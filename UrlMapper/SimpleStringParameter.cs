using System.Collections.Generic;

namespace UrlMapper
{
    public class SimpleStringParameter : ISimpleStringParameter
    {
        public string pattern { get; set; }
        Dictionary<string, string> tempdic = new Dictionary<string, string>();
        bool isMatch = false;

        public SimpleStringParameter(string pattern)
        {
            this.pattern = pattern;
        }
        public void ExtractVariables(string target, IDictionary<string, string> dicToStoreResults)
        {
            if(isMatch)
            {
                foreach (var item in tempdic)
                {
                    dicToStoreResults.Add(item);
                }
            }else
            {
                if (IsMatched(target))
                {
                    foreach (var item in tempdic)
                    {
                        dicToStoreResults.Add(item);
                    }
                }                    
            }
        }

        public bool IsMatched(string textToCompare)
        {
            //  "https://mana.com/linkto/{link-id}/xxx/yyy/{xdd}"
            //  "https://mana.com/linkto/   {   link-id}/xxx/yyy/   {   xdd}"

            //  "https://mana.com/linkto/   //TODO it is pattern

            //  link-id} aa/xxx/yyy/
            //  link-id     }   /   xxx/yyy/
            //  xdd }   "


            //  1234aa/xxx/yyy/   888/

            var split1 = pattern.Split('{');
            foreach (var item in split1)
            {
                if (item.Contains("}"))
                {
                    var param = item.Split('}');

                    if (!string.IsNullOrEmpty(param[1]))
                    {
                        if (textToCompare.Contains(param[1]))
                        {
                            var endValueIndex = textToCompare.IndexOf(param[1]);
                            var value = textToCompare.Substring(0, endValueIndex);

                            //TODO it is key contained
                            var fckparam = param[1].Split('/');
                            if (!string.IsNullOrEmpty(fckparam[0]))
                            {
                                tempdic.Add("{" + param[0] + "}", value + fckparam[0]);
                            }
                            else
                            {
                                tempdic.Add("{" + param[0] + "}", value);
                            }
                            textToCompare = textToCompare.Substring(value.Length + param[1].Length);

                        }else { return false; }
                        //TODO match next pattern
                    }else 
                    {
                        tempdic.Add( "{" + param[0] + "}", textToCompare);
                    }
                }
                else
                {
                    //TODO it is pattern go match
                    if (textToCompare.StartsWith(item))
                    {
                        textToCompare = textToCompare.Substring(item.Length);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return isMatch = true ;
        }
    }
}
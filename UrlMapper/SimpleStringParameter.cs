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
        //  "https://mana.com/linkto/aa{link-id}/xxx/yyy/{xdd}"
        //  "https://mana.com/linkto/aa     {   link-id}/xxx/yyy/   {   xdd}"

        //  "https://mana.com/linkto/aa   //TODO it is pattern

        //  link-id} aa/xxx/yyy/
        //  link-id     }   /   xxx/yyy/
        //  xdd }   "


        //  1234aa/xxx/yyy/   888/

        //https://mana.com/linkto/  {   link-id     }   aa/g
        https://mana.com/linkto/A2348


            var split1 = pattern.Split('{');
            var nextPrefixValue = string.Empty;
            foreach (var item in split1)
            {
                if (item.Contains("}"))
                {
                    var param = item.Split('}');

                    if (!string.IsNullOrEmpty(param[1]))
                    {
                        var aarightsplit = param[1].Split('/');
                        var remain = param[1].Substring(aarightsplit[0].Length);

                        if (aarightsplit.Length == 1 || aarightsplit[1] == null)
                        {
                            tempdic.Add("{" + nextPrefixValue + param[0] + aarightsplit[0] + "}", textToCompare);
                        }
                        else if (textToCompare.Contains(remain))
                        {
                            //aarightsplit[1] = "/" + aarightsplit[1];
                            var endValueIndex = textToCompare.IndexOf(param[1].Substring(aarightsplit[0].Length));
                            var value = textToCompare.Substring(0, endValueIndex);

                            //TODO it is key contained
                            //var aaright = aarightsplit[1].Split('/');
                            if (!string.IsNullOrEmpty(aarightsplit[0]))
                            {
                                tempdic.Add("{" + nextPrefixValue + param[0] + aarightsplit[0] + "}", value);
                            }
                            else
                            {
                                tempdic.Add("{" + nextPrefixValue + param[0] + "}", value);
                            }
                            textToCompare = textToCompare.Substring(value.Length + remain.Length);

                        }else { return false; }
                        //TODO match next pattern
                    }else 
                    {
                        tempdic.Add( "{" + nextPrefixValue + param[0] + "}", textToCompare);
                    }
                }
                else
                {
                    var aaleft = item.Split('/');
                    var subtext = item;
                    if (!string.IsNullOrEmpty(aaleft[aaleft.Length - 1]))
                    {
                        nextPrefixValue = aaleft[aaleft.Length - 1];
                        subtext = subtext.Remove(item.Length - aaleft[aaleft.Length - 1].Length);
                    }
                    //TODO it is pattern go match
                    if (textToCompare.StartsWith(subtext))
                    {
                        textToCompare = textToCompare.Substring(subtext.Length);
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
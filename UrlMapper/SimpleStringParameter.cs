using System.Collections.Generic;

namespace UrlMapper
{
    public class SimpleStringParameter : ISimpleStringParameter
    {
        public string pattern { get; set; }

        public SimpleStringParameter(string pattern)
        {
            this.pattern = pattern;
        }
        public void ExtractVariables(string target, IDictionary<string, string> dicToStoreResults)
        {
            throw new System.NotImplementedException();
        }

        public bool IsMatched(string textToCompare)
        {
            //  "https://mana.com/linkto/{link-id}/xxx/yyy/{xdd}"
            //  "https://mana.com/linkto/   {   link-id}/xxx/yyy/   {   xdd}"

            //  "https://mana.com/linkto/   //TODO it is pattern

            //  link-id}/xxx/yyy/
            //  link-id     }   /xxx/yyy/
            //  xdd }   "

            //  "123"

            Dictionary<string, string> tempdic = new Dictionary<string, string>();

            var split1 = pattern.Split('{');
            foreach (var item in split1)
            {
                if (item.Contains("}"))
                {
                    //TODO it is key contained
                    var param = item.Split('}');
                    tempdic.Add(param[0], null); 
                    //TODO get value

                    if (!string.IsNullOrEmpty(param[1]))
                    {
                        //TODO match next pattern
                    }
                }else
                {
                    //TODO it is pattern go match
                }
            }
            throw new System.NotImplementedException();
        }
    }
}
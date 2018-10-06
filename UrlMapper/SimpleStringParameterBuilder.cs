using System.Collections.Generic;

namespace UrlMapper
{
    public class SimpleStringParameterBuilder : ISimpleStringParameterBuilder
    {
        public ISimpleStringParameter Parse(string pattern)
        {
            if (pattern == null || pattern == "")
            {
                return null;
            }
            else
            {
                // TODO: Need to implement this method.
                SimpleStringParameter sp = new SimpleStringParameter(pattern);

                return sp;
            }

        }
    }
}
using System.Collections.Generic;

namespace UrlMapper
{
    public interface ISimpleStringParameterBuilder
    {
        ISimpleStringParameter Parse(string pattern);
    }
}
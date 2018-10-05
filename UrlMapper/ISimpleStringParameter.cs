using System.Collections.Generic;

namespace UrlMapper
{
    public interface ISimpleStringParameter
    {
        bool IsMatched(string textToCompare);
        void ExtractVariables(string target, IDictionary<string, string> dicToStoreResults);
    }
}
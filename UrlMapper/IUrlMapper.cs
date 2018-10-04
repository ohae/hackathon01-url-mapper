using System.Collections.Generic;

namespace UrlMapper
{
    public interface IUrlMapper
    {
        IEnumerable<string> GetMatchedPatterns(string url, params string[] patterns);
        IDictionary<string, string> ExtractVariables(string url, string pattern);
    }
}
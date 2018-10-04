using System.Collections.Generic;

namespace UrlMapper
{
    public class UrlMapper : IUrlMapper
    {
        public IDictionary<string, string> ExtractVariables(string url, string pattern)
        {
            // TODO: Need to implement this method.
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetMatchedPatterns(string url, params string[] patterns)
        {
            // TODO: Need to implement this method.
            throw new System.NotImplementedException();
        }
    }
}
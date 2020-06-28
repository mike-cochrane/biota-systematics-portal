using System.Collections.Generic;

namespace SearchLibrary.Implementation
{
    internal class ExtraParameters
    {
        internal List<KeyValuePair<string, string>> BuildExtraParameters()
        {
            List<KeyValuePair<string, string>> extraParameters = new List<KeyValuePair<string, string>>();

            extraParameters.Add(new KeyValuePair<string, string>("q.op", "AND"));
            // As the "text" field is not declared as default parameter on solr,
            // we need that solrnet uses this field as default parameter
            extraParameters.Add(new KeyValuePair<string, string>("df", "text"));

            return extraParameters;
        }

    }
}

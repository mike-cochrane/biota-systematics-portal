using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systematics.Portal.Web.Api.Access.Infrastructure
{
    public class AppSettings
    {
        public IdentityServerSettings IdentityServer { get; set; }

        public SolrSettings Solr { get; set; }
    }

    public class IdentityServerSettings
    {
        public string Url { get; set; }
        public string ApiName { get; set; }
    }

    public class SolrSettings
    {
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}

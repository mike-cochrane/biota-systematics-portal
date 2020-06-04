using CommonServiceLocator;
using HttpWebAdapters;
using HttpWebAdapters.Adapters;
using SolrNet;
using System;
using System.Net;
using System.Text;
using Systematics.Portal.Web.Search.Tools.Models;

namespace SearchLibrary.Implementation
{
    public class Connection
    {
        public readonly ISolrOperations<Document> SolrCore;

        // Initialize the connection and provide it to the search library
        public Connection(string coreUrl,string userName, string password)
        {
            var solrConnection = new SolrNet.Impl.SolrConnection(coreUrl)
            {
                HttpWebRequestFactory = new SecureHttpWebRequestFactory(userName, password)
            };

            // Enable the following line in case that you get the error "url string is too long"
            // Notice that we'll use our own implementation to obtain a POST connection.
            //Startup.Init<Image>(new MyPostSolrConnection(solrConnection, coreUrl,userName,password));
            Startup.Init<Document>(solrConnection);

            SolrCore = ServiceLocator.Current.GetInstance<ISolrOperations<Document>>();
        }

        private class SecureHttpWebRequestFactory : IHttpWebRequestFactory
        {
            private readonly string _username;
            private readonly string _password;

            public SecureHttpWebRequestFactory(string username, string password)
            {
                _username = username;
                _password = password;
            }

            public IHttpWebRequest Create(string url)
            {
                return Create(new Uri(url));
            }

            public IHttpWebRequest Create(Uri url)
            {
                var req = (HttpWebRequest)WebRequest.Create(url);
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_username + ":" + _password));

                req.Headers.Add("Authorization", "Basic " + credentials);

                return new HttpWebRequestAdapter(req);
            }
        }

    }
}
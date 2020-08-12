using CommonServiceLocator;
using HttpWebAdapters;
using HttpWebAdapters.Adapters;
using SolrNet;
using System;
using System.Net;
using System.Text;
using SystematicsData.Search.Tools.Models;

namespace SystematicsData.Search.Infrastructure
{
    public class SolrConnection : Tools.Models.Interfaces.ISolrConnection
    {
        public readonly ISolrOperations<SolrDocument> _solrCore;

        // Initialize the connection and provide it to the search library
        public SolrConnection(string coreUrl, string userName, string password)
        {
            SolrNet.Impl.SolrConnection solrConnection;
            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
            {
                solrConnection = new SolrNet.Impl.SolrConnection(coreUrl);
            }
            else
            {
                solrConnection = new SolrNet.Impl.SolrConnection(coreUrl)
                {
                    HttpWebRequestFactory = new SecureHttpWebRequestFactory(userName, password)
                };
            }

            // Enable the following line in case that you get the error "url string is too long"
            // Notice that we'll use our own implementation to obtain a POST connection.
            //Startup.Init<Document>(new MyPostSolrConnection(solrConnection, coreUrl,userName,password));
            Startup.Init<SolrDocument>(solrConnection);

            _solrCore = ServiceLocator.Current.GetInstance<ISolrOperations<SolrDocument>>();
        }

        public ISolrOperations<SolrDocument> GetSolrCore()
        {
            return _solrCore;
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

                if (!(string.IsNullOrEmpty(_username) || string.IsNullOrEmpty(_password)))
                {
                    var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_username + ":" + _password));

                    req.Headers.Add("Authorization", "Basic " + credentials);
                }

                return new HttpWebRequestAdapter(req);
            }
        }

    }
}
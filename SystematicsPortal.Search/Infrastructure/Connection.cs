using CommonServiceLocator;
using HttpWebAdapters;
using HttpWebAdapters.Adapters;
using SolrNet;
using System;
using System.Net;
using System.Text;
using SystematicsPortal.Search.Tools.Models;

namespace SearchLibrary.Implementation
{
    public class Connection
    {
        public readonly ISolrOperations<SolrDocument> SolrCore;

        // Initialize the connection and provide it to the search library
        public Connection(string coreUrl, string userName, string password)
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

            SolrCore = ServiceLocator.Current.GetInstance<ISolrOperations<SolrDocument>>();
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
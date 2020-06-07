using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Systematics.Portal.Web.Api.Access.Demo
{
    class Client
    {
        private readonly HttpClient _client;


        public Client()
        {
            _client = new HttpClient();
        }

        public object JsonConvert { get; private set; }

        public async Task CallService()
        {
            bool waitCondition = true;
            while (waitCondition)
            {
                Console.Write("Enter search name:");
                string imageName = Console.ReadLine();
                Console.Write("Enter Facet:");
                string facetName = Console.ReadLine();
                Console.Write("Enter result per page:");
                string resultPerPage = Console.ReadLine();

                Console.Write("Enter page number:");
                string pageNumber = Console.ReadLine();

                string urlToQuery = "http://localhost:29578/" + "search?query=" + imageName + "&resultsPerPage=" + resultPerPage + "&pageNumber=" + pageNumber + "&facets=" + facetName;


                try
                {

                    var baseAddress = urlToQuery;

                    var client = new HttpClient
                    {
                        BaseAddress = new Uri(baseAddress)
                    };

                   
                    var response = await client.GetStringAsync(urlToQuery);

                    Console.WriteLine(response.ToString());
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);

                }

                Console.Write("Do you want to Try again Yes/No:");
                string userResponse = Console.ReadLine();

                if (userResponse == "No" || userResponse == "N")
                    waitCondition = false;
            }


        }
    }
}

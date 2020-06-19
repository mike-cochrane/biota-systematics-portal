using System;
using System.Threading.Tasks;

namespace SystematicsPortal.Web.Api.Demo
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Title = "Systemtics Portal API Demo";

            var client = new SystematicsPortal.Web.Api.Client.Client("http://localhost:29578/");
            bool waitCondition = true;
            while (waitCondition)
            {
                Console.Write("Enter search name:");
                string query = Console.ReadLine();
                Console.Write("Enter result per page:");
                string resultsPerPage = Console.ReadLine();
                Console.Write("Enter page number:");
                string pageNumber = Console.ReadLine();


                await client.CallService(query, string.IsNullOrEmpty(pageNumber) ? 0 : int.Parse(pageNumber), string.IsNullOrEmpty(resultsPerPage) ? 100 : int.Parse(resultsPerPage));

                Console.Write("Do you want to Try again Yes/No:");
                string userResponse = Console.ReadLine();

                if (userResponse == "No" || userResponse == "N")
                {
                    waitCondition = false;
                }
            }
        }
    }
}

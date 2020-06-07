using System;
using System.Threading.Tasks;

namespace Systematics.Portal.Web.Api.Access.Demo
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Title = "Systemtics Portal API Demo";

            var client = new Client();

            await client.CallService ();
        }
    }
}

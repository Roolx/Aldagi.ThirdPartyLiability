using IdentityModel;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aldagi.IdentityClientTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAuthenticationToken().Wait();
        }

        static async Task GetAuthenticationToken()
        {
            var discoveryResponse = await DiscoveryClient.GetAsync("http://localhost:5000");
            if (discoveryResponse.IsError)
            {
                Console.WriteLine(discoveryResponse.Error);
                return;
            }

            var tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, "adminClient", "secret");
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("admin","123");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);


            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:5001/liabilities/2");

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine( JObject.Parse(content));

            Console.ReadLine();
        }
    }
}

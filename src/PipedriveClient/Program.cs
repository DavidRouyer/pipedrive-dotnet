using System;
using System.Threading.Tasks;

namespace Pipedrive.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            PipedriveClient client = new PipedriveClient(
                new ProductHeaderValue("Pipedrive.app.csharp"),
                new Uri("https://thin-geology.pipedrive.com/"),
                "51a89f20c71512b63ab5d1182a70b13ca04daeea");

            var result = await client.Currency.GetAll("EUR");
            Console.WriteLine(result);
        }
    }
}

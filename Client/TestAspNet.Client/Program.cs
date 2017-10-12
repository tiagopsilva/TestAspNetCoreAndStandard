using System;
using System.Linq;
using System.Net.Http;

namespace TestAspNet.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string ASPNETCORE = "http://testcore.DOMINIO.com.br";
            const string ASPNETSTANDARD = "http://teststandard.DOMINIO.com.br";

            try
            {
                Console.WriteLine("Select application to test:");
                Console.WriteLine("(1) ASP.NET Core");
                Console.WriteLine("(2) ASP.NET Standard");
                var option = 0;
                var options = new[] {1, 2};
                while (!options.Contains(option))
                {
                    Console.Write("Set option: ");
                    var input = Console.ReadLine();
                    if (!int.TryParse(input, out option) || !options.Contains(option))
                        Console.Write("Invalid option! ");
                    else
                        break;
                }

                var startTime = DateTime.Now;

                Console.WriteLine($"\nStart time: {(DateTime.Now - startTime)}");
                Console.WriteLine("Processing...");
                Console.WriteLine();

                var client = new HttpClient { BaseAddress = new Uri(option == 1 ? ASPNETCORE : ASPNETSTANDARD) };

                for (var index = 0; index < 100; index++)
                {
                    var currentItemStartTime = DateTime.Now;
                    var result = client.GetAsync("api/customers").GetAwaiter().GetResult();
                    Console.WriteLine($"index: {index}, status: {result.StatusCode}, time: {(DateTime.Now - currentItemStartTime).TotalMilliseconds} ms");
                }

                Console.WriteLine($"\nElapsed time: {(DateTime.Now - startTime):g}");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\nERROR");
                Console.WriteLine(e);
            }
            finally
            {
                Console.Write("\nProcess terminated! Press ENTER to exit: ");
                Console.ReadLine();
            }
        }
    }
}

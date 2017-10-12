using System;
using System.Linq;
using System.Net.Http;

namespace TestAspNet.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string ASPNETCORE = "http://localhost:5001";
            const string ASPNETSTANDARD = "http://localhost:5002";

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

                Console.WriteLine();
                Console.WriteLine("Processing...");
                Console.WriteLine();

                var client = new HttpClient { BaseAddress = new Uri(option == 1 ? ASPNETCORE : ASPNETSTANDARD) };

                for (var index = 0; index < 100; index++)
                {
                    var result = client.GetAsync("api/customers").GetAwaiter().GetResult();
                    Console.WriteLine($"index: {index}, status: {result.StatusCode}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("ERROR");
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine();
                Console.Write("Process terminated! Press ENTER to exit: ");
                Console.ReadLine();
            }
        }
    }
}

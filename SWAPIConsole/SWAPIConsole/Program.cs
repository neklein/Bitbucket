using SWAPIConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace SWAPIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            bool askAgain = true;
            WriteLogo();
            Console.WriteLine("\n Ship Search utility \n");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            while (askAgain)
            {
                Console.Clear();
                Console.Write("Enter a ship search term (Q to exit): ");
                string shipId = Console.ReadLine();
                if (shipId.ToLower().Equals("q"))
                    askAgain = false;
                else
                    DoGetShip(shipId);
            }
            WriteLogo();
            Console.WriteLine("\n May the Force be with you. \n");
            Thread.Sleep(3000);
        }
        private static void DoGetShip(string shipId)
        {
            SWAPIModels model = null;
            HttpClient client = new HttpClient();

            string uri = $"https://swapi.co/api/starships?search={shipId}";
            var task = client.GetAsync(uri).ContinueWith((taskForResponse) =>
            {
                HttpResponseMessage response = taskForResponse.Result;
                var processJson = response.Content.ReadAsAsync<SWAPIModels>();
                processJson.Wait();
                model = processJson.Result;
            });

            task.Wait();
            DisplaySearchResults(model);
        }
        private static void DisplaySearchResults(SWAPIModels model)
        {
            foreach (ShipJson ship in model.shipList)
            {
                Console.WriteLine("~~~~~~~Ship Details~~~~~~~~");
                Console.WriteLine($"Ship Name: {ship.ShipName}");
                Console.WriteLine($"Ship Model: {ship.ShipModel}");
                Console.WriteLine($"Ship Class: {ship.ShipClass}");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        private static void WriteLogo()
        {
            Console.WriteLine("                  ________________.  ___     .______  ");
            Console.WriteLine("                 /                | /   \\    |   _  \\");
            Console.WriteLine("                |   (-----|  |----`/  ^  \\   |  |_)  |");
            Console.WriteLine("                 \\   \\    |  |    /  /_\\  \\  |      /");
            Console.WriteLine("            .-----)   |   |  |   /  _____  \\ |  |\\  \\-------.");
            Console.WriteLine("            |________/    |__|  /__/     \\__\\| _| `.________|");
            Console.WriteLine("             ____    __    ____  ___     .______    ________.");
            Console.WriteLine("             \\   \\  /  \\  /   / /   \\    |   _  \\  /        |");
            Console.WriteLine("              \\   \\/    \\/   / /  ^  \\   |  |_)  ||   (-----`");
            Console.WriteLine("               \\            / /  /_\\  \\  |      /  \\   \\");
            Console.WriteLine("                \\    /\\    / /  _____  \\ |  |\\  \\---)   |");
            Console.WriteLine("                 \\__/  \\__/ /__/     \\__\\|__| `._______/");
        }
    }
}

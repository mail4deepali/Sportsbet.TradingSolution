// See https://aka.ms/new-console-template for more information
using Sportbet.TradingSolution.Models;
using Sportbet.TradingSolution.Services;

namespace Sportbet.TradingSolution
{
    class Program
    {
        static void Main(string[] args)
        {

            Player TomBrady = new Player() { Number = 12, Name = "Tom Brady" };
            Player BlaineGabbert = new Player() { Number = 11, Name = "Blaine Gabbert" };
            Player KyleTrask = new Player() { Number = 2, Name = "Kyle Trask" };

            Player MikeEvans = new Player() { Number = 13, Name = "Mike Evans" };
            Player JaelonDarden = new Player() { Number = 1, Name = "Jaelon Darden" };
            Player ScottMiller = new Player() { Number = 10, Name = "Scott Miller" };

            DepthChartService depthChartService = new DepthChartService();
            depthChartService.AddPlayerToDepthChart("QB", TomBrady, 0);
            depthChartService.AddPlayerToDepthChart("QB", BlaineGabbert, 1);
            depthChartService.AddPlayerToDepthChart("QB", KyleTrask, 2);

            depthChartService.AddPlayerToDepthChart("LWR", MikeEvans, 0);
            depthChartService.AddPlayerToDepthChart("LWR", JaelonDarden, 1);
            depthChartService.AddPlayerToDepthChart("LWR", ScottMiller, 2);

            depthChartService.GetFullDepthChart();

            Console.WriteLine("Back up TomBrady");
            List<Player> backUpTomBrady = depthChartService.GetBackups("QB", TomBrady);
            PrintPlayers(backUpTomBrady);

            Console.WriteLine();
            Console.WriteLine("Back up JaelonDarden");

            List<Player> backUpJaelonDarden = depthChartService.GetBackups("QB", JaelonDarden);
            PrintPlayers(backUpJaelonDarden);

            Console.WriteLine();
            Console.WriteLine("Back up MikeEvans");
            List <Player> backUpMikeEvans = depthChartService.GetBackups("QB", MikeEvans);
            PrintPlayers(backUpMikeEvans);

            Console.WriteLine();
            Console.WriteLine("Back up BlaineGabbert");

            List<Player> backUpBlaineGabbert = depthChartService.GetBackups("QB", BlaineGabbert);
            PrintPlayers(backUpBlaineGabbert);

            Console.WriteLine();
            Console.WriteLine("Back up KyleTrask");

            List<Player> backUpKyleTrask = depthChartService.GetBackups("QB", KyleTrask);
            PrintPlayers(backUpKyleTrask);

            Player removedplayer = depthChartService.RemovePlayerFromDepthChart("LWR", MikeEvans);

            if (removedplayer != null)
            {
                Console.WriteLine("Removed Player");
                PrintPlayers(new List<Player> { removedplayer });
            }
            depthChartService.GetFullDepthChart();
        }

        public static void PrintPlayers(List<Player> players)
        {
            if (players.Count == 0)
            {
                Console.WriteLine("No Backup");
            }
            else
            {
                foreach (Player player in players)
                {
                    Console.Write("  ");
                    Console.Write(player.Number);
                    Console.Write("  ");
                    Console.Write(player.Name);
                    Console.WriteLine();
                }
            }
        }
    }
}

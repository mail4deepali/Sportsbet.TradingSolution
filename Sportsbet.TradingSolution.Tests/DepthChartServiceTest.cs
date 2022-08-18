using Sportbet.TradingSolution.Models;
using Sportbet.TradingSolution.Services;
using System.Collections.Generic;
using Xunit;

namespace Sportsbet.TradingSolution.Tests
{
    public class DepthChartServiceTest
    {
        [Fact]
        public void AddPlayerToDepthChartTest()
        {
            Player SmithDonovon = new Player() { Number = 12, Name = "Smith Donovon" };
            DepthChartService depthChartService = new DepthChartService();
            depthChartService.AddPlayerToDepthChart("QB", SmithDonovon, 0);
            DepthChartData depthChartData = depthChartService.depthCharts.Find(t => t.Position == "QB" && t.PositionDepth == 0 && t.Player == SmithDonovon);
            Assert.Equal(0, depthChartData.PositionDepth);
            Assert.Equal("QB", depthChartData.Position);
            Assert.Equal(SmithDonovon, depthChartData.Player);
        }


        [Fact]
        public void AddPlayerToExistingPosition()
        {
            Player SmithDonovon = new Player() { Number = 12, Name = "Smith Donovon" };
            Player HowardOJ = new Player() { Number = 80, Name = "Howard OJ" };
            Player CappaAlex = new Player() { Number = 80, Name = "Cappa Alex" };
            DepthChartService depthChartService = new DepthChartService();
            depthChartService.AddPlayerToDepthChart("QB", SmithDonovon, 0);
            depthChartService.AddPlayerToDepthChart("QB", HowardOJ, 0);
            depthChartService.AddPlayerToDepthChart("QB", CappaAlex, 0);
            DepthChartData depthChartData = depthChartService.depthCharts.Find(t => t.Position == "QB" && t.Player == SmithDonovon);
            Assert.Equal(2, depthChartData.PositionDepth);
        }

        [Fact]
        public void RemovePlayerFromDepthChartTest()
        {
            Player SmithDonovon = new Player() { Number = 12, Name = "Smith Donovon" };
            DepthChartService depthChartService = new DepthChartService();
            depthChartService.depthCharts.Add(new DepthChartData() { Position = "QB", PositionDepth = 0, Player = SmithDonovon });
            depthChartService.RemovePlayerFromDepthChart("QB", SmithDonovon);
            DepthChartData depthChartData = depthChartService.depthCharts.Find(t => t.Position == "QB" && t.PositionDepth == 0 && t.Player == SmithDonovon);
            Assert.Equal(null, depthChartData);
        }

        [Fact]
        public void RemovePlayerFromDepthChartTestWithMultiplePlayers()
        {
            Player SmithDonovon = new Player() { Number = 12, Name = "Smith Donovon" };
            Player HowardOJ = new Player() { Number = 80, Name = "Howard OJ" };
            Player CappaAlex = new Player() { Number = 80, Name = "Cappa Alex" };
            DepthChartService depthChartService = new DepthChartService();
            depthChartService.depthCharts.Add(new DepthChartData() { Position = "QB", PositionDepth = 0, Player = SmithDonovon });
            depthChartService.depthCharts.Add(new DepthChartData() { Position = "QB", PositionDepth = 1, Player = HowardOJ });
            depthChartService.depthCharts.Add(new DepthChartData() { Position = "QB", PositionDepth = 2, Player = CappaAlex });

            depthChartService.RemovePlayerFromDepthChart("QB", SmithDonovon);
            DepthChartData depthChartData = depthChartService.depthCharts.Find(t => t.Position == "QB" && t.PositionDepth == 0 && t.Player == SmithDonovon);
            Assert.Equal(null, depthChartData);
        }

        [Fact]
        public void GetBackupsTest()
        {
            Player SmithDonovon = new Player() { Number = 12, Name = "Smith Donovon" };
            DepthChartService depthChartService = new DepthChartService();
            depthChartService.depthCharts.Add(new DepthChartData() { Position = "QB", PositionDepth = 0, Player = SmithDonovon });
            Player MarpetAli = new Player() { Number = 12, Name = "Marpet Ali" };
            depthChartService.depthCharts.Add(new DepthChartData() { Position = "QB", PositionDepth = 1, Player = MarpetAli });
            List<Player> backupsSmithDonovon = depthChartService.GetBackups("QB", SmithDonovon);
            Assert.Equal(backupsSmithDonovon.Count, 1);
            Player player = backupsSmithDonovon[0];
            Assert.Equal(12, player.Number);
            Assert.Equal("Marpet Ali", player.Name);
        }
    }
}
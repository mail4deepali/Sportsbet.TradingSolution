using Sportbet.TradingSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportbet.TradingSolution.Services
{
    public class TeamService
    {
        public static List<Team> _teams = new List<Team>();
        public void AddTeam(string teamName)
        {
            _teams.Add(new Team() { Name = teamName });
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using football_api;
namespace Feasibilityapp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetTournament();
            GetStandings();
            Console.ReadKey();
        }

        private static async Task GetTournament()
        {
            var result = await ScoreProvider.Instance.GetTournaments();
            Console.WriteLine("Competition Name : " + result.Competition[0].name);
            Console.WriteLine("Competition Id : " + result.Competition[0].id);
            Console.WriteLine("Competition Region : " + result.Competition[0].region);            
        }

        private static async Task GetStandings()
        {
            var result = await ScoreProvider.Instance.GetStandings(1204);
            foreach (var team in result.teams)
            {
                Console.WriteLine("Team Name : " + team.stand_team_name);
                Console.WriteLine("Team Position: " + team.stand_position);
                Console.WriteLine("Team Form : " + team.stand_recent_form);
            }
        }
    }
}

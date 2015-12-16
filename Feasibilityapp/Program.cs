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
           var comp = GetTournament();
           GetStandings(comp);
            Console.ReadKey();
        }

        private static CompetitionInfo GetTournament()
        {
            var result = ScoreProvider.Instance.GetCompetetions();

            Console.WriteLine("Competition Name : " + result.Result.Competition[0].name);
            Console.WriteLine("Competition Id : " + result.Result.Competition[0].id);
            Console.WriteLine("Competition Region : " + result.Result.Competition[0].region);
            return result.Result;
        }

        private static async Task GetStandings(CompetitionInfo comp)
        {
            foreach (var item in comp.Competition)
            {
                int id;
                int.TryParse(item.id, out id);
                var result = await ScoreProvider.Instance.GetStandingsAsync(id);
                foreach (var team in result)
                {
                    Console.WriteLine("Team Name : " + team.Team.Name);
                    Console.WriteLine("Team Position: " + team.Position);
                    Console.WriteLine("Team Form : " + team.Form);
                }
                Console.WriteLine("---------------------------------------");
            }
        }
    }
}

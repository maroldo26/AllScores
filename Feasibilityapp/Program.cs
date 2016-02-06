using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllScores.Common.Data.Base;
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

        private static List<Tournament> GetTournament()
        {
            var result = ScoreProvider.Instance.GetCompetetions();

            Console.WriteLine("Competition Name : " + result.Result[0].Name);
            Console.WriteLine("Competition Id : " + result.Result[0].Id);
            Console.WriteLine("Competition Region : " + result.Result[0].Country);
            return result.Result;
        }

        private static async Task GetStandings(List<Tournament> comp)
        {
            foreach (var item in comp)
            {
                int id;
                int.TryParse(item.Id, out id);
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

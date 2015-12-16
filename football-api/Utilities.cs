using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AllScores.Common.Data.Base;
using AllScores.Common.Data.Football;
using Newtonsoft.Json;

namespace football_api
{
    static class Utilities
    {
        public static HttpClient CreateWebRequest(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static T ConvertJsonToObject<T>(string json)
        {
            var o = JsonConvert.DeserializeObject<T>(json);
            return o;
        }

        public static List<Competition> GetStaticLeagues()
        {
            var leaguestring = football_api.Properties.Resources.LeagueId;
            var leagues = new List<Competition>();

            foreach (var item in leaguestring.Split(','))
            {
                var detail = item.Split(';');
                leagues.Add(new Competition() 
                { 
                    id = detail[0],
                    name = detail[1], 
                    region = detail[2] 
                });
            }
            return leagues;
        }

        public static Fixtures ConvertMatchInfoToFixtures(MatchInfo matches)
        {
            Fixtures fixtures = new Fixtures();
            foreach (var match in matches.matches)
            {
                FootballFixture fixture = new FootballFixture();
                fixture.Id = match.match_id.ToInt();
                fixture.HomeTeam = new FootballTeam()
                {
                    Id = match.match_localteam_id,
                    Name = match.match_localteam_name,
                    TeamType = SportType.TeamSport
                };
                fixture.Score = match.match_ft_score;
                fixture.Date = match.match_date;
                fixtures.Add(fixture);
            }
            return fixtures;
        }

        public static Standings ConvertTeamsInfoToStandings(TeamsInfo teams)
        {
            Standings standings = new Standings();
            foreach (var team in teams.teams)
            {
                Standing standing = new Standing(){
                    Team = new FootballTeam()
                    {
                        Id = team.stand_team_id,
                        Name = team.stand_team_name,
                        TeamType = SportType.TeamSport
                    },
                    Form = team.stand_recent_form,
                    Points = team.stand_points,
                    Position = team.stand_position,
                    GoalsAgainst = team.stand_overall_ga,
                    GoalsFor = team.stand_overall_gs,
                    GamesPlayed = team.stand_overall_gp,
                    GoalDifference = team.stand_overall_gs
                };
                standings.Add(standing);
            }
            return standings;
        }

        public static int ToInt(this string number)
        {
            int no;
            int.TryParse(number, out no);
            return no;
        }
    }
}

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
            foreach (var match in matches)
            {
                FootballFixture fixture = new FootballFixture();
                fixture.Id = match.id.ToInt();
                fixture.HomeTeam = new FootballTeam()
                {
                    Id = match.localteam_id,
                    Name = match.localteam_name,
                    TeamType = SportType.TeamSport
                };

                fixture.AwayTeam = new FootballTeam()
                {
                    Id = match.visitorteam_id,
                    Name = match.visitorteam_name,
                    TeamType = SportType.TeamSport
                };

                fixture.Venue = match.venue;

                fixture.Score = match.ft_score;
                fixture.Date = match.formatted_date;
                fixtures.Add(fixture);
            }
            return fixtures;
        }

        public static Standings ConvertTeamsInfoToStandings(TeamsInfo teams)
        {
            Standings standings = new Standings();
            foreach (var team in teams)
            {
                Standing standing = new Standing(){
                    Team = new FootballTeam()
                    {
                        Id = team.team_id,
                        Name = team.team_name,
                        TeamType = SportType.TeamSport
                    },
                    Form = team.recent_form,
                    Points = team.points,
                    Position = team.position,
                    GoalsAgainst = team.overall_ga,
                    GoalsFor = team.overall_gs,
                    GamesPlayed = team.overall_gp,
                    GoalDifference = team.overall_gs
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

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
                fixture.APIId = Constants.APIId;
                fixture.HomeTeam = new FootballTeam()
                {
                    Id = match.localteam_id,
                    APIId = Constants.APIId,
                    Name = match.localteam_name,
                    TeamType = SportType.TeamSport
                };

                fixture.AwayTeam = new FootballTeam()
                {
                    Id = match.visitorteam_id,
                    APIId = Constants.APIId,
                    Name = match.visitorteam_name,
                    TeamType = SportType.TeamSport
                };
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
                        APIId = Constants.APIId,
                        Name = team.team_name,
                        TeamType = SportType.TeamSport
                    },
                    Form = team.recent_form,
                    APIId = Constants.APIId,
                    Points = team.points,
                    Position = team.position,
                    GoalsAgainst = team.overall_ga,
                    GoalsFor = team.overall_gs,
                    GamesPlayed = team.overall_gp,
                    GoalDifference = team.overall_d
                };
                standings.Add(standing);
            }
            return standings;
        }

        public static List<Tournament> ConvertCompetitionToTournament(List<Competition> competitions)
        {
            var competetions = new List<Tournament>();
            foreach (var competition in competitions)
            {
                var competetion = new Tournament();
                competetion.APIId = Constants.APIId;
                competetion.Country = competition.region;
                competetion.Id = competition.id;
                competetion.Name = competition.name;
                competetion.Sport = Sport.Football;
                competetions.Add(competetion);
            }
            return competetions;
        }

        public static int ToInt(this string number)
        {
            int no;
            int.TryParse(number, out no);
            return no;
        }
    }
}

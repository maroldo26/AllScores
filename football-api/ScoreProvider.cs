using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllScores.Common.Data.Base;
using AllScores.Common.Data.Football;
using AllScores.Common.Exceptions;

namespace football_api
{
    public class ScoreProvider
    {

        #region Private Variables

        /// <summary>
        /// The isinitialized. 
        /// Should be set to true if sucessfuly get the tournament info.
        /// </summary>
        private bool isinitialized;

        #endregion

        #region Constructor

        /// <summary>
        /// Prevents a default instance of the <see cref="ScoreProvider"/> class from being created.
        /// dont write any code inside this constructor.
        /// </summary>
        private ScoreProvider()
        {
        }

        #endregion

        #region Static Members

        /// <summary>
        /// The instance
        /// </summary>
        private static ScoreProvider instance;

        /// <summary>
        /// The competetions
        /// </summary>
        private List<Tournament> competetions;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static ScoreProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScoreProvider();
                    instance.Inititalize();
                }
                return instance;
            }
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Inititalizes this instance.
        /// </summary>
        private async Task Inititalize()
        {
            CompetitionInfo competitions;
            var result = await this.GetTournaments();
            competitions = result;
            isinitialized = true;
            this.competetions = Utilities.ConvertCompetitionToTournament(competitions);                    
        }

        /// <summary>
        /// Gets the tournaments.
        /// </summary>
        /// <returns></returns>
        private async Task<CompetitionInfo> GetTournaments()
        {            
            var client = Utilities.CreateWebRequest(Constants.BaseUrl);
            var response = await client.GetAsync(string.Format("competitions?Authorization={0}", Constants.V2ApiKey));
            var content = response.Content;                
            string json = await content.ReadAsStringAsync();
            client.Dispose();
            return Utilities.ConvertJsonToObject<CompetitionInfo>(json);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the competetions.
        /// </summary>
        /// <value>
        /// The competetions.
        /// </value>
        public async Task<List<Tournament>> GetCompetetions()
        {
            if (!this.isinitialized)
            {
                    await this.Inititalize();
            }
            return this.competetions;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the standings.
        /// </summary>
        /// <param name="competitionid">The competitionid.</param>
        /// <returns></returns>
        public async Task<Standings> GetStandingsAsync(int competitionid)
        {
            if (!this.isinitialized)
            {
                await this.Inititalize();
            }
            var client = Utilities.CreateWebRequest(Constants.BaseUrl);
            var response =await client.GetAsync(string.Format("standings/{1}?Authorization={0}", Constants.V2ApiKey, competitionid));
            var content = response.Content;
            string json = await content.ReadAsStringAsync();
            client.Dispose();
            var teams = Utilities.ConvertJsonToObject<TeamsInfo>(json);
            return Utilities.ConvertTeamsInfoToStandings(teams);
        }

        //http://football-api.com/api/?Action=fixtures&APIKey=[YOUR_API_KEY]&comp_id=[COMPETITION]&&match_date=[DATE_IN_d.m.Y_FORMAT]
        /// <summary>
        /// Gets the fixtures for the given date.
        /// </summary>
        /// <param name="competitionid">The competition id.</param>
        /// <param name="fromdate">The date.</param>
        /// <returns></returns>
        public async Task<Fixtures> GetFixturesAsync(string competitionid, string date)
        {
            if (!this.isinitialized)
            {
                await this.Inititalize();
            }
            var client = Utilities.CreateWebRequest(Constants.BaseUrl);
            var response =await client.GetAsync(string.Format("matches?comp_id={1}&match_date={2}&Authorization={0}", Constants.V2ApiKey, competitionid, date));
            var content = response.Content;
            string json = await content.ReadAsStringAsync();
            client.Dispose();
            var matches = Utilities.ConvertJsonToObject<MatchInfo>(json);
            return Utilities.ConvertMatchInfoToFixtures(matches);
        }

        //http://football-api.com/api/?Action=fixtures&APIKey=[YOUR_API_KEY]&comp_id=[COMPETITION]&&match_date=[DATE_IN_d.m.Y_FORMAT]
        /// <summary>
        /// Gets the fixtures for the given date range.
        /// </summary>
        /// <param name="competitionid">The competition id.</param>
        /// <param name="fromdate">From date.</param>
        /// <param name="enddate">End date.</param>
        /// <returns></returns>
        public async Task<Fixtures> GetFixturesAsync(string competitionid, string fromdate, string enddate)
        {
            if (!this.isinitialized)
            {
                await this.Inititalize();
            }
            var client = Utilities.CreateWebRequest(Constants.BaseUrl);
            var response = await client.GetAsync(
                string.Format(
                "matches?comp_id={1}&from_date={2}&to_date={3}&Authorization={0}", 
                Constants.V2ApiKey, 
                competitionid, 
                fromdate, 
                enddate)
                );
            var content = response.Content;
            string json = await content.ReadAsStringAsync();
            client.Dispose();
            var matches = Utilities.ConvertJsonToObject<MatchInfo>(json);
            return Utilities.ConvertMatchInfoToFixtures(matches);
        }

        public async Task<Fixtures> GetTeamFixturesAsync(string teamid, string date)
        {
            if (!this.isinitialized)
            {
                await this.Inititalize();
            }
            var client = Utilities.CreateWebRequest(Constants.BaseUrl);
            var response = await client.GetAsync(
                string.Format(
                "matches?team_id={1}&match_date={2}&Authorization={0}",
                Constants.V2ApiKey,
                teamid,
                date)
                );
            var content = response.Content;
            string json = await content.ReadAsStringAsync();
            client.Dispose();
            var matches = Utilities.ConvertJsonToObject<MatchInfo>(json);
            return Utilities.ConvertMatchInfoToFixtures(matches);
        }

        public async Task<Fixtures> GetTeamFixturesAsync(string teamid, string startdate, string enddate)
        {
            if (!this.isinitialized)
            {
                await this.Inititalize();
            }
            var client = Utilities.CreateWebRequest(Constants.BaseUrl);
            var response = await client.GetAsync(
                string.Format(
                "matches?team_id={1}&from_date={2}&to_date={3}&Authorization={0}",
                Constants.V2ApiKey,
                teamid,
                startdate,
                enddate)
                );
            var content = response.Content;
            string json = await content.ReadAsStringAsync();
            client.Dispose();
            var matches = Utilities.ConvertJsonToObject<MatchInfo>(json);
            return Utilities.ConvertMatchInfoToFixtures(matches);
        }

        #endregion

    }
}

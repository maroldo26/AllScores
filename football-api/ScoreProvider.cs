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

        /// <summary>
        /// The list of competetions
        /// </summary>
        private CompetitionInfo competetions;

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
            var result =await this.GetTournaments();
            competetions = result;
            if (competetions.ERROR.Equals("ok", StringComparison.CurrentCultureIgnoreCase))
            {
                isinitialized = true;
                foreach (var item in Utilities.GetStaticLeagues())
                {
                    competetions.Competition.Add(item);
                }
            }
            else
            {
                var message = competetions.ERROR;
                competetions = null;
                throw new UnauthorizedAPIAccessException(message);
            }                        
        }

        /// <summary>
        /// Gets the tournaments.
        /// </summary>
        /// <returns></returns>
        private async Task<CompetitionInfo> GetTournaments()
        {
            try
            {
                var client = Utilities.CreateWebRequest(Constants.BaseUrl);
                var response = client.GetAsync(string.Format("?Action=competitions&APIKey={0}", Constants.ApiKey));
                var content = response.Result.Content;                
                string json = await content.ReadAsStringAsync();
                client.Dispose();
                return Utilities.ConvertJsonToObject<CompetitionInfo>(json);
            }
            catch (Exception)
            {                
                throw;
            }
            
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the competetions.
        /// </summary>
        /// <value>
        /// The competetions.
        /// </value>
        public async Task<CompetitionInfo> GetCompetetions()
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
            try
            {
                if (!this.isinitialized)
                {
                    await this.Inititalize();
                }
                var client = Utilities.CreateWebRequest(Constants.BaseUrl);
                var response = client.GetAsync(string.Format("?Action=standings&APIKey={0}&comp_id={1}", Constants.ApiKey, competitionid));
                var content = response.Result.Content;
                string json = await content.ReadAsStringAsync();
                client.Dispose();
                var teams = Utilities.ConvertJsonToObject<TeamsInfo>(json);
                return Utilities.ConvertTeamsInfoToStandings(teams);
            }
            catch (Exception)
            {

                throw;
            }
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
            var response = client.GetAsync(string.Format("?Action=fixtures&APIKey={0}&comp_id={1}&&match_date={2}", Constants.ApiKey, competitionid, date));
            var content = response.Result.Content;
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
            var response = client.GetAsync(
                string.Format(
                "?Action=fixtures&APIKey={0}&comp_id={1}&&match_date={2}", 
                Constants.ApiKey, 
                competitionid, 
                fromdate, 
                enddate)
                );
            var content = response.Result.Content;
            string json = await content.ReadAsStringAsync();
            client.Dispose();
            var matches = Utilities.ConvertJsonToObject<MatchInfo>(json);
            return Utilities.ConvertMatchInfoToFixtures(matches);
        }
 
        #endregion
        
    }
}

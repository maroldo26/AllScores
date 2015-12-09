using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace football_api
{
    public class ScoreProvider
    {
        private ScoreProvider()
        {

        }

        private static ScoreProvider instance;

        public static ScoreProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScoreProvider();
                }
                return instance;
            }
        }

        public async Task<CompetitionInfo> GetTournaments()
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

        public async Task<TeamsInfo> GetStandings(int competitionid)
        {
            try
            {
                var client = Utilities.CreateWebRequest(Constants.BaseUrl);
                var response = client.GetAsync(string.Format("?Action=standings&APIKey={0}&comp_id={1}", Constants.ApiKey, competitionid));
                var content = response.Result.Content;                
                string json = await content.ReadAsStringAsync();
                client.Dispose();
                return Utilities.ConvertJsonToObject<TeamsInfo>(json);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //http://football-api.com/api/?Action=fixtures&APIKey=[YOUR_API_KEY]&comp_id=[COMPETITION]&&match_date=[DATE_IN_d.m.Y_FORMAT]
        public async Task<MatchInfo> GetFixtures(string competitionid,string date)
        {
            var client = Utilities.CreateWebRequest(Constants.BaseUrl);
            var response = client.GetAsync(string.Format("?Action=fixtures&APIKey={0}&comp_id={1}&&match_date={2}", Constants.ApiKey, competitionid, date));
            var content = response.Result.Content;
            string json = await content.ReadAsStringAsync();
            client.Dispose();
            return Utilities.ConvertJsonToObject<MatchInfo>(json);
        }

    }
}

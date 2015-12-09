using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using football_api;

namespace ScoreService.Controllers
{
    //[RoutePrefix("api/score")]
    public class ScoreController : ApiController
    {
        [HttpGet]
        //[Route("tournament")]
        public async Task<HttpResponseMessage> GetTounaments()
        {
            var tournament =await ScoreProvider.Instance.GetTournaments();
            return Request.CreateResponse<CompetitionInfo>(HttpStatusCode.OK, tournament);
        }

        [HttpGet]
        //[Route("api/score/getstandings/{competetionid}")]
        public async Task<HttpResponseMessage> GetTable(int id)
        {
            var table = await ScoreProvider.Instance.GetStandings(id);
            return Request.CreateResponse<TeamsInfo>(HttpStatusCode.OK, table);
        }

        [HttpGet]
        [Route("api/score/getfixtures/{querystring}")]
        public async Task<MatchInfo> GetFixtures(string querystring)
        {
            var values = querystring.Split('&');
            return await ScoreProvider.Instance.GetFixtures(values[0], values[1]);
        }
        
    }
}

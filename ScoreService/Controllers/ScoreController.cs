using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AllScores.Common.Data.Base;
using AllScores.Common.Data.Football;
using AllScores.Common.Exceptions;
using football_api;

namespace ScoreService.Controllers
{
    //[RoutePrefix("api/score")]
    public class ScoreController : ApiController
    {

        [HttpGet]
        //[Route("tournament")]
        //http://localhost:63823/api/score/gettounament
        public async Task<HttpResponseMessage> GetTounaments()
        {
            try
            {
                var tournament =await ScoreProvider.Instance.GetCompetetions();
                return Request.CreateResponse<CompetitionInfo>(HttpStatusCode.OK, tournament);
            }
            catch (UnauthorizedAPIAccessException uex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, uex);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
        }

        [HttpGet]
        //[Route("api/score/getstandings/{competetionid}")]
        //http://localhost:63823/api/score/gettable/1204
        public async Task<HttpResponseMessage> GetTable(int param)
        {
            try
            {
                var table = await ScoreProvider.Instance.GetStandingsAsync(param);
                return Request.CreateResponse<Standings>(HttpStatusCode.OK, table);
            }
            catch (UnauthorizedAPIAccessException uex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, uex);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        //http://localhost:63823/api/score/getfixtures?competitionid=1204&date=13.12.2015
        // TODO 
        public async Task<HttpResponseMessage> GetFixtures(string competitionid,string date)
        {
            try
            {
                var fixtures = await ScoreProvider.Instance.GetFixturesAsync(competitionid, date);
                return Request.CreateResponse<Fixtures>(fixtures);
            }
            catch (UnauthorizedAPIAccessException uex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, uex);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }        
    }
}

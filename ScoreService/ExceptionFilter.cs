using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using AllScores.Common.Exceptions;

namespace ScoreService
{
    class ExceptionFilter:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);
            HttpResponseMessage response;
            var exception =actionExecutedContext.Exception;
            if (exception is HttpRequestException)
            {
                response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.RequestTimeout, "Network not available");
            }
            else if (exception is UnauthorizedAPIAccessException)
            {
                response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, exception);
            }
            else
            {
                response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, exception);
            }
            actionExecutedContext.Response = response;
        } 
    }
}

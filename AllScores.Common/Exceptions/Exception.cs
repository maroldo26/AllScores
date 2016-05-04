using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace AllScores.Common.Exceptions
{
    public class UnauthorizedAPIAccessException:Exception
    {
        public UnauthorizedAPIAccessException(string message):base(message)
        {

        }
    }

    public class ScoreProviderNotInitializedException:Exception
    {
        public ScoreProviderNotInitializedException(string message):base(message)
        {

        }
    }

    public class APIAcessException:Exception
    {
       public APIAcessException(string message):base(message)
        {

        }

       public HttpStatusCode StatusCode { get; set; }
    }

}

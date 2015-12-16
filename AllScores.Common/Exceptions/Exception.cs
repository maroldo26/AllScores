using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}

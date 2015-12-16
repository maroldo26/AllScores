using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllScores.Common.Data.Base;

namespace AllScores.Common
{
    public interface IScoreProvider
    {
        Fixtures GetFixturesAsync(string competitionid, string date);

        Fixtures GetFixturesAsync(string competitionid, string fromdate, string enddate);

        void GetScore(string matchid);
    }
}

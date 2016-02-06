using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllScores.Common.Data.Base;

namespace AllScores.Common.Data.Football
{
    public class Standing : APIModel
    {
        public FootballTeam Team { get; set; }
        public string Position { get; set; }
        public string Points { get; set; }
        public string Form { get; set; }
        public string GoalsAgainst { get; set; }
        public string GoalsFor { get; set; }
        public string GamesPlayed { get; set; }
        public string GoalDifference { get; set; }
    }

    public class Standings : List<Standing>
    {
    }
}

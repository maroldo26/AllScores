using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllScores.Common.Data.Base
{
    public class Tournament : APIModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public TournamentType Type { get; set; }
        public Sport Sport { get; set; }
        public string Id { get; set; }
    }
}

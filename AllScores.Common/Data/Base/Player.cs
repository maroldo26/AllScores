using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllScores.Common.Data.Base
{
    public class Player : APIModel
    {
        public string Name
        {
            get;
            set;
        }

        public string Nationality
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public int Weight
        {
            get;
            set;
        }
    }
}

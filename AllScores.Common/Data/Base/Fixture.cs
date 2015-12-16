using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllScores.Common.Data.Base
{
    /// <summary>
    /// Reresents a Fixture in any sport.
    /// </summary>
    public class Fixture
    {
        /// <summary>
        /// Gets or sets the away team.
        /// </summary>
        /// <value>
        /// The away team.
        /// </value>
        public Team AwayTeam
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the home team.
        /// </summary>
        /// <value>
        /// The home team.
        /// </value>
        public Team HomeTeam
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the venue.
        /// </summary>
        /// <value>
        /// The venue.
        /// </value>
        public int Venue
        {
            get;
            set;
        }

        //public int Date
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Gets or sets the type of the sport.
        /// </summary>
        /// <value>
        /// The type of the sport.
        /// </value>
        public SportType SportType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        public string Score { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public string Date { get; set; }

    }

    /// <summary>
    /// Contains a set of Fixtures
    /// </summary>
    /// <seealso cref="System.Collections.Generic.List{AllScores.Common.Data.Base.Fixture}" />
    public class Fixtures : List<Fixture>
    {
        
    }
}

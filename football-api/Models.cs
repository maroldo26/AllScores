using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace football_api
{
    public class Competition
    {
        public string id { get; set; }
        public string name { get; set; }
        public string region { get; set; }
    }

    public class BaseInfo
    {
        public int APIVersion { get; set; }
        public int APIRequestsRemaining { get; set; }
        public string DeveloperAuthentication { get; set; }
        public string Action { get; set; }
        public Params Params { get; set; }
        public double ComputationTime { get; set; }
        public string IP { get; set; }
        public string ERROR { get; set; }
        public string ServerName { get; set; }
        public string ServerAddress { get; set; }
    }

    public class CompetitionInfo : List<Competition>
    {              
    }

    public class Team
    {
        public string comp_id { get; set; }
        public string season { get; set; }
        public string round { get; set; }
        public string stage_id { get; set; }
        public object comp_group { get; set; }
        public string country { get; set; }
        public string team_id { get; set; }
        public string team_name { get; set; }
        public string status { get; set; }
        public string recent_form { get; set; }
        public string position { get; set; }
        public string overall_gp { get; set; }
        public string overall_w { get; set; }
        public string overall_d { get; set; }
        public string overall_l { get; set; }
        public string overall_gs { get; set; }
        public string overall_ga { get; set; }
        public string home_gp { get; set; }
        public string home_w { get; set; }
        public string home_d { get; set; }
        public string home_l { get; set; }
        public string home_gs { get; set; }
        public string home_ga { get; set; }
        public string away_gp { get; set; }
        public string away_w { get; set; }
        public string away_d { get; set; }
        public string away_l { get; set; }
        public string away_gs { get; set; }
        public string away_ga { get; set; }
        public string gd { get; set; }
        public string points { get; set; }
        public string description { get; set; }
    }

    public class TeamsInfo : List<Team>
    {        
    }


    public class MatchEvent
    {
        public string id { get; set; }
        public string type { get; set; }
        public string minute { get; set; }
        public string extra_min { get; set; }
        public string team { get; set; }
        public string player { get; set; }
        public string player_id { get; set; }
        public string assist { get; set; }
        public string assist_id { get; set; }
        public string result { get; set; }
    }

    public class Match
    {
        public string id { get; set; }
        public string comp_id { get; set; }
        public string formatted_date { get; set; }
        public string season { get; set; }
        public string week { get; set; }
        public string venue { get; set; }
        public string venue_id { get; set; }
        public string venue_city { get; set; }
        public string status { get; set; }
        public string timer { get; set; }
        public string time { get; set; }
        public string localteam_id { get; set; }
        public string localteam_name { get; set; }
        public string localteam_score { get; set; }
        public string visitorteam_id { get; set; }
        public string visitorteam_name { get; set; }
        public string visitorteam_score { get; set; }
        public string ht_score { get; set; }
        public string ft_score { get; set; }
        public object et_score { get; set; }
        public object penalty_local { get; set; }
        public object penalty_visitor { get; set; }
        public List<MatchEvent> events { get; set; }
    }

    public class Params
    {
        public string Action { get; set; }
        public string APIKey { get; set; }
        public string comp_id { get; set; }
        public string match_date { get; set; }
    }

    public class MatchInfo : List<Match>
    {
    }

}

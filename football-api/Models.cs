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

    public class CompetitionInfo : BaseInfo
    {        
        public List<Competition> Competition { get; set; }        
    }

    public class Team
    {
        public string stand_id { get; set; }
        public string stand_competition_id { get; set; }
        public string stand_season { get; set; }
        public string stand_round { get; set; }
        public string stand_stage_id { get; set; }
        public string stand_group { get; set; }
        public string stand_country { get; set; }
        public string stand_team_id { get; set; }
        public string stand_team_name { get; set; }
        public string stand_status { get; set; }
        public string stand_recent_form { get; set; }
        public string stand_position { get; set; }
        public string stand_overall_gp { get; set; }
        public string stand_overall_w { get; set; }
        public string stand_overall_d { get; set; }
        public string stand_overall_l { get; set; }
        public string stand_overall_gs { get; set; }
        public string stand_overall_ga { get; set; }
        public string stand_home_gp { get; set; }
        public string stand_home_w { get; set; }
        public string stand_home_d { get; set; }
        public string stand_home_l { get; set; }
        public string stand_home_gs { get; set; }
        public string stand_home_ga { get; set; }
        public string stand_away_gp { get; set; }
        public string stand_away_w { get; set; }
        public string stand_away_d { get; set; }
        public string stand_away_l { get; set; }
        public string stand_away_gs { get; set; }
        public string stand_away_ga { get; set; }
        public string stand_gd { get; set; }
        public string stand_points { get; set; }
        public string stand_desc { get; set; }
    }

    public class TeamsInfo : BaseInfo
    {        
        public List<Team> teams { get; set; }
    }


    public class MatchEvent
    {
        public string event_id { get; set; }
        public string event_match_id { get; set; }
        public string event_type { get; set; }
        public string event_minute { get; set; }
        public string event_team { get; set; }
        public string event_player { get; set; }
        public string event_player_id { get; set; }
        public string event_result { get; set; }
    }

    public class Match
    {
        public string match_id { get; set; }
        public string match_static_id { get; set; }
        public string match_comp_id { get; set; }
        public string match_date { get; set; }
        public string match_formatted_date { get; set; }
        public string match_season_beta { get; set; }
        public string match_week_beta { get; set; }
        public string match_venue_beta { get; set; }
        public string match_venue_id_beta { get; set; }
        public string match_venue_city_beta { get; set; }
        public string match_status { get; set; }
        public string match_timer { get; set; }
        public string match_time { get; set; }
        public string match_commentary_available { get; set; }
        public string match_localteam_id { get; set; }
        public string match_localteam_name { get; set; }
        public string match_localteam_score { get; set; }
        public string match_visitorteam_id { get; set; }
        public string match_visitorteam_name { get; set; }
        public string match_visitorteam_score { get; set; }
        public string match_ht_score { get; set; }
        public string match_ft_score { get; set; }
        public string match_et_score { get; set; }
        public List<MatchEvent> match_events { get; set; }
    }

    public class Params
    {
        public string Action { get; set; }
        public string APIKey { get; set; }
        public string comp_id { get; set; }
        public string match_date { get; set; }
    }

    public class MatchInfo : BaseInfo
    {
        public List<Match> matches { get; set; }
    }

}

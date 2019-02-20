using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats
{

    public class RootObject1
    {
        public Player[] Players { get; set; }
    }

    public class Player1
    {
        public int assists { get; set; }
        public int big_chances_created { get; set; }
        public int blocks { get; set; }
        public int? chance_of_playing_next_round { get; set; }
        public int? chance_of_playing_this_round { get; set; }
        public int clean_sheets { get; set; }
        public int clearances { get; set; }
        public int code { get; set; }
        public int cost_change_event { get; set; }
        public int cost_change_event_fall { get; set; }
        public int cost_change_start { get; set; }
        public int cost_change_start_fall { get; set; }
        public int crosses { get; set; }
        public int dreamteam_count { get; set; }
        public int element_type { get; set; }
        public string ep_next { get; set; }
        public string ep_this { get; set; }
        public int errors_leading_to_goal { get; set; }
        public int event_points { get; set; }
        public string first_name { get; set; }
        public string form { get; set; }
        public int goals_conceded { get; set; }
        public int goals_scored { get; set; }
        public int id { get; set; }
        public bool in_dreamteam { get; set; }
        public int interceptions { get; set; }
        public int key_passes { get; set; }
        public int loaned_in { get; set; }
        public int loaned_out { get; set; }
        public int loans_in { get; set; }
        public int loans_out { get; set; }
        public int minutes { get; set; }
        public string news { get; set; }
        public int now_cost { get; set; }
        public int own_goal_earned { get; set; }
        public int own_goals { get; set; }
        public int pass_completion { get; set; }
        public int penalties_conceded { get; set; }
        public int penalties_earned { get; set; }
        public int penalties_missed { get; set; }
        public int penalties_saved { get; set; }
        public string photo { get; set; }
        public string points_per_game { get; set; }
        public string position { get; set; }
        public int recoveries { get; set; }
        public int red_cards { get; set; }
        public int saves { get; set; }
        public string second_name { get; set; }
        public string selected_by_percent { get; set; }
        public int shots { get; set; }
        public bool special { get; set; }
        public string status { get; set; }
        public int tackles { get; set; }
        public int team { get; set; }
        public string team_name { get; set; }
        public int total_points { get; set; }
        public int transfers_in { get; set; }
        public int transfers_in_event { get; set; }
        public int transfers_out { get; set; }
        public int transfers_out_event { get; set; }
        public string value_form { get; set; }
        public string value_season { get; set; }
        public int was_fouled { get; set; }
        public string web_name { get; set; }
        public int yellow_cards { get; set; }
    }
}

using System;
namespace cnfWebApi.Models
{
    public class ServingSize
    {
        public int conv_factor_c { get; set; }
        public int food_c { get; set; }
        public int conv_factor { get; set; }
        public int seq_web { get; set; }
	    public string flag_cfg { get; set; }
	    public int no_serving { get; set; }
	    public string food_desc { get; set; }
	    public string food_desc_f { get; set; }
	    public int canada_food_subgroup_id { get; set; }
	    public string measure_desc { get; set; }
	    public string measure_desc_f { get; set; }
	    public string measure_type { get; set; }
	    public string canada_food_group_desc_e { get; set; }
	    public string canada_food_group_desc_f { get; set; }
	    public int canada_food_subgroup_code { get; set; }
	    public string canada_food_subgroup_desc_e { get; set; }
	    public string canada_food_subgroup_desc_f { get; set; }
    }
}
using System;
namespace cnfWebApi.Models
{
    public class NutrientAmount
    {
        public int food_c { get; set; }
        public int nutr_value { get; set; }
        public int std_error { get; set; }
        public int num_obser { get; set; }
	    public int nutr_c { get; set; }
	    public string nutr_web_name_e { get; set; }
	    public string nutr_web_name_f { get; set; }
	    public string unit { get; set; }
	    public int nutr_decimal_place { get; set; }
	    public int nutr_web_order { get; set; }
	    public int nutrient_group_order { get; set; }
	    public int source_c { get; set; }
	    public int nrd_ref { get; set; }
	    public string source_desc { get; set; }
	    public string source_desc_f { get; set; }
    }
}
using System;
namespace cnfWebApi.Models
{
    public class NutrientAmount
    {
        public int food_code { get; set; }
        public double nutrient_value { get; set; }
        public int standard_error { get; set; }
        public int number_observation { get; set; }
	    public int nutrient_name_id { get; set; }
	    public string nutrient_web_name { get; set; }
        public int nutrient_source_id { get; set; }

        //public string nutr_web_name_f { get; set; }
        //20180503 Removed to reduce size of data returned. public string unit { get; set; }
        //20180503 Removed to reduce size of data returned. public int nutrient_decimals { get; set; }
        //20180503 Removed to reduce size of data returned. public int nutrient_web_order { get; set; }

        //20180503 Removed to reduce size of data returned. public int nutrient_source_code { get; set; }
        //20180503 Removed to reduce size of data returned. public string nutrient_source_description { get; set; }
        //public string source_desc_f { get; set; }
    }
}
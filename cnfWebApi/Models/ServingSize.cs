using System;
namespace cnfWebApi.Models
{
    public class ServingSize
    {
        public double conversion_factor_value { get; set; }
        public int food_code { get; set; }
        public string food_description { get; set; }
        public string measure_name { get; set; }
        // 20180501 measure_type is not being displayed to reduce data set size.
        //public string measure_type { get; set; }
    }
}
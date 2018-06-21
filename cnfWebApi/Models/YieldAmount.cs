using System;
namespace cnfWebApi.Models
{
    public class YieldAmount
    {
        public double yield_amount { get; set; }
        public int food_code { get; set; }
        public string food_description { get; set; }
        public string yield_name { get; set; }
        // 20180501 measure_type is not being displayed to reduce data set size.
        //public string measure_type { get; set; }
    }
}
using System;
namespace cnfWebApi.Models
{
    public class RefuseAmount
    {
        public double refuse_amount { get; set; }
        public int food_code { get; set; }
        public string food_description { get; set; }
        public string refuse_name { get; set; } //TODO Change to refuse_amount Barry 20180430
        // 20180501 measure_type is not being displayed to reduce data set size.
        //public string measure_type { get; set; }
    }
}
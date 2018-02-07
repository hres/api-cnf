using System;
namespace cnfWebApi.Models
{
    public class RefuseAmount
    {
        public double conv_factor { get; set; }
        public int food_c { get; set; }
        public string food_desc { get; set; }
        public string measure_desc { get; set; }
        public string measure_type { get; set; }
    }
}
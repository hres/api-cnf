using System;
namespace cnfWebApi.Models
{
    public class ReportCfg
    {
        public int food_c { get; set; }
        public string food_desc { get; set; }
        public string food_desc_f { get; set; }
        public int conv_factor_c { get; set; }
        public int conv_factor { get; set; }
        public int seq_web { get; set; }
        public string flag_cfg { get; set; }
        public string flag_reference_amount { get; set; }
        public int no_serving { get; set; }
        public string measure_desc { get; set; }
        public string measure_desc_f { get; set; }
        public string measure_type { get; set; }
        public string group_c { get; set; }
    }
}
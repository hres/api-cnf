using System;
namespace cnfWebApi.Models
{
    public class NutrientName
    {
        public int nutr_c { get; set; }
        public string nutr_symbol { get; set; }
        public string nutr_name { get; set; }
        public string unit { get; set; }
        public int sequence_c { get; set; }
        public string nutr_name_f { get; set; }
        public int nutr_code { get; set; }
        public int nutr_web { get; set; }
        public string tagname { get; set; }
        public int nutr_active_flag { get; set; }
        public int nutr_decimal_place { get; set; }
        public int nutr_web_order { get; set; }
        public string nutr_web_name_e { get; set; }
        public string nutr_web_name_f { get; set; }
        public int nutrient_group_id { get; set; }
    }
}
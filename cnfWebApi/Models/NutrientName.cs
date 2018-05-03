using System;
namespace cnfWebApi.Models
{
    public class NutrientName
    {
        public int nutrient_name_id { get; set; }
        public string nutrient_symbol { get; set; }
        public string nutrient_name { get; set; }
        public string unit { get; set; }
        public int nutrient_code { get; set; }
        public string tagname { get; set; }
        public int nutrient_decimals { get; set; }
        public int nutrient_web_order { get; set; }
        public string nutrient_web_name { get; set; }
        public int nutrient_group_id { get; set; }
    }
}
using System;
namespace cnfWebApi.Models
{
    public class NutrientGroup
    {
        public int nutrient_group_id { get; set; }
        public string nutrient_group_name { get; set; }
        public int nutrient_group_order { get; set; }
    }
}
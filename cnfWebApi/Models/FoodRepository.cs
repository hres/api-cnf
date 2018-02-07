using cnf;
using System.Collections.Generic;

namespace cnfWebApi.Models
{
    public class FoodRepository : IFoodRepository
    {
        private List<Food> foods = new List<Food>();
        private Food food = new Food();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Food> Get(int id, string lang = "")
        {
            foods = dbConnection.GetFoodById(id, lang);
            return foods;
        }

        public IEnumerable<Food> GetAll(string lang="")
        {
            foods = dbConnection.GetAllFood(lang);
            return foods;
        }
    }
}
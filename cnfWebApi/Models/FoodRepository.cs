using cnf;
using System.Collections.Generic;

namespace cnfWebApi.Models
{
    public class FoodRepository : IFoodRepository
    {
        private List<Food> foods = new List<Food>();
        private Food food = new Food();
        DBConnection dbConnection = new DBConnection("en");
        public Food Get(int id, string lang = "")
        {
            food = dbConnection.GetFoodById(id, lang);
            return food;
        }

            public IEnumerable<Food> GetAll(string lang="")
        {
            foods = dbConnection.GetAllFood(lang);

            return foods;
        }
    }
}
using cnf;
using System.Collections.Generic;

namespace cnfWebApi.Models
{
    public class FoodGroupRepository : IFoodGroupRepository
    {
        private List<FoodGroup> foodGroups = new List<FoodGroup>();
        private FoodGroup foodGroup = new FoodGroup();
        DBConnection dbConnection = new DBConnection("en");
        public FoodGroup Get(int id, string lang = "")
        {
            foodGroup = dbConnection.GetFoodGroupById(id, lang);
            return foodGroup;
        }

            public IEnumerable<FoodGroup> GetAll(string lang="")
        {
                foodGroups = dbConnection.GetAllFoodGroup(lang);

            return foodGroups;
        }
    }
}
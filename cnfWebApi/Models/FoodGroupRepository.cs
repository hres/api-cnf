using cnf;
using System.Collections.Generic;

namespace cnfWebApi.Models
{
    public class FoodGroupRepository : IFoodGroupRepository
    {
        // We are using the list and _fakeDatabaseID to represent what would
        // most likely be a database of some sort, with an auto-incrementing ID field:
        private List<FoodGroup> foodGroups = new List<FoodGroup>();
        private FoodGroup foodGroup = new FoodGroup();
        DBConnection dbConnection = new DBConnection("en");
    public FoodGroup Get(int id, string lang = "")
    {
        foodGroup = dbConnection.GetFoodGroupById(id, lang);
        return foodGroup;
    }

        public IEnumerable<FoodGroup> GetAll(string lang="", string foodname = "")
    {
            foodGroups = dbConnection.GetAllFoodGroup(lang, foodname);

        return foodGroups;
    }
    }
}
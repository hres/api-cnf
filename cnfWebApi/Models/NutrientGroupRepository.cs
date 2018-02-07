using cnf;
using System.Collections.Generic;

namespace cnfWebApi.Models
{
    public class NutrientGroupRepository : INutrientGroupRepository
    {
        private List<NutrientGroup> nutrientGroups = new List<NutrientGroup>();
        //private NutrientGroup nutrientGroup        = new NutrientGroup();
        DBConnection dbConnection                  = new DBConnection("en");

        public IEnumerable<NutrientGroup> Get(int id, string lang = "")
        {
            nutrientGroups = dbConnection.GetNutrientGroupById(id, lang);
            return nutrientGroups;
        }

         public IEnumerable<NutrientGroup> GetAll(string lang="")
        {
                nutrientGroups = dbConnection.GetAllNutrientGroup(lang);

            return nutrientGroups;
        }
    }
}
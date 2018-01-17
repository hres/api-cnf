using cnf;
using System.Collections.Generic;

namespace cnfWebApi.Models
{
    public class NutrientNameRepository : INutrientNameRepository
    {
        private List<NutrientName> nutrientNames = new List<NutrientName>();
        private NutrientName nutrientName = new NutrientName();
        DBConnection dbConnection = new DBConnection("en");
        public NutrientName Get(int id, string lang = "")
        {
            nutrientName = dbConnection.GetNutrientNameById(id, lang);
            return nutrientName;
        }

            public IEnumerable<NutrientName> GetAll(string lang="")
        {
            nutrientNames = dbConnection.GetAllNutrientName(lang);

            return nutrientNames;
        }
    }
}
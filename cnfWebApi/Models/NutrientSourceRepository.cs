using cnf;
using System.Collections.Generic;

namespace cnfWebApi.Models
{
    public class NutrientSourceRepository : INutrientSourceRepository
    {
        private List<NutrientSource> nutrientSources = new List<NutrientSource>();
        private NutrientSource nutrientSource = new NutrientSource();
        DBConnection dbConnection = new DBConnection("en");
        public NutrientSource Get(int id, string lang = "")
        {
            nutrientSource = dbConnection.GetNutrientSourceById(id, lang);
            return nutrientSource;
        }

            public IEnumerable<NutrientSource> GetAll(string lang="")
        {
            nutrientSources = dbConnection.GetAllNutrientSource(lang);

            return nutrientSources;
        }
    }
}
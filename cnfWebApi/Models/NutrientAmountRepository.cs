using cnf;
using System.Collections.Generic;

namespace cnfWebApi.Models
{
    public class NutrientAmountRepository : INutrientAmountRepository
    {
        private List<NutrientAmount> nutrientAmounts = new List<NutrientAmount>();
        private NutrientAmount nutrientAmount = new NutrientAmount();
        DBConnection dbConnection = new DBConnection("en");
        public NutrientAmount Get(int id, string lang = "")
        {
            nutrientAmount = dbConnection.GetNutrientAmountById(id, lang);
            return nutrientAmount;
        }

            public IEnumerable<NutrientAmount> GetAll(string lang="")
        {
            nutrientAmounts = dbConnection.GetAllNutrientAmount(lang);

            return nutrientAmounts;
        }
    }
}
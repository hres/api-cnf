using System.Collections.Generic;

namespace cnfWebApi.Models
{
    interface INutrientAmountRepository
    {
        IEnumerable<NutrientAmount> GetAll(string lang="");

        NutrientAmount Get(int id, string lang = "");
    }
}

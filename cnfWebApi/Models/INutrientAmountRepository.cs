using System.Collections.Generic;

namespace cnfWebApi.Models
{
    interface INutrientAmountRepository
    {
        IEnumerable<NutrientAmount> GetAll(string lang="");

        IEnumerable<NutrientAmount> Get(int id, string lang = "");
    }
}

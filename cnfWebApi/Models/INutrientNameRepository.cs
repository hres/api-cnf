using System.Collections.Generic;

namespace cnfWebApi.Models
{
    interface INutrientNameRepository
    {
        IEnumerable<NutrientName> GetAll(string lang="");

        NutrientName Get(int id, string lang = "");
    }
}

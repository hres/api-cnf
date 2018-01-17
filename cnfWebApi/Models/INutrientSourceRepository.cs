using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnfWebApi.Models
{
    interface INutrientSourceRepository
    {
        IEnumerable<NutrientSource> GetAll(string lang="");

        NutrientSource Get(int id, string lang = "");
    }
}

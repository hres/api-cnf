using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnfWebApi.Models
{
    interface INutrientGroupRepository
    {
        IEnumerable<NutrientGroup> GetAll(string lang="");

        NutrientGroup Get(int id, string lang = "");
    }
}

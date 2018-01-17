using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnfWebApi.Models
{
    interface IFoodGroupRepository
    {
        IEnumerable<FoodGroup> GetAll(string lang="");

        FoodGroup Get(int id, string lang = "");
    }
}

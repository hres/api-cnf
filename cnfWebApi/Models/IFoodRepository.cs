using System.Collections.Generic;

namespace cnfWebApi.Models
{
    interface IFoodRepository
    {
        IEnumerable<Food> GetAll(string lang="");

        IEnumerable<Food> Get(int id, string lang = "");
    }
}

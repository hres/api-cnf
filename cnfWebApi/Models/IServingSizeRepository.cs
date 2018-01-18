using System.Collections.Generic;

namespace cnfWebApi.Models
{
    interface IServingSizeRepository
    {
        IEnumerable<ServingSize> GetAll(string lang="");

        ServingSize Get(int id, string lang = "");
    }
}

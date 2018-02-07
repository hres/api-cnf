using System.Collections.Generic;

namespace cnfWebApi.Models
{
    interface IServingSizeRepository
    {
        IEnumerable<ServingSize> GetAll(string lang="");

        IEnumerable<ServingSize> Get(int id, string lang = "");
    }
}

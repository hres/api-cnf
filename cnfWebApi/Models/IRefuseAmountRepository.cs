using System.Collections.Generic;

namespace cnfWebApi.Models
{
    interface IRefuseAmountRepository
    {
        IEnumerable<RefuseAmount> GetAll(string lang="");

        //RefuseAmount Get(int id, string lang = "");
        IEnumerable<RefuseAmount> Get(int id, string lang = "");
    }
}

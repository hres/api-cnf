using System.Collections.Generic;

namespace cnfWebApi.Models
{
    interface IYieldAmountRepository
    {
        IEnumerable<YieldAmount> GetAll(string lang="");

        IEnumerable<YieldAmount> Get(int id, string lang = "");
    }
}

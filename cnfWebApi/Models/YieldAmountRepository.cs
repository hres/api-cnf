using cnf;
using System.Collections.Generic;

namespace cnfWebApi.Models
{
    public class YieldAmountRepository : IYieldAmountRepository
    {
        private List<YieldAmount> yieldAmounts = new List<YieldAmount>();
        private YieldAmount yieldAmount        = new YieldAmount();
        DBConnection dbConnection              = new DBConnection("en");

        public IEnumerable<YieldAmount> Get(int id, string lang = "")
        {
            yieldAmounts = dbConnection.GetYieldAmountById(id, lang);
            return yieldAmounts;
        }

            public IEnumerable<YieldAmount> GetAll(string lang="")
        {
            yieldAmounts = dbConnection.GetAllYieldAmount(lang);

            return yieldAmounts;
        }
    }
}
using cnf;
using System.Collections.Generic;

namespace cnfWebApi.Models
{
    public class RefuseAmountRepository : IRefuseAmountRepository
    {
        private List<RefuseAmount> refuseAmounts = new List<RefuseAmount>();
        private RefuseAmount refuseAmount        = new RefuseAmount();
        DBConnection dbConnection                = new DBConnection("en");

        public IEnumerable<RefuseAmount> Get(int id, string lang = "")
        {
            refuseAmounts = dbConnection.GetRefuseAmountById(id, lang);
            return refuseAmounts;
        }

        public IEnumerable<RefuseAmount> GetAll(string lang="")
        {
            refuseAmounts = dbConnection.GetAllRefuseAmount(lang);

            return refuseAmounts;
        }
    }
}
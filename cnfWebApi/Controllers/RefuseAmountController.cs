using cnfWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace cnfWebApi.Controllers
{
    public class RefuseAmountController : ApiController
    {
        static readonly IRefuseAmountRepository databasePlaceholder = new RefuseAmountRepository();

        public IEnumerable<RefuseAmount> GetAllRefuseAmount(string lang="en")
        {

            return databasePlaceholder.GetAll(lang);
        }

        public IEnumerable<RefuseAmount> GetRefuseAmountById(int id, string lang="en")
        {
            return databasePlaceholder.Get(id, lang);
            //RefuseAmount refuseAmount = databasePlaceholder.Get(id, lang);
            //if (refuseAmount == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            // return refuseAmount;


        }
    }
}

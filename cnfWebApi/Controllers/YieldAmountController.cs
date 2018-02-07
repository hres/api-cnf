using cnfWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace cnfWebApi.Controllers
{
    public class YieldAmountController : ApiController
    {
        static readonly IYieldAmountRepository databasePlaceholder = new YieldAmountRepository();

        public IEnumerable<YieldAmount> GetAllYieldAmount(string lang="")
        {

            return databasePlaceholder.GetAll(lang);
        }

        public IEnumerable<YieldAmount> GetYieldAmountById(int id, string lang = "")
        {
            return databasePlaceholder.Get(id, lang);

            //OriginalCode YieldAmount yieldAmount = databasePlaceholder.Get(id, lang);
            //OriginalCodeif (yieldAmount == null)
            //{OriginalCode
            //OriginalCode   throw new HttpResponseException(HttpStatusCode.NotFound);
        }
        //OriginalCodereturn yieldAmount;


    }
}

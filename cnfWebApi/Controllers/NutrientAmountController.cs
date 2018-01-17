using cnfWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace cnfWebApi.Controllers
{
    public class NutrientAmountController : ApiController
    {
        static readonly INutrientAmountRepository databasePlaceholder = new INutrientAmountRepository();

        public IEnumerable<NutrientAmount> GetAllNutrientAmount(string lang="")
        {

            return databasePlaceholder.GetAll(lang);
        }
        
        public NutrientAmount GetNutrientAmountById(int id, string lang = "")
        {
            NutrientAmount nutrientAmount = databasePlaceholder.Get(id, lang);
            if (nutrientAmount == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return nutrientAmount;
            

        }
    }
}

using cnfWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace cnfWebApi.Controllers
{
    public class NutrientNameController : ApiController
    {
        static readonly INutrientNameRepository databasePlaceholder = new NutrientNameRepository();

        public IEnumerable<NutrientName> GetAllNutrientName(string lang="en")
        {

            return databasePlaceholder.GetAll(lang);
        }
        
        public NutrientName GetNutrNameById(int id, string lang = "en")
        {
            NutrientName nutrientName = databasePlaceholder.Get(id, lang);
            if (nutrientName == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return nutrientName;
            

        }
    }
}

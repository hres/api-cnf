using cnfWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace cnfWebApi.Controllers
{
    public class NutrientSourceController : ApiController
    {
        static readonly INutrientSourceRepository databasePlaceholder = new NutrientSourceRepository();

        public IEnumerable<NutrientSource> GetAllNutrientSource(string lang="en")
        {

            return databasePlaceholder.GetAll(lang);
        }
        
        public NutrientSource GetNutrSourceById(int id, string lang = "en")
        {
            NutrientSource nutrientSource = databasePlaceholder.Get(id, lang);
            if (nutrientSource == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return nutrientSource;
            

        }
    }
}

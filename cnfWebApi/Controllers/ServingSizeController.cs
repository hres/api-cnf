using cnfWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace cnfWebApi.Controllers
{
    public class ServingSizeController : ApiController
    {
        static readonly IServingSizeRepository databasePlaceholder = new ServingSizeRepository();

        public IEnumerable<ServingSize> GetAllServingSize(string lang="")
        {

            return databasePlaceholder.GetAll(lang);
        }
        
        public ServingSize GetServingSizeById(int id, string lang = "")
        {
            ServingSize servingSize = databasePlaceholder.Get(id, lang);
            if (servingSize == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return servingSize;
            

        }
    }
}

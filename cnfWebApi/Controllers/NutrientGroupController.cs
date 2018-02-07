using cnfWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace cnfWebApi.Controllers
{
    public class NutrientGroupController : ApiController
    {
        static readonly INutrientGroupRepository databasePlaceholder = new NutrientGroupRepository();

        public IEnumerable<NutrientGroup> GetAllNutrientGroup(string lang="")
        {

            return databasePlaceholder.GetAll(lang);
        }
        
        public IEnumerable<NutrientGroup> GetNutrientGroupById(int id, string lang = "")
        {
            return databasePlaceholder.Get(id, lang);
            //NutrientGroup nutrientGroup = databasePlaceholder.Get(id, lang);
            //if (nutrientGroup == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            //return nutrientGroup;
        }
    }
}

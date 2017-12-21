using cnfWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace cnfWebApi.Controllers
{
    public class FoodGroupController : ApiController
    {
        static readonly IFoodGroupRepository databasePlaceholder = new FoodGroupRepository();

        public IEnumerable<FoodGroup> GetAllFoodGroup(string lang="", string foodname = "")
        {

            return databasePlaceholder.GetAll(lang, foodname);
        }
        
        public FoodGroup GetFoodGroupById(int id, string lang = "")
        {
            FoodGroup foodGroup = databasePlaceholder.Get(id, lang);
            if (foodGroup == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return foodGroup;
            

        }
    }
}

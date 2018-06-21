using cnfWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace cnfWebApi.Controllers
{
    public class FoodController : ApiController
    {
        static readonly IFoodRepository databasePlaceholder = new FoodRepository();

        public IEnumerable<Food> GetAllFood(string lang="en")
        {

            return databasePlaceholder.GetAll(lang);
        }
        
        public IEnumerable<Food> GetFoodById(int id, string lang = "en")
        {
            return databasePlaceholder.Get(id, lang);
            // Food food = databasePlaceholder.Get(id, lang);
            // if (food == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            //return food;
        }
    }
}

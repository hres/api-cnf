using cnf;
using System.Collections.Generic;

namespace cnfWebApi.Models
{
    public class ServingSizeRepository : IServingSizeRepository
    {
        private List<ServingSize> servingSizes = new List<ServingSize>();
        private ServingSize servingSize = new ServingSize();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<ServingSize> Get(int id, string lang = "")
        {
            servingSizes = dbConnection.GetServingSizeById(id, lang);
            return servingSizes;
        }

        public IEnumerable<ServingSize> GetAll(string lang="")
        {
                servingSizes = dbConnection.GetAllServingSize(lang);

            return servingSizes;
        }
    }
}
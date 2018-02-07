using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using cnf;

namespace cnfWebApi.Controllers
{
    public class CSVController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage DownloadCSV(string dataType, string lang)
        {
            DBConnection dbConnection = new DBConnection(lang);
            var jsonResult = string.Empty;
            var fileNameDate = string.Format("{0}{1}{2}",
                           DateTime.Now.Year.ToString(),
                           DateTime.Now.Month.ToString().PadLeft(2, '0'),
                           DateTime.Now.Day.ToString().PadLeft(2, '0'));
            var fileName = string.Format(dataType + "_{0}.csv", fileNameDate);
            byte[] outputBuffer = null;
            string resultString = string.Empty;
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);

            var json = string.Empty;

            switch (dataType)
            {
                case "food":
                    var food = dbConnection.GetAllFood(lang).ToList();
                    if (food.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(food);
                    }
                    break;
                case "nutrientamount":
                    var nutrientamount = dbConnection.GetAllNutrientAmount(lang).ToList();
                    if (nutrientamount.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(nutrientamount);
                    }
                    break;
                case "nutrientgroup":
                    var nutrientgroup = dbConnection.GetAllNutrientGroup(lang).ToList();
                    if (nutrientgroup.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(nutrientgroup);
                    }
                    break;
                case "nutrientname":
                    var nutrientname = dbConnection.GetAllNutrientName(lang).ToList();
                    if (nutrientname.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(nutrientname);
                    }
                    break;
                case "nutrientsource":
                    var nutrientsource = dbConnection.GetAllNutrientSource(lang).ToList();
                    if (nutrientsource.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(nutrientsource);
                    }
                    break;
                case "refuseamount":
                    var refuseamount = dbConnection.GetAllRefuseAmount(lang).ToList();
                    if (refuseamount.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(refuseamount);
                    }
                    break;
                case "servingsize":
                    var servingsize = dbConnection.GetAllServingSize(lang).ToList();
                    if (servingsize.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(servingsize);
                    }
                    break;
                case "yieldamount":
                    var yieldamount = dbConnection.GetAllYieldAmount(lang).ToList();
                    if (yieldamount.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(yieldamount);
                    }
                    break;
                    //case "foodGroup":
                    //    var foodGroup = dbConnection.GetAllFoodGroup(lang).ToList();
                    //    if (foodGroup.Count > 0)
                    //    {
                    //        json = JsonConvert.SerializeObject(foodGroup);
                    //    }
                    //    break;
            }

            if (!string.IsNullOrWhiteSpace(json))
            {
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);
                if (dt.Rows.Count > 0)
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            UtilityHelper.WriteDataTable(dt, writer, true);
                            outputBuffer = stream.ToArray();
                            resultString = Encoding.UTF8.GetString(outputBuffer, 0, outputBuffer.Length);
                        }
                    }
                    result.Content = new StringContent(resultString);
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
                    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = fileName };
                }
            }

            return result;
        }
    }
}

using Newtonsoft.Json;
using StockProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.DAL
{
    public class StockAPIDAL
    {
        const string LOADAL_URL = "https://localhost:44368/api/books";
        public static async Task<List<Stock>> LoadStock() 
        {
            WebClient wc = new WebClient();
            byte[] data = await wc.DownloadDataTaskAsync(new Uri(LOADAL_URL));
            string json = Encoding.UTF8.GetString(data);
            StockAPIResult result = JsonConvert.DeserializeObject<StockAPIResult>(json);

            return result.Results;
        }
    }
}

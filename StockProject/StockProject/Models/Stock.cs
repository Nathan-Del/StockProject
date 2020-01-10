using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Models
{
    public class Stock 
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public int CodeBarre { get; set; }
        //public string Description { get; set; }
        //public decimal Price { get; set; }
        //public int NbrStock { get; set; }
        public string Id { get; set; }
        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string BookName { get; set; }

        public Int64 CodeBarre { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Int64 nbrStock { get; set; }
        public override string ToString()
        {
            return BookName;
        }
    }
}



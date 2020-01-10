using Newtonsoft.Json;
using StockProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

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
            List<Stock> result = JsonConvert.DeserializeObject<List<Stock>>(json);

            return result;
        }
        public static Task<List<Stock>> CreatStock()
        {
            // Create a request using a URL that can receive a post.   
            WebRequest request = WebRequest.Create("https://localhost:44368/api/books");
            // Set the Method property of the request to POST.  
            request.Method = "POST";

            // Create POST data and convert it to a byte array.  
            //string postData = "This is a test that posts this string to a Web server.";

            string json = "{" +
                  "\"Name\":\"" + ViewModel.StockViewModel.BookName + "\"," +
                  "\"CodeBarre\":\"" + ViewModel.StockViewModel.CodeBarre + "\"," +
                  "\"Price\":\"" + ViewModel.StockViewModel.Prix + "\"," +
                  "\"Description\":\"" + ViewModel.StockViewModel.Description + "\", " +
                  "\"nbrStock\":\"" + ViewModel.StockViewModel.nbrStock + "\"}";
            

            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            // Set the ContentType property of the WebRequest.  
            request.ContentType = "application/json";
            // Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length;

            // Get the request stream.  
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.  
            dataStream.Close();

            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.  
            // The using block ensures the stream is automatically closed.
            using (dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                // Display the content.  
                Console.WriteLine(responseFromServer);
            }

            // Close the response.  
            response.Close();

            return null;
        }


        public static Task<Stock> DeleteStock(string Id) 
        {
            // Create a request using a URL that can receive a post.   
            WebRequest request = WebRequest.Create("https://localhost:44368/api/books/" + Id);
            // Set the Method property of the request to POST.  
            request.Method = "DELETE";

            
            request.ContentType = "application/json";
            Stream dataStream = request.GetRequestStream();
            dataStream.Close();

            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using (dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                // Display the content.  
                Console.WriteLine(responseFromServer);
            }

            // Close the response.  
            response.Close();

            return null;
        }


        public static Task<List<Stock>> UpdateStock(string Id) 
        {
            // Create a request using a URL that can receive a post.   
            WebRequest request = WebRequest.Create("https://localhost:44368/api/books/" + Id);
            // Set the Method property of the request to POST.  
            request.Method = "PUT";

            // Create POST data and convert it to a byte array.  
            //string postData = "This is a test that posts this string to a Web server.";

            string json = "{" +
                  "\"Id\":\"" + Id + "\"," +
                  "\"Name\":\"" + ViewModel.InfoViewModel.CurrentStock.BookName + "\"," +
                  "\"CodeBarre\":\"" + ViewModel.InfoViewModel.CurrentStock.CodeBarre  + "\"," +   
                  "\"Price\":\"" + ViewModel.InfoViewModel.CurrentStock.Price + "\"," +
                  "\"Description\":\"" + ViewModel.InfoViewModel.CurrentStock.Description + "\", " +
                  "\"nbrStock\":\"" + ViewModel.InfoViewModel.CurrentStock.nbrStock + "\"}";


            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            // Set the ContentType property of the WebRequest.  
            request.ContentType = "application/json";
            // Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length;

            // Get the request stream.  
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.  
            dataStream.Close();

            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.  
            // The using block ensures the stream is automatically closed.
            using (dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                // Display the content.  
                Console.WriteLine(responseFromServer);
            }

            // Close the response.  
            response.Close();

            return null;
        }
         
        //public static Task<List<Stock>> UpdateNBR(string Id)
        //{ 
        //    // Create a request using a URL that can receive a post.   
        //    WebRequest request = WebRequest.Create("https://localhost:44368/api/books/" + Id);
        //    // Set the Method property of the request to POST.  
        //    request.Method = "PUT";

        //    // Create POST data and convert it to a byte array.  
        //    //string postData = "This is a test that posts this string to a Web server.";


        //    string json = "{" +
        //          "\"Id\":\"" + Id + "\"," +
        //          "\"Name\":\"" + ViewModel.InfoViewModel.CurrentStock.BookName + "\"," +
        //          "\"CodeBarre\":\"" + ViewModel.InfoViewModel.CurrentStock.CodeBarre + "\"," +
        //          "\"Price\":\"" + ViewModel.InfoViewModel.CurrentStock.Price + "\"," +
        //          "\"Description\":\"" + ViewModel.InfoViewModel.CurrentStock.Description + "\", " +
        //          "\"nbrStock\":\"" +  + "\"}";


        //    byte[] byteArray = Encoding.UTF8.GetBytes(json);

        //    // Set the ContentType property of the WebRequest.  
        //    request.ContentType = "application/json";
        //    // Set the ContentLength property of the WebRequest.  
        //    request.ContentLength = byteArray.Length;

        //    // Get the request stream.  
        //    Stream dataStream = request.GetRequestStream();
        //    // Write the data to the request stream.  
        //    dataStream.Write(byteArray, 0, byteArray.Length);
        //    // Close the Stream object.  
        //    dataStream.Close();

        //    // Get the response.  
        //    WebResponse response = request.GetResponse();
        //    // Display the status.  
        //    Console.WriteLine(((HttpWebResponse)response).StatusDescription);

        //    // Get the stream containing content returned by the server.  
        //    // The using block ensures the stream is automatically closed.
        //    using (dataStream = response.GetResponseStream())
        //    {
        //        // Open the stream using a StreamReader for easy access.  
        //        StreamReader reader = new StreamReader(dataStream);
        //        // Read the content.  
        //        string responseFromServer = reader.ReadToEnd();
        //        // Display the content.  
        //        Console.WriteLine(responseFromServer);
        //    }

        //    // Close the response.  
        //    response.Close();

        //    return null; 
        //}

        
    }
}



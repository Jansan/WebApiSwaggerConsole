using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace WebRequestPostExample
{
    class Program
    {
        static void Main(string[] args)
        {
            PostJson("https://localhost:44322/api/Speakers", new Speaker
            { 
                name = "Will Smith",
                Bio = "likes to drive cars",
                webSite = "www.smith.com"
            });
        }

        private static void PostJson(string uri, Speaker postParameters)
        {
            string postData = JsonConvert.SerializeObject(postParameters);
            byte[] bytes = Encoding.UTF8.GetBytes(postData); 
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = bytes.Length;
            httpWebRequest.ContentType = "application/json";
            using (Stream requestStream = httpWebRequest.GetRequestStream())
            { 
                requestStream.Write(bytes, 0, bytes.Count());
            }
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse(); 
            Console.WriteLine(httpWebResponse);
        }
    }
}

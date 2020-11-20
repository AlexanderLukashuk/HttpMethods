using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpMethods
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //https://postman-echo.com/get?foo1=bar1&foo2=bar2
            //var getRequest = WebRequest.Create("https://postman-echo.com/get?foo1=bar1&foo2=bar2");
            //getRequest.Method = "GET";
            ////getRequest.Headers.Add(...)

            //var getResponse = getRequest.GetResponse() as HttpWebResponse;

            //using (var stream = new StreamReader(getResponse.GetResponseStream()))
            //{
            //    Console.WriteLine(stream.ReadToEnd());
            //}
            //getResponse.Close();

            var postRequest = WebRequest.Create("https://postman-echo.com/post");
            postRequest.Method = "POST";

            string data = "sName=Hello from VS(C#)";

            byte[] buffer = Encoding.UTF8.GetBytes(data);

            postRequest.ContentType = "application/x-www-form-urlencoded";
            postRequest.ContentLength = buffer.Length;

            using (var stream = postRequest.GetRequestStream())
            {
                stream.Write(buffer, 0, buffer.Length);
            }

            var postResponse = await postRequest.GetResponseAsync();
            using (var stream = postResponse.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }

            postResponse.Close();
            Console.WriteLine();

            var putRequest = WebRequest.Create("https://postman-echo.com/put");
            postRequest.Method = "PUT";

            string putData = "sName=Method PUT";

            byte[] putBuffer = Encoding.UTF8.GetBytes(putData);

            putRequest.ContentType = "application/x-www-form-urlencoded";
            putRequest.ContentLength = putBuffer.Length;

            using (var stream = putRequest.GetRequestStream())
            {
                stream.Write(putBuffer, 0, putBuffer.Length);
            }

            var putResponse = await putRequest.GetResponseAsync();
            using (var stream = putResponse.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
}

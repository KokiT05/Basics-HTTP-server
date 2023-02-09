namespace HTTPClientDemo
{
    using System.ComponentModel;
    using System.Net;
    using System.Net.Http;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Runtime.InteropServices;

    public class Program
    {
        const string NewLine = "\r\n";
        static string pathTofile = @"Views\F.html";

        static async Task Main(string[] args)
        {
            

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 1522);
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                
                    using (NetworkStream stream = client.GetStream())
                    {

                        //int byteLenght = 0;
                        byte[] buffer = new byte[100000];

                        //while (true)
                        //{
                        int numberOfCharacters = stream.Read(buffer, 0, buffer.Length);
                        //if (numberOfCharacters == 0)
                        //{
                        //    break;
                        //}

                        string requestString = Encoding.UTF8.GetString(buffer, 0, numberOfCharacters);

                        
                        //string htmlPage = ReturHtmlPage(requestString);

                        Console.WriteLine(requestString);
                        //}

                        Console.WriteLine(new string('=', 100));
                        Console.WriteLine();

                        string responseHtml = ReturHtmlPage(requestString);
                    int contentLenght = Encoding.UTF8.GetByteCount(responseHtml);

                        string response = "HTTP/1.1 200 OK" + NewLine +
                                          //"Location: https://google.com" + NewLine +
                                          "Server: MyServer 2023" + NewLine +
                                          "Content-Type: text/html; charset=utf-8" + NewLine +
                                          $"Content-Lenght: {contentLenght}" + NewLine +
                                          NewLine +
                                          responseHtml +
                                          NewLine;

                        byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                        stream.Write(responseBytes);
                        stream.Close();
                    }
            }
            //Console.WriteLine(IPAddress.Loopback);
        }

        public static async Task ReadResponse()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string url = "https://localhost/";
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            Console.WriteLine($"Method: {response.RequestMessage.Method}; Satus code: {(int)response.StatusCode}; {response.StatusCode};");
            Console.WriteLine("Headers ----- ");
            Console.Write("Header: ");
            Console.WriteLine(string.Join("\r\nHeader: " ,
                            response.Headers
                            .Select(x => x.Key + ": " + string.Join(" ", x.Value) + ";")));
        }

        public static string ReturHtmlPage(string httprequest)
        {
            string[] HTTPdata = httprequest.Split(NewLine);

            string[] HTTPInformationAbautRequest = HTTPdata[0].Split(" ");

            string methodOfRequest = HTTPInformationAbautRequest[0];
            string pathOfTheFile = HTTPInformationAbautRequest[1];
            string versionOfHTTP = HTTPInformationAbautRequest[2];

            StringBuilder htmlResponse = new StringBuilder();
            byte[] buffer = new byte[1024];
            int bytesRead = 0;
            try
            {
                using (FileStream fileStream = new FileStream(pathTofile.Replace("F", pathOfTheFile), FileMode.Open))
                {
                    while (true)
                    {
                        bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0)
                        {
                            break;
                        }
                        string text = Encoding.UTF8.GetString(buffer);
                        htmlResponse.Append(text);
                    }
                }
            }
            catch (Exception)
            {
                using (FileStream fileStream = new FileStream(pathTofile.Replace("F", "ErrorPage"), FileMode.Open))
                {
                    while (true)
                    {
                        bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0)
                        {
                            break;
                        }
                        string text = Encoding.UTF8.GetString(buffer);
                        htmlResponse.Append(text);
                    }
                }
            }

            return htmlResponse.ToString().TrimEnd();
        }
    }
}
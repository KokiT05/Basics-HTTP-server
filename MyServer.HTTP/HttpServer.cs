namespace MyServer.HTTP
{
    using MyServer.HTTP.Interfaces;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class HttpServer : IHttpServer
    {
        //private const string NewLine = "\r\n";
        //private const int BufferSize = 4096;
        IDictionary<string , Func<HttpRequest, HttpResponse>> routeTable = new Dictionary<string, Func<HttpRequest, HttpResponse>>();
        //private static TcpListener tcpListener;

        //public HttpServer()
        //{
        //    routeTable = new Dictionary<string, Func<HttpRequest, HttpResponse>>(); 
        //}

        public void AddRoute(string routeName, Func<HttpRequest, HttpResponse> action)
        {
            if (routeTable.ContainsKey(routeName))
            {
                routeTable[routeName] = action;
            }
            else
            {
                routeTable.Add(routeName, action);
            }
        }

        public async Task StartAsync(int port = 80)
        {
            //tcpListener = new TcpListener(IPAddress.Loopback, port);
            //tcpListener.Start();

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);

            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                ProcessClientAsync(tcpClient);
            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            try
            {
                using (NetworkStream stream = tcpClient.GetStream())
                {
                    List<byte> readData = new List<byte>();
                    byte[] buffer = new byte[HttpConstants.BufferSize];
                    int position = 0;

                    while (true)
                    {
                        int readBytes = await stream.ReadAsync(buffer, position, buffer.Length);
                        position += readBytes;

                        if (readBytes < buffer.Length)
                        {
                            byte[] partialBuffer = new byte[readBytes];
                            Array.Copy(buffer, partialBuffer, readBytes);
                            readData.AddRange(partialBuffer);
                            break;
                        }
                        else
                        {
                            readData.AddRange(buffer);
                        }
                    }

                    string request = Encoding.UTF8.GetString(readData.ToArray());
                    HttpRequest httpRequest = new HttpRequest(request);
                    Console.WriteLine($"{httpRequest.Method} {httpRequest.Path} => {httpRequest.Headers.Count} headers");

                    HttpResponse httpResponse;
                    if (this.routeTable.ContainsKey(httpRequest.Path))
                    {
                        var value = this.routeTable[httpRequest.Path];
                        httpResponse = value(httpRequest);
                    }
                    else
                    {
                        httpResponse = new HttpResponse("text/html", new byte[0], HttpStatusCode.NotFound);
                    }

                    //string responseHttp = "HTTP/1.1 200 OK" + HttpConstants.NewLine +
                    //                      "Content-Type: text/html" + HttpConstants.NewLine +
                    //                      $"Content-Length: {responseHtmlBytes.Length}" + HttpConstants.NewLine +
                    //                      "Server: MyFirstServer" + HttpConstants.NewLine +
                    //                      HttpConstants.NewLine +
                    //                      responseHtml +
                    //                      HttpConstants.NewLine;

                    byte[] responseInBytes = Encoding.UTF8.GetBytes(httpResponse.ToString());

                    await stream.WriteAsync(responseInBytes);
                    await stream.WriteAsync(httpResponse.Body);

                    stream.Dispose();
                    stream.Close();
                }

                tcpClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //public void Stop()
        //{
        //    tcpListener.Stop();
        //}
    }
}
using System.IO.Pipes;

namespace bsaberdownloader.NamedPipes
{
    internal class NamedPipeServer
    {
        public static string Start()
        {
            using (var pipeServer = new NamedPipeServerStream("BSDownloaderPipe"))
            {
                Console.WriteLine("Waiting for connection...");
                pipeServer.WaitForConnection();

                Console.WriteLine("Connected.");

                using (var reader = new StreamReader(pipeServer))
                {
                    string message = reader.ReadToEnd();
                    Console.WriteLine("Received message: " + message);
                    return message;
                }
            }
        }
    }
}

using System.IO.Pipes;

namespace bsaberdownloader.NamedPipes
{
    internal class NamedPipeClient
    {
        public static void Start(string mapId)
        {
            using var pipeClient = new NamedPipeClientStream(".", "BSDownloaderPipe", PipeDirection.Out);
            Console.WriteLine("Connecting to server...");
            pipeClient.Connect();

            Console.WriteLine("Connected.");

            using (var writer = new StreamWriter(pipeClient))
            {
                writer.Write(mapId);
                Console.WriteLine("Sent message: " + mapId);
            }
        }
    }
}

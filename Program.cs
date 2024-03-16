using bsaberdownloader;
using bsaberdownloader.NamedPipes;
using bsaberdownloader.Downloaders;

namespace FileDownloader
{
    internal class Config
    {
        public const string BSaberDir =
            "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Beat Saber\\Beat Saber_Data\\CustomLevels";
    }

 internal class Program
    {
        static void Main(string[] args)
        {
            new Mutex(false, "BSDownloaderMutex", out var isFirst);

            if (!isFirst)
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Please provide an ID as a command-line argument.");
                    return;
                }
                NamedPipeClient.Start(args[0]);
                return;
            }

            var bSaverDownload = new BSaverDownload();
            var mapService = new MapService(bSaverDownload);
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide an ID as a command-line argument.");
            }
            else
            {
                mapService.InstallMap(args[0]);
            }

            while (true)
            {
                var mapId = NamedPipeServer.Start();
                mapService.InstallMap(mapId);
            }
        }
    }
}

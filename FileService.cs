using FileDownloader;
using System.IO.Compression;

namespace bsaberdownloader
{
    internal class FileService
    {
        public static async void SaveMap(HttpResponseMessage mapData, MapInfo mapInfo)
        {
            var tempFilePath = Path.Join(Path.GetTempPath(), mapInfo.Id);
            var contentLength = mapData.Content.Headers.ContentLength;

            await using var content = await mapData.Content.ReadAsStreamAsync();

            await using FileStream fileStream = new(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
            var buffer = new byte[8192];
            int bytesRead;
            long downloadedBytes = 0;

            while ((bytesRead = await content.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await fileStream.WriteAsync(buffer, 0, bytesRead);
                downloadedBytes += bytesRead;

                if (!contentLength.HasValue) continue;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write($"Downloading: [{new string('#', (int)(downloadedBytes * 50 / contentLength)!),-50}] {downloadedBytes * 100 / contentLength}%");
            }

            Console.WriteLine("\nUnzipping...");
            UnzipAndMove(tempFilePath, Path.Combine(Config.BSaberDir, $"{mapInfo.Id} {mapInfo.Name}"));
            File.Delete(tempFilePath);
            await Task.Delay(1000 * 2);

        }

        private static void UnzipAndMove(string from, string to)
        {
            if (Directory.Exists(to))
            {
                Console.WriteLine($"\n{to} already exists");
                return;
            }

            Directory.CreateDirectory(to);
            ZipFile.ExtractToDirectory(from, to);
            Console.WriteLine("\nUnzipping complete!");
        }
    }
}

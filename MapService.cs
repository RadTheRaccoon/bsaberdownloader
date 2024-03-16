using bsaberdownloader.Downloaders;

namespace bsaberdownloader
{
    internal class MapService
    {
        private readonly IMapDownloader _downloader;
        public MapService(IMapDownloader downloader) { _downloader = downloader; }

        public async void InstallMap(string id)
        {
            var mapInfo = await _downloader.GetMapInfo(id);
            var mapData = await _downloader.GetMap(mapInfo);
            FileService.SaveMap(mapData, mapInfo);

        }
    }

}

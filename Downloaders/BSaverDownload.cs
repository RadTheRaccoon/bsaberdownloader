using System.Text.Json;

namespace bsaberdownloader.Downloaders
{
    internal class BSaverDownload : IMapDownloader
    {
        private readonly HttpClient _httpClient;
        private const string BaseDownloadUrl = "https://api.beatsaver.com/download/key/";
        private const string BaseMetaUrl = "https://api.beatsaver.com/maps/id/";

        public BSaverDownload(HttpClient client)
        {
            _httpClient = client;
        }

        public BSaverDownload()
        {
            _httpClient = new HttpClient();
        }

        public async Task<MapInfo> GetMapInfo(string fileId)
        {
            var mapDataUrl = BaseMetaUrl + fileId;
            var mapDataResp = await _httpClient.GetStringAsync(mapDataUrl);

            if (mapDataResp.Length == 0)
            {
                throw new Exception("An error has occured gathering map information");
            }

            var mapInfo = JsonSerializer.Deserialize<MapInfo>(mapDataResp!);
            string mapName = $"{mapInfo!.Id} ({mapInfo.Name})"!;

            return mapInfo;
        }

        public async Task<HttpResponseMessage> GetMap(MapInfo mapInfo)
        {
            var mapDownloadUrl = BaseDownloadUrl + mapInfo!.Id;
            var mapDownloadResp = await _httpClient.GetAsync(mapDownloadUrl);

            if (!mapDownloadResp.IsSuccessStatusCode)
            {
                throw new Exception("Error downloading the map");
            }
            return mapDownloadResp;
        }
    }
}

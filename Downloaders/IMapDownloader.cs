namespace bsaberdownloader.Downloaders
{
    internal interface IMapDownloader
    {
        public Task<MapInfo> GetMapInfo(string id);

        public Task<HttpResponseMessage> GetMap(MapInfo mapInfo);
    }
}

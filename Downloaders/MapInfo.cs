namespace bsaberdownloader.Downloaders
{
    internal class Curator
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Hash { get; set; }
        public string Avatar { get; set; }
        public string Type { get; set; }
        public bool? Admin { get; set; }
        public bool? curator { get; set; }
        public bool? CuratorTab { get; set; }
        public bool? VerifiedMapper { get; set; }
        public string PlaylistUrl { get; set; }
    }

    internal class Diff
    {
        public double? Njs { get; set; }
        public double? Offset { get; set; }
        public int? Notes { get; set; }
        public int? Bombs { get; set; }
        public int? Obstacles { get; set; }
        public double? Nps { get; set; }
        public double? Length { get; set; }
        public string Characteristic { get; set; }
        public string Difficulty { get; set; }
        public int? Events { get; set; }
        public bool? Chroma { get; set; }
        public bool? Me { get; set; }
        public bool? Ne { get; set; }
        public bool? Cinema { get; set; }
        public double? Seconds { get; set; }
        public ParitySummary ParitySummary { get; set; }
        public int? MaxScore { get; set; }
    }

    internal class Metadata
    {
        public double? Bpm { get; set; }
        public int? Duration { get; set; }
        public string SongName { get; set; }
        public string SongSubName { get; set; }
        public string SongAuthorName { get; set; }
        public string LevelAuthorName { get; set; }
    }

    internal class ParitySummary
    {
        public int? Errors { get; set; }
        public int? Warns { get; set; }
        public int? Resets { get; set; }
    }

    internal class MapInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Uploader Uploader { get; set; }
        public Metadata Metadata { get; set; }
        public Stats Stats { get; set; }
        public DateTime? Uploaded { get; set; }
        public bool? Automapper { get; set; }
        public bool? Ranked { get; set; }
        public bool? Qualified { get; set; }
        public List<Version> Versions { get; set; }
        public Curator Curator { get; set; }
        public DateTime? CuratedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? LastPublishedAt { get; set; }
        public List<string> Tags { get; set; }
        public bool? Bookmarked { get; set; }
    }

    internal class Stats
    {
        public int? Plays { get; set; }
        public int? Downloads { get; set; }
        public int? Upvotes { get; set; }
        public int? Downvotes { get; set; }
        public double? Score { get; set; }
    }

    internal class Uploader
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Hash { get; set; }
        public string Avatar { get; set; }
        public string Type { get; set; }
        public bool? Admin { get; set; }
        public bool? Curator { get; set; }
        public bool? VerifiedMapper { get; set; }
        public string PlaylistUrl { get; set; }
    }

    internal class Version
    {
        public string Hash { get; set; }
        public string State { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? SageScore { get; set; }
        public List<Diff> Diffs { get; set; }
        public string DownloadUrl { get; set; }
        public string CoverUrl { get; set; }
        public string PreviewUrl { get; set; }
    }


}

namespace sims.DTO
{
    public partial class DataUsageDTO
    {
        public long IdDataUsage { get; set; }
        public long OpenDataId { get; set; }
        public DateTime DateOfUsage { get; set; }
        public int DataFormatId { get; set; }
        public int LanguageId { get; set; }
        public sbyte IsDownloaded { get; set; }

        public virtual DataFormatDTO DataFormat { get; set; } = null!;
        public virtual DataLanguageDTO Language { get; set; } = null!;
        public virtual OpenDatumDTO OpenData { get; set; } = null!;

    }
}

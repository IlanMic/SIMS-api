namespace sims.DTO
{
    public partial class OpenDatumDTO
    {
        public long IdData { get; set; }
        public string DataUrl { get; set; } = null!;
        public sbyte DataOpenLicense { get; set; }
        public long DataOwnerId { get; set; }
        public int UpdateFrequencyId { get; set; }
        public int DataThemeId { get; set; }

        public virtual DataOwnerDTO DataOwner { get; set; } = null!;
        public virtual DataThemeDTO DataTheme { get; set; } = null!;
        public virtual UpdateFrequencyDTO UpdateFrequency { get; set; } = null!;
    }
}

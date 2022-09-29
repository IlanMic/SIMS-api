using System;
using System.Collections.Generic;

namespace Sims.Models
{
    public partial class OpenDatum
    {
        public OpenDatum()
        {
            DataUsages = new HashSet<DataUsage>();
        }

        public long IdData { get; set; }
        public string DataUrl { get; set; } = null!;
        public sbyte DataOpenLicense { get; set; }
        public long DataOwnerId { get; set; }
        public int UpdateFrequencyId { get; set; }
        public int DataThemeId { get; set; }

        public virtual DataOwner DataOwner { get; set; } = null!;
        public virtual DataTheme DataTheme { get; set; } = null!;
        public virtual UpdateFrequency UpdateFrequency { get; set; } = null!;
        public virtual ICollection<DataUsage> DataUsages { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Sims.Models
{
    public partial class DataUsage
    {
        public long IdDataUsage { get; set; }
        public long OpenDataId { get; set; }
        public DateTime DateOfUsage { get; set; }
        public int DataFormatId { get; set; }
        public int LanguageId { get; set; }
        public sbyte IsDownloaded { get; set; }

        public virtual DataFormat DataFormat { get; set; } = null!;
        public virtual DataLanguage Language { get; set; } = null!;
        public virtual OpenDatum OpenData { get; set; } = null!;
    }
}

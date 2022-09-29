using System;
using System.Collections.Generic;

namespace Sims.Models
{
    public partial class DataFormat
    {
        public DataFormat()
        {
            DataUsages = new HashSet<DataUsage>();
        }

        public int IdDataFormat { get; set; }
        public string DataFormatName { get; set; } = null!;

        public virtual ICollection<DataUsage> DataUsages { get; set; }
    }
}

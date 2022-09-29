using System;
using System.Collections.Generic;

namespace Sims.Models
{
    public partial class DataLanguage
    {
        public DataLanguage()
        {
            DataUsages = new HashSet<DataUsage>();
        }

        public int IdDataLanguage { get; set; }
        public string DataLanguageName { get; set; } = null!;

        public virtual ICollection<DataUsage> DataUsages { get; set; }
    }
}

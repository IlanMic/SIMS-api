using System;
using System.Collections.Generic;

namespace Sims.Models
{
    public partial class DataTheme
    {
        public DataTheme()
        {
            OpenData = new HashSet<OpenDatum>();
        }

        public int IdDataTheme { get; set; }
        public string DataThemeName { get; set; } = null!;

        public virtual ICollection<OpenDatum> OpenData { get; set; }
    }
}

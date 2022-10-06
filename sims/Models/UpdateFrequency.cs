using System;
using System.Collections.Generic;

namespace Sims.Models
{
    public partial class UpdateFrequency
    {
        public UpdateFrequency()
        {
            OpenData = new HashSet<OpenDatum>();
        }

        public int IdUpdateFrequency { get; set; }
        public string UpdateFrequencyName { get; set; } = null!;

        public virtual ICollection<OpenDatum> OpenData { get; set; }
    }
}

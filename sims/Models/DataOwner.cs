using System;
using System.Collections.Generic;

namespace Sims.Models
{
    public partial class DataOwner
    {
        public DataOwner()
        {
            OpenData = new HashSet<OpenDatum>();
        }

        public long IdDataOwner { get; set; }
        public string DataOwnerName { get; set; } = null!;

        public virtual ICollection<OpenDatum> OpenData { get; set; }
    }
}

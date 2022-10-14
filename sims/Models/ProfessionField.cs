using System;
using System.Collections.Generic;

namespace Sims.Models
{
    public partial class ProfessionField
    {
        public ProfessionField()
        {
            Users = new HashSet<User>();
        }

        public int IdProfessionField { get; set; }
        public string ProfessionFieldName { get; set; } = null!;
        public int ProfessionId { get; set; }

        public virtual Profession Profession { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; }
    }
}

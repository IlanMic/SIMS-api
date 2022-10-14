using System;
using System.Collections.Generic;

namespace Sims.Models
{
    public partial class Profession
    {
        public Profession()
        {
            ProfessionFields = new HashSet<ProfessionField>();
            Users = new HashSet<User>();
        }

        public int IdProfession { get; set; }
        public string ProfessionName { get; set; } = null!;

        public virtual ICollection<ProfessionField> ProfessionFields { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Sims.Models
{
    public partial class User
    {
        public User()
        {
            DataUsages = new HashSet<DataUsage>();
        }

        public long IdUser { get; set; }
        public int UserProfessionId { get; set; }
        public int UserProfessionFieldId { get; set; }
        public string? UserName { get; set; }
        public string? UserMail { get; set; }
        public string? UserCompany { get; set; }
        public byte[]? UserPicture { get; set; }

        public virtual Profession UserProfession { get; set; } = null!;
        public virtual ProfessionField UserProfessionField { get; set; } = null!;
        public virtual ICollection<DataUsage> DataUsages { get; set; }
    }
}

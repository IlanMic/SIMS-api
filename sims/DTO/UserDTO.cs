namespace sims.DTO
{
    public partial class UserDTO
    {
        public long IdUser { get; set; }
        public string? UserName { get; set; }
        public string? UserMail { get; set; }
        public string? UserCompany { get; set; }
        public virtual ProfessionDTO UserProfession { get; set; } = null!;
        public virtual ProfessionFieldDTO UserProfessionField { get; set; } = null!;
    }
}

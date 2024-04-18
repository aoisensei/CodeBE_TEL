namespace CodeBE_TEL.Entities
{
    public class AppUser
    {
        public long Id { get; set; }

        public string UserName { get; set; } = null!;

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Gender { get; set; }

        public string? Password { get; set; }

        public string? Status { get; set; }
    }
}

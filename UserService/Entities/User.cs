namespace UserService.Entities
{
    public class User
    {
        public int Id { get; set; }  // AuthService'ten gelen ID
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Bio { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

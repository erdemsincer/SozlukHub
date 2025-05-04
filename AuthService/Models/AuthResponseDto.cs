namespace AuthService.Models
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = null!;
        public DateTime ExpireAt { get; set; }
    }
}

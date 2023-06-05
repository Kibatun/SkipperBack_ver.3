
namespace SkipperBack3.EFCore
{
    public class UserModel
    {
        public Guid Uid { get; set; } = Guid.Empty;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool IsMenor { get; set; } = false;
        public string Bio { get; set; } = null!;
        public string Post { get; set; } = null!;
        public byte[]? Avatar { get; set; }
        public float Rating { get; set; } = 0.0f;
        public int ReviewsCount { get; set; } = 0;
        public long UpdatedAt { get; set; } = 0;
        public long CreatedAt { get; set; } = 0;
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkipperBack3.EFCore
{
    [Table("refreshToken")]
    public class RefreshUserToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid Token { get; set; }

        [Required]
        public DateTime ExpiresAt { get; set; }

        public bool isExpired { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public User User { get; set; }

    }
}

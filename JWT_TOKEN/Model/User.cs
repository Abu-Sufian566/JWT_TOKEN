using System.ComponentModel.DataAnnotations;

namespace JWT_TOKEN.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? UserName { get; set; }
        [Required]
        [StringLength(100)]
        public string? Password { get; set; }
    }
}

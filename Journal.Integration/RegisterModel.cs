using System.ComponentModel.DataAnnotations;

namespace Journal.Model
{
    public class RegisterModel
    {
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Password { get; set; }
    }
}

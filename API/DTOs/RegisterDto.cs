using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        /*
            (?=.*\\d) => at least one char should be number
            (?=.*[a-z]) => at least one char should be lowercase letter
            (?=.*[A-Z]) => at least one char should be uppercase letter
            .{4,8}$ => min 4 chars, max 8 chars
        */
        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", ErrorMessage = "Password must be complex")]
        public string Password { get; set; }
        
        [Required]
        public string Username { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Eyouth_APIs.DTOs
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}

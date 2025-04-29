using System.ComponentModel.DataAnnotations;

namespace DemoMvcApp.Models
{
    public class RegistrationViewModel
    {
        [Required, MinLength(3)]
        public string UserName { get; set; }
        
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Passwort bestätigen")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Die Passwörter stimmen nicht überein")]
        public string ConfirmPassword { get; set; }
    }
}

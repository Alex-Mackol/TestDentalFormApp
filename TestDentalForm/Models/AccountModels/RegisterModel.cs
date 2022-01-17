using System.ComponentModel.DataAnnotations;

namespace TestDentalForm.Models.AccountModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Can`t be null!")]
        public string Name { get; set; }
        public string Surname { get; set; }

        [Required(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Can`t be null!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords aren`t equal")]
        public string ConfirmPassword { get; set; }
    }
}

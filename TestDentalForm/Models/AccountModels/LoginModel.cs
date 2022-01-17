using System.ComponentModel.DataAnnotations;

namespace TestDentalForm.Models.AccountModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Can`t be null!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

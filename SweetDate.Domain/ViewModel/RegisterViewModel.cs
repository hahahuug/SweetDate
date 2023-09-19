using System.ComponentModel.DataAnnotations;

namespace SweetDate.Domain.ViewModel;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Username")]
    [Display(Name = "Username")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Your full name")]
    [Display(Name = "Name")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Enter login")]
    [MinLength(8, ErrorMessage = "The login must be longer than 8 characters")]
    public string Login { get; set; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Desired password")]
    [MinLength(6, ErrorMessage = "The password must be longer than 6 characters")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Confirm password")]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string PasswordConfirm { get; set; }
}
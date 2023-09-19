using System.ComponentModel.DataAnnotations;

namespace SweetDate.Domain.ViewModel;

public class LoginViewModel
{
    [Required(ErrorMessage = "Username")]
    [Display(Name = "Username")]
    public string Username { get; set; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password")]
    [Display(Name = "Password")]
    public string Password { get; set; }
}
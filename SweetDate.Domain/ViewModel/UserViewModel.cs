using System.ComponentModel.DataAnnotations;

namespace SweetDate.Domain.ViewModel;

public class UserViewModel
{
    public long Id { get; set; }
    
    [Required(ErrorMessage = "Enter your username")]
    [Display(Name = "Username")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Enter your name")]
    [Display(Name = "Name")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Your email")]
    [Display(Name = "Login")]
    public string Login { get; set; }
    
    [Required(ErrorMessage = "Enter your password")]
    [Display(Name = "Password")]
    public string Password { get; set; }
    

}
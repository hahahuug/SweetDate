using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SweetDate.Domain.ViewModel;

public class PersonViewModel
{
    public long Id { get; set; }
    
    [Required(ErrorMessage = "Gender is required.")]
    public string Gender { get; set; }
    
    [Required(ErrorMessage = "Age is required.")]
    [Range(18, 75, ErrorMessage = "Age must be between 18 and 75.")]
    public int Age { get; set; }
    
    [Required(ErrorMessage = "Enter description.")]
    [RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "Description can only contain letters and spaces.")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Enter tg.")]
    public string Tg { get; set; }
    
    [Required(ErrorMessage = "Enter city.")]
    [RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "City can only contain letters and spaces.")]
    public string City { get; set; }
    
    // public DateTime DateCreate { get; set; }
    
    // public IFormFile Avatar { get; set; }
    //
    // public byte[]? Image { get; set; }
    [Required(ErrorMessage = "Add a photo.")]
    public string Avatar { get; set; }
    
    [Required(ErrorMessage = "Gender is required.")]
    public string LookingGender { get; set; }
    
    [Required(ErrorMessage = "Enter country.")]
    [RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "Country can only contain letters and spaces.")]
    public string Country { get; set; }
    
    public string Name { get; set; }
    
    public string UserName { get; set; }
}
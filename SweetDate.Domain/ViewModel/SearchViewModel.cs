using System.ComponentModel.DataAnnotations;

namespace SweetDate.Domain.ViewModel;

public class SearchViewModel
{
        public string LookingGender { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        
        [Required(ErrorMessage = "Enter city")]
        public string City { get; set; }
}
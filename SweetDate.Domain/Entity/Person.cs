using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using SweetDate.Domain.Enum;

namespace SweetDate.Domain.Entity;

public class Person
    {
        public long Id { get; set; }
        
        public string Gender { get; set; }
        
        public string LookingGender { get; set; }
        
        public int Age { get; set; }

        public string Description { get; set; }

        public string Tg { get; set; }

        public string City { get; set; }
        
        public string Country { get; set; }
        
        public string Avatar { get; set; }

        // public byte[]? Avatar { get; set; }
        
        // public DateTime DateCreate { get; set; }
        
        public long UserId { get; set; }
        
        public User User { get; set; }

    }
    
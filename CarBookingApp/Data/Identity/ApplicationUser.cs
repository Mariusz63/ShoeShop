using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShopApp.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        public string? ProfilePicture { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}

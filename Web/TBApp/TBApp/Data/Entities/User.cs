using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static TBApp.Data.DataConstants.User;

namespace TBApp.Data.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(FirstNameMaxLength)]
        public string FirstName { get; init; }

        [Required]
        [StringLength(LastNameMaxLength)]
        public string LastName { get; init; }
    }
}

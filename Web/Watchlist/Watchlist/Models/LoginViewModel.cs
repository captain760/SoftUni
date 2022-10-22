using System.ComponentModel.DataAnnotations;

namespace Watchlist.Models
{
    public class LoginViewModel
    {
        [Required]
        //[StringLength(20, MinimumLength = 5)]   //not needed in the LOGIN page - only in REGISTER page!
        public string UserName { get; set; } = null!;

        [Required]
        //[StringLength(20, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}

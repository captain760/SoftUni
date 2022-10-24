using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class LoginViewModel
    {
        //validation for length skipped in order not to hint possible attacker
        [Required]        
        public string UserName { get; set; } = null!;

        [Required]        
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}

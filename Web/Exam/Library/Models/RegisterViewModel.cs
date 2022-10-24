using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(Data.DataConstants.User.UserNameMaxLength, MinimumLength = Data.DataConstants.User.UserNameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(Data.DataConstants.User.EmailMaxLength, MinimumLength = Data.DataConstants.User.EmailMinLength)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(Data.DataConstants.User.PasswordMaxLength, MinimumLength = Data.DataConstants.User.PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}

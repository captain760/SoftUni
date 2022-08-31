using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Data.Models
{
    public class Author
    {
        public Author()
        {
            this.AuthorsBooks = new HashSet<AuthorBook>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(12)]
        [RegularExpression(@"^(\d{3})-(\d{3})-(\d{4})$")]
        public string Phone { get; set; }

        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}

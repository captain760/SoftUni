﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Writer
    {
        public Writer()
        {
            Songs = new HashSet<Song>();

        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.WreterNameMaxLength)]
        public string Name { get; set; }
        public string Pseudonym { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}

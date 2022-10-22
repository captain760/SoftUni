﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Watchlist.Data.Entities
{
    public class UserMovie
    {
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } 
        public User User { get; set; } 
        [Required]
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public Movie Movie { get; set; } 
    }
}

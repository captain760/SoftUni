﻿using System.ComponentModel.DataAnnotations;

namespace Watchlist.Data.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } =null!;
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}

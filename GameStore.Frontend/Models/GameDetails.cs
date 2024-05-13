﻿using System.ComponentModel.DataAnnotations;

namespace GameStore.Frontend.Models;

public class GameDetails
{
    public int Id { get; set; }

    [Required] [StringLength(50)]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Genre is required")]
    public string? GenreId { get; set; }
    [Range(1,1000)]
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}

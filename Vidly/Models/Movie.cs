﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
  public class Movie
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public Genre Genre { get; set; }

    [Required]
    [Display(Name = "Genre")]
    public byte GenreId { get; set; }

    [Required]
    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }

    [Required]
    [Display(Name = "Date Added")]
    public DateTime DateAdded { get; set; }

    [Required]
    [Display(Name = "Number in Stock")]
    [Range(1,20)]
    public int NumberInStock { get; set; }

    public Movie()
    {
      DateAdded = DateTime.Now;
    }
  }


}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
  public class MovieFormViewModel
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Genre")]
    public byte GenreId { get; set; }

    [Required]
    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }

    [Required]
    [Display(Name = "Number in Stock")]
    [Range(1, 20)]
    public int NumberInStock { get; set; }

    public IEnumerable<Genre> Genres { get; set; }

    public string FormTitle
    {
      get
      {
        return Id != 0 ? "Edit Movie" : "New Movie";
      }
    }

    public MovieFormViewModel()
    {
      Id = 0;
    }

    public MovieFormViewModel(Movie movie)
    {
      Id = movie.Id;
      Name = movie.Name;
      GenreId = movie.GenreId;
      ReleaseDate = movie.ReleaseDate;
      NumberInStock = movie.NumberInStock;
    }
  }
}
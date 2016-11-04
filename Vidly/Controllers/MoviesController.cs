﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
  public class MoviesController : Controller
  {

    private ApplicationDbContext _context;

    public MoviesController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }

    // GET: Movies
    public ActionResult Random()
    {
      var movie = new Movie() {Name = "Shrek!"};
      var customers = new List<Customer>
      {
        new Customer {Name = "Customer 1"},
        new Customer {Name = "Customer 2"}
      };

      var viewModel = new RandomMovieViewModel
      {
        Movie = movie,
        Customers = customers
      };

      return View(viewModel);
    }

    public ActionResult Edit(int id)
    {
      var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

      if (movie == null)
        return HttpNotFound();

      var viewModel = new MovieFormViewModel
      {
        Movie = movie,
        Genres = _context.Genres.ToList(),
        FormTitle = "Edit Movie"
      };

      return View("MovieForm", viewModel);
    }

    public ActionResult Index()
    {
      var movies = _context.Movies.Include(m => m.Genre).ToList();

      return View(movies);
    }

    [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
    public ActionResult ByReleaseDate(int year, int month)
    {
      return Content(year + "/" + month);
    }

    public ActionResult Details(int id)
    {
      var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

      if(movie == null)
        return HttpNotFound();

      return View(movie);
    }

    public ActionResult New()
    {
      var genres = _context.Genres.ToList();
      var viewModel = new MovieFormViewModel
      {
        Genres = genres,
        FormTitle = "New Movie"
      };

      return View("MovieForm", viewModel);
    }

    public ActionResult Save(Movie movie)
    {
      if (movie.Id == 0)
        _context.Movies.Add(movie);
      else
      {
        var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
        movieInDb.Name = movie.Name;
        movieInDb.ReleaseDate = movie.ReleaseDate;
        movieInDb.GenreId = movie.GenreId;
        movieInDb.NumberInStock = movie.NumberInStock;
      }

      _context.SaveChanges();
      return RedirectToAction("Index", "Movies");
    }
  }
}
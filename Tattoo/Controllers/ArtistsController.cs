using Microsoft.AspNetCore.Mvc;
using Tattoo.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tattoo.Controllers
{
  public class ArtistsController : Controller
  {
    private readonly TattooContext _db;

    public ArtistsController(TattooContext db)
    {
      _db = db;
    }

    public ActionResult Index(string firstName = "")
    {
      var model = _db.Artists;
      if (!string.IsNullOrEmpty(firstName))
      {
        return View(model.AsQueryable().Where(artist => artist.FirstName.Contains(firstName)).ToList());
      }
      return View(model.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Artist Artist)
    {
      _db.Artists.Add(Artist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisArtist = _db.Artists
        .Include(artist => artist.RelationShips).ThenInclude(join => join.Style)
        .Include(artist => artist.RelationShips).ThenInclude(join => join.Client)
        .FirstOrDefault(artist => artist.ArtistId == id);
      return View(thisArtist);
    }

    public ActionResult Edit(int id)
    {
      var thisArtist = _db.Artists.FirstOrDefault(Artists => Artists.ArtistId == id);
      return View(thisArtist);
    }

    [HttpPost]
    public ActionResult Edit(Artist Artist)
    {
      _db.Entry(Artist).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // public ActionResult Delete(int id)
    // {
    //   var thisArtist = _db.Artists.FirstOrDefault(Artists => Artists.ArtistId == id);
    //   return View(thisArtist);
    // }

    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //   var thisArtist = _db.Artists.FirstOrDefault(Artists => Artists.ArtistId == id);
    //   _db.Artists.Remove(thisArtist);
    // }

  }
}

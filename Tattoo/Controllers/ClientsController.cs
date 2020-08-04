using Microsoft.AspNetCore.Mvc;
using Tattoo.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tattoo.Controllers
{
  public class ClientsController : Controller
  {
    private readonly TattooContext _db;

    public ClientsController(TattooContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Clients.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "FirstName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Client client, int ArtistId)
    {
      _db.Clients.Add(client);
      if (ArtistId != 0)
      {
        _db.ArtistClients.Add(new ArtistClient() { ArtistId = ArtistId, ClientId = client.ClientId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisClient = _db.Clients
        .Include(client => client.Artists)
        .ThenInclude(join => join.Artist)
        .FirstOrDefault(client => client.ClientId == id);
      return View(thisClient);
    }

    public ActionResult Edit(int id)
    {
      var thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
      ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "FirstName");
      return View(thisClient);
    }

    [HttpPost]
    public ActionResult Edit(Client client, int ArtistId)
    {
      if (ArtistId != 0)
      {
        _db.ArtistClients.Add(new ArtistClient() { ArtistId = ArtistId, ClientId = client.ClientId });
      }
      _db.Entry(client).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
      return View(thisClient);
    }

    [HttpPost]
    public ActionResult DeleteArtist(int joinId)
    {
      var joinEntry = _db.ArtistClients.FirstOrDefault(entry => entry.ArtistClientId == joinId);
      _db.ArtistClients.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteClient(int id)
    {
      var thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
      _db.Clients.Remove(thisClient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddArtist(int id)
    {
      var thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
      ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "FirstName");
      return View(thisClient);
    }
    [HttpPost]
    public ActionResult AddArtist(Client client, int ArtistId)
    {
      if (ArtistId != 0)
      {
        _db.ArtistClients.Add(new ArtistClient() { ArtistId = ArtistId, ClientId = client.ClientId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}

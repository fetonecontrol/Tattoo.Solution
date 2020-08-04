using Microsoft.AspNetCore.Mvc;
using Tattoo.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tattoo.Controllers
{
  public class StylesController : Controller
  {
    private readonly TattooContext _db;

    public StylesController(TattooContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      var model = _db.Styles;
      return View(model.ToList());
    }

    public ActionResult Details(int id)
    {
      var thisStyle = _db.Styles
        .Include(styles => styles.Artists)
        .ThenInclude(join => join.Artist)
        .FirstOrDefault(style => style.StyleId == id);
      return View(thisStyle);
    }
  }
}

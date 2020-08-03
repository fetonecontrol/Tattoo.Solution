using Microsoft.AspNetCore.Mvc;
using Tattoo.Models;
using System.Collections.Generic;

namespace Tattoo.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

  }
}
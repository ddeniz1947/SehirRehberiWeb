using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SehirRehberiApp.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public ActionResult FirstPage()
        {
            return View();
        }
    }
}
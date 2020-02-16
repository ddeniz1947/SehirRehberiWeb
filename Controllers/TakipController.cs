using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SehirRehberiApp.Controllers
{
    public class TakipController : Controller
    {
        // GET: Takip
        AppDbContext _ctx = new AppDbContext(); 
        public ActionResult Index()
        {
            //_ctx.followClass
            //return View();
            return null;
        }
    }
}
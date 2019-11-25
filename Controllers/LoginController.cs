using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SehirRehberiApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        AppDbContext _ctx = new AppDbContext();
        public ActionResult Login()
        {
            return View();
        }
        
       [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            var users = _ctx.UserProperties.FirstOrDefault(u => u.UserName == UserName);
          
            
            if (users == null)
            {
                SehirRehberiApp.Models.ViewModels.UserViewModel.FakeHash();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (users == null || !users.CheckPassword(Password))
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı Adı veya parola bulunamadı . Tekrar Deneyin.");
                return View();
            }
            else
            {
                
                FormsAuthentication.SetAuthCookie(UserName, true);
                return RedirectToRoute("FirstPage");
            }

     
        }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("HomePage");
        }

    }
}
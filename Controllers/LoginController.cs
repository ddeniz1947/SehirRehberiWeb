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

        /// <summary>
        /// Eklenen Cookie nin Encrypt edilmesi gerekiyor.
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            var users = _ctx.UserProperties.FirstOrDefault(u => u.UserName == UserName);

            if (users == null)
            {
                SehirRehberiApp.Models.ViewModels.UserViewModel.FakeHash();
            }
            if(users != null)
            {
                HttpCookie httpCookie = new HttpCookie("USERID");
                httpCookie.Value = Convert.ToString(users.id);
                httpCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(httpCookie);
                Session.Add("ID", users.id);
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
            Response.Cookies["ID"].Expires = DateTime.Now.AddDays(-1);
            FormsAuthentication.SignOut();
            HttpContext.Session.Clear();
            HttpContext.Session.Abandon();
            HttpCookie cookie1 = new HttpCookie("USERID", "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Response.Cookies.Add(cookie1);
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Response.Cookies.Add(cookie2);
            return RedirectToRoute("HomePage");
        }

    }
}
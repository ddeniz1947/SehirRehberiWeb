using ClassLibrary1.Models;
using SehirRehberiApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SehirRehberiApp.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        AppDbContext _ctx = new AppDbContext();
        public ActionResult Index()
        {

            return View();
        }
       
        [HttpPost]
        public ActionResult Register(string UserName, string Password, string Email,string FirstName , string LastName ,string City)
        {

            if (!ModelState.IsValid)
            {

                return View();
            }
            var obj = new Users();
            var role = new Roles();
            obj.Email = Email;
            obj.Password = SetPassword(Password);
            obj.UserName = UserName;
            obj.FirstName = FirstName;
            obj.LastName = LastName;
            obj.City = City;
            obj.Authority = "User";
            obj.Auth_id = 2;
            obj.IsActive = true;
            obj.IsDeleted = false;
           
            obj.ProfilePhoto = System.IO.File.ReadAllBytes("Content/default.jpeg");

            _ctx.UserProperties.Add(obj);
            _ctx.SaveChanges();

            //role.user_id2 = obj.id;
            //role.Authority = "User";
            //_ctx.Roles.Add(role);
            //_ctx.SaveChanges();
           
            return RedirectToRoute("HomePage");

        }
        public virtual string SetPassword(string Password)
        {
           return Password = BCrypt.Net.BCrypt.HashPassword(Password, 13);
        }
    }
}
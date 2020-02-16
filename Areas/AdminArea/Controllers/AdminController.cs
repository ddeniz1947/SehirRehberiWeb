using ClassLibrary1.Models;
using SehirRehberiApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SehirRehberiApp.Areas.AdminArea.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminArea/Admin

        public AppDbContext _ctx = new AppDbContext();

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {


            //var empDetails = (from users in _ctx.UserProperties
            //                  where users.IsDeleted == false
            //                  select new UserViewModel
            //                  {
            //                      UserName = users.UserName,
            //                      Authority = users.Authority,
            //                      Email = users.Email,
            //                      Auth_id = users.Auth_id,
            //                      IsDeleted = users.IsDeleted,
            //                      IsActive = users.IsActive,
            //                  }).ToList();
            //obj.Users = _ctx.UserProperties.ToList();
            UserViewModel users = new UserViewModel();
            users.Users = _ctx.UserProperties.Where(x=>x.IsActive == true).ToList();

            return View(users);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {


            var empDetails = (from emp in _ctx.UserProperties
                              where emp.id == id
                              select new EditViewModel
                              {
                                  Authority = emp.Authority,
                                  UserName = emp.UserName,
                                  Email = emp.Email
                              }).FirstOrDefault();

            Session.Add("Id", id);
            return View(empDetails);

        }

        [HttpPost]
        public ActionResult Edit(string UserName, string Authority, string Email)
        {
            int authorization_id;
            int userId = Convert.ToInt32(Session["Id"]);
            Users users = _ctx.UserProperties.FirstOrDefault(x => x.id == userId);
            users.UserName = UserName;

            if (Authority == "User")
            {
                authorization_id = 2;
            }
            else if (Authority == "Admin")
            {
                authorization_id = 3;
            }
            else if(Authority == "Editor")
            {
                authorization_id = 4;
            }
            else
            {
                authorization_id = 1;
            }
            users.Authority = Authority;

            users.Auth_id = authorization_id;
            users.Email = Email;
            users.IsActive = true;
            users.IsDeleted = false;

            _ctx.SaveChanges();
            return RedirectToRoute("AdminPanel");
        }

        public ActionResult Delete(int id)
        {
            Users user = _ctx.UserProperties.FirstOrDefault(x => x.id == id);
            user.IsDeleted = true;
            user.IsActive = false;
            _ctx.SaveChanges();
            return RedirectToRoute("AdminPanel");
        }
    }
}
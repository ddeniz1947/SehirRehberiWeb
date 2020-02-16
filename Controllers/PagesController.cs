using ClassLibrary1.Models;
using SehirRehberiApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SehirRehberiApp.Controllers
{
    public class PagesController : Controller
    {
        AppDbContext _ctx = new AppDbContext();

        [HttpGet]
        public ActionResult FirstPage()
        {
            PostViewModel posts = new PostViewModel();

            posts.Posts = _ctx.posts.OrderByDescending(x=>x.Id).ToList();
            posts.GetUsers = _ctx.UserProperties.ToList();
            return View(posts);
        }
        [HttpGet]
        public ActionResult ExtraImages(int Id)
        {
            ExtraImageViewModel extraImg = new ExtraImageViewModel();
            extraImg.extraImages = _ctx.extraPost.Where(x => x.ExtraPostId == Id).ToList();
            extraImg.Posts = _ctx.posts.Where(x => x.Id == Id).ToList();
            return View(extraImg);


        }
    }
}
using ClassLibrary1.Models;
using SehirRehberiApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SehirRehberiApp.Controllers
{
    public class ProfileController : Controller
    {
        AppDbContext _ctx = new AppDbContext();
        // GET: Profile
        [HttpGet]
        public ActionResult Index()
        {
            PostViewModel postViewModels = new PostViewModel();
            string ID = Request.Cookies["USERID"].Value;
            int user_id = Convert.ToInt32(ID);
            postViewModels.Posts = _ctx.posts.Where(x => x.UserId == user_id & x.IsDeleted == false).ToList();
            var dbUser = _ctx.UserProperties.FirstOrDefault(x => x.id == user_id);
            postViewModels.ProfilePhoto = dbUser.ProfilePhoto;
            postViewModels.UserName = dbUser.UserName;
            return View(postViewModels);
        }
        [HttpGet]
        public ActionResult Edit()
        {
            UserViewModel user = new UserViewModel();
            var iller = new List<SelectListItem>();
            _ctx.Sehirlers.OrderBy(s => s.SehirAdi).ToList().ForEach(s => iller.Add(new SelectListItem
            {
                Text = s.SehirAdi,
                Value = s.Id.ToString()
            }));
            string ID = Request.Cookies["USERID"].Value;
            int user_id = Convert.ToInt32(ID);
            user.Users = _ctx.UserProperties.Where(x => x.id == user_id).ToList();
            user.Cities = iller;
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase image, UserViewModel model)
        {
            string ID = Request.Cookies["USERID"].Value;
            int user_id = Convert.ToInt32(ID);
            byte[] bytes;
            var user = _ctx.UserProperties.FirstOrDefault(x => x.id == user_id);
            if (image != null)
            {
                using (BinaryReader br = new BinaryReader(image.InputStream))
                {
                    bytes = br.ReadBytes(image.ContentLength);
                }
                user.ProfilePhoto = bytes;
            }
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.FirstName = model.FirstName;

            _ctx.SaveChanges();
            return RedirectToRoute("HomePage");
        }

        public ActionResult ClickedProfile(int id)
        {
            ClickedProfileViewModel clickedUserProperties = new ClickedProfileViewModel();
            string ID = Request.Cookies["USERID"].Value;
            int followerId = Convert.ToInt32(ID);
            var clickedUser = _ctx.UserProperties.FirstOrDefault(x => x.id == id);
            var takip = _ctx.followClass.Where(x => x.FollowedId == id && x.FollowerId == followerId).ToList();
            if (takip.Count != 0)
            {
                clickedUserProperties.IsFollowing = true;
            }
            else
            {
                clickedUserProperties.IsFollowing = false;
            }
            //For ClickedUser User.cs
            clickedUserProperties.ClickedUserName = clickedUser.UserName;
            clickedUserProperties.ClickedUser_id = clickedUser.id;
            clickedUserProperties.ClickedFirstName = clickedUser.FirstName;
            clickedUserProperties.ClickedLastName = clickedUser.LastName;
            clickedUserProperties.ClickedUserCity = clickedUser.City;
            clickedUserProperties.ClickedUserPhoto = clickedUser.ProfilePhoto;
            clickedUserProperties.clickedUserPosts = _ctx.posts.Where(x => x.UserId == id & x.IsDeleted == false).ToList();

            return View(clickedUserProperties);

        }
        public ActionResult FollowingUser(int id)

        {
            string ID = Request.Cookies["USERID"].Value;
            int followerId = Convert.ToInt32(ID);
            var followingUser = _ctx.UserProperties.FirstOrDefault(x => x.id == id);
            var followerUser = _ctx.UserProperties.FirstOrDefault(x => x.id == followerId);
            Takip folloWMethod = new Takip();
            folloWMethod.FollowedId = followingUser.id;
            folloWMethod.FollowedName = followingUser.UserName;
            folloWMethod.FollowerId = followerUser.id;
            folloWMethod.FollowerName = followerUser.UserName;
            _ctx.followClass.Add(folloWMethod);
            _ctx.SaveChanges();
            return RedirectToAction("ClickedProfile", new { id = followingUser.id });

        }
        public ActionResult UnFollowUser(int followingId)
        {
            string ID = Request.Cookies["USERID"].Value;
            int followerId = Convert.ToInt32(ID);
            var followingUser = _ctx.UserProperties.FirstOrDefault(x => x.id == followingId);
            var followerUser = _ctx.UserProperties.FirstOrDefault(x => x.id == followerId);
            var follows = _ctx.followClass.FirstOrDefault(x => x.FollowedId == followingId & x.FollowerId == followerId);
            if(follows!= null)
            {
                _ctx.followClass.Remove(follows);
                _ctx.SaveChanges();
            }
            return RedirectToAction("ClickedProfile", new { id = followingUser.id });

        }
    }
}
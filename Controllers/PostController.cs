using ClassLibrary1.Models;
using SehirRehberiApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SehirRehberiApp.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        AppDbContext _ctx = new AppDbContext();
        [HttpGet]
        public ActionResult NewPost()
        {
            if (Request.Cookies["USERID"] != null)
            {
                var iller = new List<SelectListItem>();
                var ilceler = new List<SelectListItem>();

                _ctx.Sehirlers.OrderBy(s => s.SehirAdi).ToList().ForEach(s => iller.Add(new SelectListItem
                {
                    Text = s.SehirAdi,
                    Value = s.Id.ToString()
                }));
                Convert.ToInt32(iller[0].Value);
                int ID = int.Parse(iller[0].Value);
                _ctx.Ilcelers.OrderBy(s => s.IlceAdi).Where(s => s.Sehir_Id == ID).ToList().ForEach(s => ilceler.Add(new SelectListItem
                {
                    Text = s.IlceAdi,
                    Value = s.Id.ToString()
                }));

                var model = new PostViewModel
                {
                    Iller = iller,
                    Ilceler = ilceler
                };

                return View(model);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Giriş Yapmış Kullanıcı Bulunamadı Lütfen Giriş Yapınız");
                return View();
            }
        }
        public JsonResult IlcelerByIlId(string IlID)
        {
            int ID = int.Parse(IlID);
            var ilceler = _ctx.Ilcelers.Where(s => s.Sehir_Id == ID).OrderBy(s => s.IlceAdi).Select(s => new
            {
                id = s.Id,
                ilceAdi = s.IlceAdi
            }).ToList();

            return Json(ilceler, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Yeni Post Ekleme Methodu
        /// </summary>
        /// NULL KONTROLÜ YAPILMALI
        /// <param name="images"></param>
        /// <param name="model"></param>
        /// <param name="Description"></param> 
        /// <param name="deneme"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NewPost(HttpPostedFileBase image, PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRoute("NewPost");
            }

            Posts post = new Posts();
            byte[] bytes;
            int user_id;
            string ID;
            //UserId And UserName
            if (Request.Cookies["USERID"] != null)
            {
                ID = Request.Cookies["USERID"].Value;
                user_id = Convert.ToInt32(ID);
                //int user_id = Convert.ToInt32(TempData["USERID"]);
                var user = _ctx.UserProperties.FirstOrDefault(x => x.id == user_id);

                //Sehir ve İlce
                var sehir = _ctx.Sehirlers.FirstOrDefault(x => x.Id == model.IlId);
                var ilce = _ctx.Ilcelers.FirstOrDefault(x => x.Id == model.IlceId);


                using (BinaryReader br = new BinaryReader(image.InputStream))
                {
                    bytes = br.ReadBytes(image.ContentLength);
                }
                post.ImgName = Path.GetFileName(image.FileName);
                post.PostName = model.PostName;
                post.ContentType = image.ContentType;
                post.ImgData = bytes;
                post.SehirId = model.IlId;
                post.İlceId = model.IlceId;
                post.SehirAdi = sehir.SehirAdi;
                post.IlceAdi = ilce.IlceAdi;
                post.UserId = user_id;
                post.UserName = user.UserName;
                post.Description = model.Description;
                post.IsActive = true;
                post.IsDeleted = false;
                post.PostDate = DateTime.Now;
                post.ChangeDate = DateTime.Now;

                _ctx.posts.Add(post);
                _ctx.SaveChanges();
                return RedirectToRoute("FirstPage");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Giriş Yapmış Kullanıcı Bulunamadı Lütfen Giriş Yapınız");
                return View();
            }

        }
        [HttpGet]
        public ActionResult AddExtraImage(int Id)
        {
            ExtraImageViewModel images = new ExtraImageViewModel();
            var Post = _ctx.posts.FirstOrDefault(x => x.Id == Id);
            if (Post.Id != null)
            {
                images.ExtraPostName = Post.PostName;
                TempData["PostName"] = Post.PostName;
                TempData["PostId"] = Post.Id;
                TempData["user_id"] = Post.UserId;
            }
            return View(images);
        }

        [HttpPost]
        public ActionResult AddExtraImage(HttpPostedFileBase[] images, ExtraImageViewModel model)
        {

            ExtraImage extraImage = new ExtraImage();
            byte[] bytes;

            //UserId And UserName
            int PostId = Convert.ToInt32(TempData["PostId"]);
            string PostName = Convert.ToString(TempData["PostName"]);
            int user_id = Convert.ToInt32(TempData["user_id"]);
            //var ID = Request.Cookies["USERID"].Value;
            //int user_id = Convert.ToInt32(ID);



            foreach (HttpPostedFileBase image in images)
            {
                using (BinaryReader br = new BinaryReader(image.InputStream))
                {
                    bytes = br.ReadBytes(image.ContentLength);
                }
                extraImage.ExtraPostName = PostName;
                extraImage.ExtraPostId = PostId;
                extraImage.ExtraImgName = Path.GetFileName(image.FileName);
                extraImage.ExtraContentType = image.ContentType;
                extraImage.ExtraImgData = bytes;
                extraImage.ExtraUserId = user_id;
                extraImage.ExtraIsActive = true;
                extraImage.ExtraIsDeleted = false;
                extraImage.ExtraImgDate = DateTime.Now;

                _ctx.extraPost.Add(extraImage);
                _ctx.SaveChanges();

            }
            return RedirectToRoute("FirstPage");



        }

        public ActionResult Delete(int id)
        {
            var post = _ctx.posts.FirstOrDefault(x => x.Id == id);
            post.IsDeleted = true;
            post.IsActive = false;
            _ctx.SaveChanges();
            return RedirectToRoute("Profile");
        }


    }
}
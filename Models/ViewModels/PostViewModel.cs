using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SehirRehberiApp.Models.ViewModels
{
    public class PostViewModel
    {
        //public int Id { get; set; }
        //public string SehirAdi { get; set; }
        //public string IlceAdi { get; set; }
        //public string Description { get; set; }
        public int Id { get; set; }
         
        [MaxLength(40)]
        [Required(ErrorMessage = "Lütfen Albüm için Bir İsim giriniz.")]
        public string PostName { get; set; }
        public int IlId { get; set; }
        public int IlceId { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        //For Cities
        public List<Sehirler> Sehirlers { get; set; }
        public List<Ilceler> Ilcelers { get; set; }
        public List<Posts> Posts { get; set; }
        public List<Users> GetUsers { get; set; }

        public List<SelectListItem> Iller { get; set; }
        public List<SelectListItem> Ilceler { get; set; }

        //For Image
       
        public int ImgID { get; set; }
        public string ImgName { get; set; }
        public string ImgAlt { get; set; }
        //[MaxLength(40)]
        //[Required(ErrorMessage = "Lütfen Albümünüz İçin Bir Kapak Fotoğrafı seçiniz.")]
        public byte[] ImgData { get; set; }
        public string ContentType { get; set; }

        public byte[] ProfilePhoto { get; set; }
    }
}
using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SehirRehberiApp.Models.ViewModels
{
    public class ExtraImageViewModel
    {
        public int ExtraImgID { get; set; }
        public string ExtraImgName { get; set; }
        public string ExtraImgAlt { get; set; }
        public byte[] ExtraImgData { get; set; }
        public string ExtraContentType { get; set; }
        public int ExtraPostId { get; set; }
        public string ExtraPostName { get; set; }
        public int ExtraUserId { get; set; }

        //User And Cities
        public List<Posts> Posts { get; set; }
        public string Description { get; set; }
        public List<ExtraImage> extraImages {get; set;}
    }
}
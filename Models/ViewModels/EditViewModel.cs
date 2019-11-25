using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SehirRehberiApp.Models.ViewModels
{
    public class EditViewModel
    {
        [MaxLength(40)]
        [Required(ErrorMessage = "Lütfen Bir Kullanıcı Adı Giriniz.")]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Authority { get; set; }
        public string Email { get; set; }
        public List<Users> Users { get; set; }
    }
}

using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SehirRehberiApp.Models.ViewModels
{
    public class UserViewModel
    {
        [MaxLength(40)]
        [Required(ErrorMessage = "Lütfen Bir Kullanıcı Adı Giriniz.")]
        public string UserName { get; set; }
        [MaxLength(40)]
        [Required(ErrorMessage = "Lütfen Bir Kullanıcı Adı Giriniz.")]
        public string Password { get; set; }
        [MaxLength(40)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string FirstName { get; set; }
        [MaxLength(40)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string LastName { get; set; }
        [MaxLength(40)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string City { get; set; }
        [MaxLength(40)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string Email { get; set; }

        public string Authority { get; set; }
        public List<Users> Users { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int Auth_id { get; set; }
        public static void FakeHash()
        {
            BCrypt.Net.BCrypt.HashPassword("", 13);
        }

   


    }
}
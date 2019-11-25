using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SehirRehberiApp.Models.ViewModels
{
    public class SehirlerViewModel
    {
        [Required]
        public int Id { get; set; }
        public string SehirAdi { get; set; }
    }
}
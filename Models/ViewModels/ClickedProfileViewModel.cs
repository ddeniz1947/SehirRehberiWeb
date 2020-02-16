using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SehirRehberiApp.Models.ViewModels
{
    public class ClickedProfileViewModel
    {
        public int ClickedUser_id { get; set; }
        public string ClickedUserName { get; set; }
        public string ClickedFirstName { get; set; }
        public string ClickedLastName { get; set; }
        public byte[] ClickedUserPhoto { get; set; }
        public string ClickedUserCity { get; set; }
        public List<Posts> clickedUserPosts { get; set; }

        public bool IsFollowing { get; set; }


    }
}
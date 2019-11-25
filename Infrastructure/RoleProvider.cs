using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ClassLibrary1.Models;
using SehirRehberiApp.Models;

namespace SehirRehberiApp.Infrastructure
{
    public class RoleProvider : System.Web.Security.RoleProvider
    {
        public override string ApplicationName { get; set; }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public override string[] GetRolesForUser(string username)
        {

            AppDbContext db = new AppDbContext();

            var objUser = db.UserProperties.FirstOrDefault(x => x.UserName == username);
            if (objUser == null)
            {
                return null;
            }
            else
            {

                var ret2 = db.Roles.FirstOrDefault(x => x.id == objUser.Auth_id);
                if (ret2 == null)
                {
                    return null;
                }
                else
                {
                    string[] ret = new string[1] { ret2.Authority };
                    return ret;
                }

            }

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }



    }
}
using StagesCycling.DAL.Context;
using StagesCycling.Web.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StagesCycling.DAL.Entities;

namespace StagesCycling.Web.Util
{
    public class RoleInitializer
    {
        public void CreateDefaultRolesAndUsers()
        {
            //ApplicationDbContext context = new ApplicationDbContext();

            //var roleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context));
            //var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            //if (!roleManager.RoleExists("Administrator"))
            //{
            //    var role = new IdentityRole()
            //    {
            //        Name = "Administrator"
            //    };

            //    roleManager.Create(role);

            //    //Create a Admin super user who will maintain the website                  
            //    var user = new ApplicationUser
            //    {
            //        UserName = "yulia.furta@gmail.com",
            //        Email = "yulia.furta@gmail.com",
            //        FirstName = "Yulia",
            //        LastName = "Furta"
            //    };

            //    string userPassword = "Qwerty1_";

            //    var addedUser = userManager.Create(user, userPassword);

            //    if (addedUser.Succeeded)
            //    {
            //        var result = userManager.AddToRole(user.Id, "Administrator");
            //    }
            //}

            //if (!roleManager.RoleExists("User"))
            //{
            //    var role = new IdentityRole
            //    {
            //        Name = "User"
            //    };

            //    roleManager.Create(role);
            //}
        }
    }
}
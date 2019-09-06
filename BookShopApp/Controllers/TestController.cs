using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Validation;

namespace BookShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public readonly RoleManager<IdentityRole> role;
        private readonly UserManager<ApplicationUser> userManager;

        public TestController(RoleManager<IdentityRole> role,UserManager<ApplicationUser> userManager)
        {
            this.role = role;
            this.userManager = userManager;
        }

        public async Task Get()
        {
//           await role.CreateAsync(new IdentityRole()
//            {
//                Name = "admin"
//            });
//            await role.CreateAsync(new IdentityRole()
//            {
//                Name = "manager"
//            });
//            await role.CreateAsync(new IdentityRole()
//            {
//                Name = "customer"
//            });

          var user = await  userManager.CreateAsync(new ApplicationUser()
            {
                Email = "akash@gmail.com",
                PhoneNumber = "01684750862",
                UserName = "akash@gmail.com"
            },"Rcis123$..");

            if (user.Succeeded)
            {
                var nowInsertedUser = await userManager.FindByEmailAsync("akash@gmail.com");
                var roleInsert = await userManager.AddToRoleAsync(nowInsertedUser, "admin");
            }
        }

        [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
        [HttpGet("get1")]
        public string Get1()
        {
            return "hello world";
        }


        [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme,Roles = "admin")]
        [HttpGet("get2")]
        public string Get2()
        {
            return "sdfds";
        }


        [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme,Roles = "manager")]
        [HttpGet("get3")]
        public string Get3()
        {
            return "sdfds";

        }
    }
}
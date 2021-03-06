﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TrophyFish.Model;
using Microsoft.AspNetCore.Identity;
using TrophyFish.Api.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrophyFish.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public AccountController(
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterVM model)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.UserName };
                user.StatusID = 1;

                //TODO: remove that 
                if(!_applicationDbContext.UserStatuses.Any(s => s.ID == 1))
                {
                    UserStatusDict status = new UserStatusDict { ID = 1, Name = "Test Status" };
                    _applicationDbContext.UserStatuses.Add(status);

                    _applicationDbContext.SaveChanges();
                }

                var result = await _userManager.CreateAsync(user, model.Password);

                //TODO: remove that
                if (model.IsAdmin)
                {
                    if (!_roleManager.Roles.Any(r => r.Name == "TestRole"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole { Name = "TestRole" });
                    }

                    await _userManager.AddToRoleAsync(user, "TestRole");
                }

                if (result.Succeeded)
                {
                    return Ok();
                }
            }

            // If we got this far, something failed.
            return BadRequest(ModelState);
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Account", "value" };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}

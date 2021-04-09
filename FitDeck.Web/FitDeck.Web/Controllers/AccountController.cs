using FitDeck.Models.Account;
using FitDeck.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitDeck.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUserIdentity> _userManager;
        private readonly SignInManager<ApplicationUserIdentity> _signInManager;

        public AccountController(
            ITokenService tokenService,
            UserManager<ApplicationUserIdentity> userManager,
            SignInManager<ApplicationUserIdentity> signInManager 
            )
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApplicationUser>> Register(ApplicationUserCreate applicationUserCreate)
        {
            var applicationUserIdentity = new ApplicationUserIdentity()
            {
                UserName = applicationUserCreate.Username,
                Email = applicationUserCreate.Email,
                FirstName = applicationUserCreate.FirstName,
                LastName = applicationUserCreate.LastName,
                Height = applicationUserCreate.Height,
                Weight = applicationUserCreate.Weight,
                DateOfBirth = applicationUserCreate.DOB
            };

            var result = await _userManager.CreateAsync(applicationUserIdentity, applicationUserCreate.Password);

            if (result.Succeeded)
            {
                applicationUserIdentity = await _userManager.FindByNameAsync(applicationUserCreate.Username);

                ApplicationUser applicationUser = new ApplicationUser()
                {
                    ApplicationUserId = applicationUserIdentity.ApplicationUserId,
                    UserName = applicationUserIdentity.UserName,
                    Email = applicationUserIdentity.Email,
                    FirstName = applicationUserIdentity.FirstName,
                    LastName = applicationUserIdentity.LastName,
                    DateOfBirth = applicationUserIdentity.DateOfBirth,
                    Token = _tokenService.CreatToken(applicationUserIdentity)
                };

                return Ok(applicationUser);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApplicationUser>> Login(ApplicationUserLogin applicationUserLogin)
        {
            var applicationUserIdentity = await _userManager.FindByNameAsync(applicationUserLogin.Username);

            if(applicationUserIdentity != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(applicationUserIdentity, applicationUserLogin.Password, false);

                if (result.Succeeded)
                {
                    ApplicationUser applicationUser = new ApplicationUser
                    {
                        ApplicationUserId = applicationUserIdentity.ApplicationUserId,
                        UserName = applicationUserIdentity.UserName,
                        Email = applicationUserIdentity.Email,
                        FirstName = applicationUserIdentity.FirstName,
                        LastName = applicationUserIdentity.LastName,
                        DateOfBirth = applicationUserIdentity.DateOfBirth,
                        Token = _tokenService.CreatToken(applicationUserIdentity)
                    };
                    return Ok(applicationUser);
                }
            }

            return BadRequest("Invalid Login attempt.");
        }
    }
}

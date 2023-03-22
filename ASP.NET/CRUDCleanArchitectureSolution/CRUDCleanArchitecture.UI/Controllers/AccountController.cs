using CRUDCleanArchitecture.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using CrudExample.Controllers;
using Microsoft.AspNetCore.Identity;
using CRUDCleanArchitecture.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using CRUDCleanArchitecture.Core.Enums;

namespace CRUDCleanArchitecture.UI.Controllers
{
    [Route("[controller]/[action]")]
    [AllowAnonymous] // contrast of Policy -> does not require authorization
    // use policy to allow actions
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AccountController(
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        [HttpGet]
        //[Authorize("NotAuthorized")]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize("NotAuthorized")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            // Check for validation errors
            if (ModelState.IsValid == false)
            {
                ViewBag.Errors = ModelState.Values
                    .SelectMany(temp => temp.Errors)
                    .Select(temp => temp.ErrorMessage);
                return View(registerRequest);
            }

            ApplicationUser user = new()
            {
                Email = registerRequest.Email,
                PhoneNumber = registerRequest.Phone,
                UserName = registerRequest.Email,
                PersonName = registerRequest.PersonName,
                
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerRequest.Password);

            if (result.Succeeded)
            {
                if (registerRequest.UserType == UserTypeOptions.Admin)
                {
                    if (await _roleManager.FindByNameAsync(UserTypeOptions.Admin.ToString()) is null)
                    {
                        // create role
                        ApplicationRole applicationRole = new() { Name = UserTypeOptions.Admin.ToString() };
                        await _roleManager.CreateAsync(applicationRole);
                    }

                    // add role to user
                    await _userManager.AddToRoleAsync(user, UserTypeOptions.Admin.ToString());
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, UserTypeOptions.User.ToString());
                }

                
                // create cookies
                // Sign-in
                // create checkbox to attribute to isPErsistent
                // keep me signed in?
                await _signInManager.SignInAsync(user, true);

                return RedirectToAction(nameof(PersonsController.Index), "Persons");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("Register", error.Description);
                }

                return View(registerRequest);
            }
        }

        [HttpGet]
        //[Authorize("NotAuthorized")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[Authorize("NotAuthorized")]
        public async Task<IActionResult> Login(LoginRequest loginRequest, string? ReturnUrl)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.Errors = ModelState.Values
                                   .SelectMany(temp => temp.Errors)
                                   .Select(temp => temp.ErrorMessage);
                return View(loginRequest);
            }

            // keep signed in?
            var result = await _signInManager
                .PasswordSignInAsync(loginRequest.Email, loginRequest.Password, isPersistent: true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Admin
                ApplicationUser user = await _userManager.FindByEmailAsync(loginRequest.Email);
                if (user != null)
                {
                    if (await _userManager.IsInRoleAsync(user, UserTypeOptions.Admin.ToString()))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                }

                if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                {
                    return LocalRedirect(ReturnUrl);
                }
                return RedirectToAction(nameof(PersonsController.Index), "Persons");
            }
            else
            {
                ModelState.AddModelError("Login", "Invalid email or password");
                return View(loginRequest);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(PersonsController.Index), "Persons");
        }
   
        public async Task<IActionResult> IsEmailAlreadyRegistered(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    
    }
}

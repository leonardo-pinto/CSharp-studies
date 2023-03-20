using CRUDCleanArchitecture.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using CRUDCleanArchitecture.UI.Controllers;
using CrudExample.Controllers;
using Microsoft.AspNetCore.Identity;
using CRUDCleanArchitecture.Core.Domain.IdentityEntities;

namespace CRUDCleanArchitecture.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
      

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

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
    }
}

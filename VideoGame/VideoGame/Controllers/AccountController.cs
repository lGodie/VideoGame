using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGame.Data;
using VideoGame.Helpers;
using VideoGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace VideoGame.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public AccountController(DataContext dataContext,
            IConfiguration configuration,
            IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrecta.");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return this.RedirectToAction("Index", "Home");

        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AddUserDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.AddUser(model);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "El email esta en uso.");
                    return View(model);

                }

                await _dataContext.SaveChangesAsync();

                ViewBag.Message = "Usuario Regitrado exitosamente";

                return View();
            }
            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> ChangeUser()
        {
            var user = await _userHelper.GetUserByEmailAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            var model = new EditUserDto
            {
                Nombres = user.Nombres,
                Apellidos = user.Apellidos
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeUser(EditUserDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(User.Identity.Name);

                user.Nombres = model.Nombres;
                user.Apellidos = model.Apellidos;

                await _userHelper.UpdateUserAsync(user);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}

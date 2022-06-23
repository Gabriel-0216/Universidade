using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UsuarioController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity is not null && User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return View(usuarioViewModel);
            var usuarioExiste = await _userManager.FindByEmailAsync(usuarioViewModel.Email);
            if (usuarioExiste is null)
            {
                ModelState.AddModelError("", "Usuário não cadastrado.");
                return View(usuarioViewModel);
            }
            var signIn = await _signInManager.PasswordSignInAsync(usuarioExiste, usuarioViewModel.Password, false, false);
            if (!signIn.Succeeded)
            {
                ModelState.AddModelError("", "Email e senha não conferem!");
                return View(usuarioViewModel);
            }

            return RedirectToAction("Index", "Home");

        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
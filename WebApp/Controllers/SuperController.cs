using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.ViewModels.SuperViewModel;

namespace WebApp.Controllers
{
    [Authorize(Roles = "SUPER")]
    public class SuperController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public SuperController(RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Usuarios()
        {
            var usuarios = await _userManager.Users.ToListAsync();
            return View(usuarios);
        }

        [HttpGet]
        public async Task<IActionResult> Funcoes()
        {
            var funcoes = await _roleManager.Roles.ToListAsync();
            return View(funcoes);
        }
        [HttpGet]
        public async Task<IActionResult> AtribuirFuncao(string usuarioId)
        {
            var model = new AtribuirFuncaoViewModel(usuarioId)
            {
                Roles = await _roleManager.Roles.ToListAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AtribuirFuncao(AtribuirFuncaoViewModel model)
        {
            var usuario = await _userManager.Users.FirstOrDefaultAsync(p => p.Id.Equals(model.UsuarioId));
            var role = await _roleManager.Roles.FirstOrDefaultAsync(p => p.Id.Equals(model.RoleId));
            if (usuario is null && role is null) return View(model);

            var adicionado = await _userManager.AddToRoleAsync(usuario, role.Name);
            if (adicionado.Succeeded) return RedirectToAction("Index", "Home");
            return View(model);
        }
    }
}
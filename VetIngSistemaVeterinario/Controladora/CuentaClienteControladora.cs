using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using VetIngSistemaVeterinario.Data;
using VetIngSistemaVeterinario.Modelo.Identity;
using VetIngSistemaVeterinario.Modelo;
using VetIngSistemaVeterinario.Modelo.ViewModel;

namespace VetIngSistemaVeterinario.Controladora
{
    public class CuentaClienteControladora : Controller

    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly ApplicationDbContext _context;

        public CuentaClienteControladora(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult RegistrarCliente()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarCliente(ClienteRegistroViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuario = new Usuario
            {
                UserName = model.Email,
                Email = model.Email,
                NombreUsuario = model.Email,
                Clave = model.Password 
            };

            var result = await _userManager.CreateAsync(usuario, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return View(model);
            }

            await _userManager.AddToRoleAsync(usuario, "Cliente");

            var cliente = new Cliente
            {
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Dni = model.Dni,
                Telefono = model.Telefono,
                Direccion = model.Direccion,
                UsuarioId = usuario.Id
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            await _signInManager.SignInAsync(usuario, isPersistent: false);

            return RedirectToAction("Index", "Home");
        }
    }
}

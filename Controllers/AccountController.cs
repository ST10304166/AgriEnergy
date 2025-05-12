using AgriEnergy.Data;
using AgriEnergy.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergy.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var farmer = await _context.Farmers
                .FirstOrDefaultAsync(f => f.Email == model.Email && f.Password == model.Password);
            if (farmer != null)
            {
                await SignInUser(farmer.Id.ToString(), farmer.Name, farmer.Email, "Farmer");
                return RedirectToAction("MyProducts", "Products");
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Email == model.Email && e.Password == model.Password);
            if (employee != null)
            {
                await SignInUser(employee.Id.ToString(), employee.Name, employee.Email, "Employee");
                return RedirectToAction("Dashboard", "Employee");
            }

            ModelState.AddModelError("", "Invalid login.");
            return View(model);
        }

        private async Task SignInUser(string userId, string name, string email, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, email),
                new Claim("Role", role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied() => View();
    }
}
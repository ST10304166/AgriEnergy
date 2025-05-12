using AgriEnergy.Models;
using AgriEnergy.Utilities;
using AgriEnergy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AgriEnergy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", employee);
            }

            employee.Password = PasswordHasher.HashPassword(employee.Password);
            employee.Role = "Employee";

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Employee registered successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

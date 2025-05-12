using AgriEnergy.Data;
using AgriEnergy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgriEnergy.Controllers
{
    [Authorize(Policy = "EmployeeOnly")]
    public class FarmersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FarmersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Farmer farmer)
        {
            if (!ModelState.IsValid)
            {
                // 🔍 Log model validation errors to console for debugging
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        Console.WriteLine($"Validation error: {error.ErrorMessage}");
                    }
                }

                // Return view again with validation messages
                return View(farmer);
            }

            farmer.Role = "Farmer";
            farmer.RegistrationDate = DateTime.Now;
            _context.Farmers.Add(farmer);
            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard", "Employee");
        }
    }
}

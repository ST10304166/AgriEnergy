using AgriEnergy.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergy.Controllers
{
    [Authorize(Policy = "EmployeeOnly")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Dashboard()
        {
            var farmers = await _context.Farmers.ToListAsync();
            return View(farmers);
        }

        public async Task<IActionResult> AllProducts(string? searchString, string? category, DateTime? startDate, DateTime? endDate)
        {
            var products = _context.Products.Include(p => p.Farmer).AsQueryable();

            // Filter by name
            if (!string.IsNullOrEmpty(searchString))
                products = products.Where(p => p.Name.Contains(searchString));

            // Filter by category
            if (!string.IsNullOrEmpty(category))
                products = products.Where(p => p.Category == category);

            // Filter by date range
            if (startDate.HasValue)
                products = products.Where(p => p.ProductionDate >= startDate.Value);

            if (endDate.HasValue)
                products = products.Where(p => p.ProductionDate <= endDate.Value);

            return View(await products.ToListAsync());
        }
    }
}
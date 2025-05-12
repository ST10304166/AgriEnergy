using AgriEnergy.Data;
using AgriEnergy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AgriEnergy.Controllers
{
    [Authorize(Policy = "FarmerOnly")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> MyProducts()
        {
            var farmerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var products = await _context.Products
                .Where(p => p.FarmerId == farmerId)
                .ToListAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.FarmerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MyProducts));
            }

            return View(product);
        }
    }
}

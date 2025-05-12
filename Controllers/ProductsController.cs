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

        // GET: Products/MyProducts
        public async Task<IActionResult> MyProducts()
        {
            var farmerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var products = await _context.Products
                .Where(p => p.FarmerId == farmerId)
                .OrderByDescending(p => p.ProductionDate)
                .ToListAsync();

            return View(products);
        }

        // GET: Products/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    product.FarmerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Product added successfully!";
                    return RedirectToAction(nameof(MyProducts));
                }
                catch
                {
                    ModelState.AddModelError("", "An error occurred while saving the product.");
                }
            }
            else
            {
                // 👇 Add this to see WHY it's invalid (only during testing)
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
            }

            return View(product);
        }
    }
}
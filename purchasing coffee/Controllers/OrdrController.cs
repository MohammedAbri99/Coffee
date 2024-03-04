using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using purchasing_coffee.Models.Data;
using purchasing_coffee.Models.Entities;

namespace purchasing_coffee.Controllers
{
    public class OrdrController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdrController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult OrderCoffee(int id)
        {

            Coffee coffee = _context.coffees.Find(id);
            ViewBag.coffeeId = id;
            ViewBag.coffeeName = coffee.Name;
            ViewBag.coffeeQuant = coffee.Quantity;
            ViewBag.coffeePrice = coffee.price;
            ViewBag.coffeeImg = coffee.ImageUrl;
            return View();
        }

        [HttpPost]
        public IActionResult OrderCoffee(Order model)
        {
            Coffee coffee = _context.coffees.Find(model.coffeeId);

            model.total_price = coffee.price * model.quantity;
            ModelState.Remove("Coffee");
            ModelState.Remove("CoffeeId");
            if (ModelState.IsValid)
            {
                _context.orders.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.coffeeId = coffee.CoffeeId;
                ViewBag.coffeeName = coffee.Name;
                ViewBag.coffeeQuant = coffee.Quantity;
                ViewBag.coffeePrice = coffee.price;
                ViewBag.coffeeImg = coffee.ImageUrl;
                return View(model);
            }

        }

    }
}

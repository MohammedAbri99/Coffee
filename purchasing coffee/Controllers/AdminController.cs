using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using purchasing_coffee.Helper;
using purchasing_coffee.Models.Data;
using purchasing_coffee.Models.Entities;
using System.Runtime.CompilerServices;

namespace purchasing_coffee.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult getCoffee()
        {
            var coffees = _context.coffees.ToList();
            return View("Coffee",coffees);
        }

        // This action an a get add coffee to add a coffee to database and its return the view that have a form
        public IActionResult AddCoffee()
        {
            return View();
        }

        //this a post add coffee action and this will be applied when the user click on submit button
        [HttpPost]
        public IActionResult AddCoffee(Coffee model)
        {
            model.ImageUrl = DocumentConf.DocumentUpload(model.Image, "image");
            if (ModelState.IsValid)
            {
                _context.coffees.Add(model);
                _context.SaveChanges();
                return RedirectToAction("getCoffee");
            }
            else
            {
                return View(model);
            }
        }

        // this action for delete coffee its recevie id from view.
        public IActionResult Delete(int id)
        {
            var coffee = _context.coffees.Find(id);
            _context.coffees.Remove(coffee);
            _context.SaveChanges();
            return RedirectToAction("getCoffee");
        }

        //the Edit get action to display the information of a coffee to edit 
        public IActionResult Edit(int id)
        {
            var coffee = _context.coffees.Find(id);
            return View(coffee);
        }

        [HttpPost]
        public IActionResult Edit(Coffee coffee)
        {
            if (coffee.Image != null)
            {
                coffee.ImageUrl = DocumentConf.DocumentUpload(coffee.Image, "image");
            }
            else
            {                 
                var existingCoffee = _context.coffees.Find(coffee.CoffeeId);
                coffee.ImageUrl = existingCoffee.ImageUrl;
            }

            if (ModelState.IsValid)
            {

                var trackedCoffee = _context.ChangeTracker.Entries<Coffee>()
                    .FirstOrDefault(e => e.Entity.CoffeeId == coffee.CoffeeId);
                if (trackedCoffee != null)
                {
                    _context.Entry(trackedCoffee.Entity).State = EntityState.Detached;
                }


                _context.Entry(coffee).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("getCoffee");
            }
            else
            {
                return View(coffee);
            }
        }
    }
}

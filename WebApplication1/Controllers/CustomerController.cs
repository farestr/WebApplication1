using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly Context _context;
        public CustomerController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var customers = _context.customer.Include(c => c.cities).ToList();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = _context.customer.Where(x => x.id == id).SingleOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(int id, Customer model)
        {
            var data = _context.customer.FirstOrDefault(x => x.id == id);
            if (data != null)
            {
                data.name = model.name;
                data.phone = model.phone;
                data.CityID = model.CityID;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _context.customer.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            var data = _context.customer.FirstOrDefault(x => x.id == customer.id);
            if (data != null)
            {
                _context.Remove(data);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    
}
}

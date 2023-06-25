using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    //dependecie injection
    public class CitiesController : Controller
    {
        private readonly Context _context;
        public CitiesController(Context context) {
            _context = context;
        }
        public IActionResult Index()
        {
            var citiesList = _context.Cities.ToList();
            return View(citiesList);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Cities cities)
        {
            _context.Add(cities);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult Update(int CityID)
        {
            var data = _context.Cities.Where(x => x.CityID == CityID).SingleOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(int CityID, Cities model)
        {
            var data = _context.Cities.FirstOrDefault(x => x.CityID == CityID);
            if (data != null)
            {
                data.CityName = model.CityName;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else {
                return View();
            }
            
        }


        [HttpGet]
        public IActionResult Delete(int CityId)
        {
            var data = _context.Cities.Find(CityId);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(Cities cities)
        {
            var data = _context.Cities.FirstOrDefault(x => x.CityID == cities.CityID);
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

using CodeFirstProject.Contexts;
using CodeFirstProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly DbProjectContext _dbProjectContext;
        public ProductController(DbProjectContext dbProjectContext)
        {
            _dbProjectContext = dbProjectContext;
        
    }

        public IActionResult Index()
        {
            var model = _dbProjectContext.Products.ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbProjectContext.Products.Add(product);
                _dbProjectContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int id)
        {
            var product = _dbProjectContext.Products.Find(id);
            _dbProjectContext.Products.Remove(product);
            _dbProjectContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _dbProjectContext.Products.Find(id);
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(Product product)

        {
            _dbProjectContext.Update(product);
            _dbProjectContext.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}

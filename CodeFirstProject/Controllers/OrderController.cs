using CodeFirstProject.Contexts;
using CodeFirstProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly DbProjectContext _dbProjectContext;
        private Order order;

        public OrderController(DbProjectContext dbProjectContext)
        {
            _dbProjectContext = dbProjectContext;
        }
        public IActionResult Index()
        {
            var model = _dbProjectContext.Orders.ToList();
            return View(model);
        }

        public IActionResult Create()//gerek var mı?
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
            _dbProjectContext.Orders.Add(order);
            _dbProjectContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var model = _dbProjectContext.Orders.Find(id);
            _dbProjectContext.Orders.Remove(order);
            _dbProjectContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

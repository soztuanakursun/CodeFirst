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
        private Order OrderId;

        public OrderController(DbProjectContext dbProjectContext)
        {
            _dbProjectContext = dbProjectContext;
        }

        public IActionResult Index()
        {
            var model = _dbProjectContext.Orders.ToList();
            return View(model);
           
           
        }

        public IActionResult Create() { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {

            _dbProjectContext.Orders.Add(order);
            _dbProjectContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var order = _dbProjectContext.Orders.Find(Id);
            _dbProjectContext.Orders.Remove(order);
            _dbProjectContext.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var order = _dbProjectContext.Orders.Find(id);
            if (order != null)
            {
                return View(order);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(Order order)

        {
            _dbProjectContext.Update(order);
            _dbProjectContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }

    }


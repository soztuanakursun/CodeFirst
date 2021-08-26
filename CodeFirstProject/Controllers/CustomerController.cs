using CodeFirstProject.Contexts;
using CodeFirstProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CodeFirstProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DbProjectContext _dbProjectContext;

        public CustomerController(DbProjectContext dbProjectContext)
        {
            _dbProjectContext = dbProjectContext;
        }

        public IActionResult Index()
        {
            var model = _dbProjectContext.Customers.ToList();

            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _dbProjectContext.Customers.Add(customer);
                _dbProjectContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }



        public IActionResult Delete(int id)
        {
            var customer = _dbProjectContext.Customers.Find(id);

            _dbProjectContext.Customers.Remove(customer);
            _dbProjectContext.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int Id)
        {
            // Id sini formdan alıyoruz Customers/Edit/2 burada 2 Id oluyor.
            var customer = _dbProjectContext.Customers.Find(Id);
            // yukarıda Customer.Find dedik ve Id yi verdik o da bize eğer varsa Id si 2 olan biri onu alıp geldi.

            if (ModelState.IsValid)
            {
                return View(customer);
            }
            else
            {
                return RedirectToAction("Index"); // eğer kayıt yok ise index e göndersin.
                // tabi burada normalde yoksa, adama öyle kayıt yok falan demek daha doğru : )
            }
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                // şimdi o ekrandan değişikliği yaptık ve buraya post edeceğiz, sonrasında
                // burada update edip db ye kaydetmemiz gerekli.
                _dbProjectContext.Update(customer);
                _dbProjectContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            // tabi burada bir sürü validasyon falan yapılabilir, kurallar falan vardır ama bizde yok şu anda.
        }
        
    } 

}


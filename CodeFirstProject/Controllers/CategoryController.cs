using CodeFirstProject.Contexts;
using CodeFirstProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CodeFirstProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DbProjectContext _dbProjectContext;

        public CategoryController(DbProjectContext dbProjectContext)
        {
            _dbProjectContext = dbProjectContext;
        }

        public IActionResult Index()
        {
            var categories = _dbProjectContext.Categories.ToList();
            // tüm kategorileri istedik ve sonrasında gelen sonuç kümesi bir
            // kategori listesi olduğundan onu döndün View içinde

            // List<Category> tipinde döndük yani aslında.
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbProjectContext.Categories.Add(category);
                _dbProjectContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            var category = _dbProjectContext.Categories.Find(id);
            _dbProjectContext.Categories.Remove(category);
            _dbProjectContext.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Edit(int id)
        {
            // Id sini formdan alıyoruz Customers/Edit/2 burada 2 Id oluyor.
            var category = _dbProjectContext.Categories.Find(id);
            // yukarıda Customer.Find dedik ve Id yi verdik o da bize eğer varsa Id si 2 olan biri onu alıp geldi.

            if (ModelState.IsValid)
            {
                return View(category);
            }
            else
            {
                return RedirectToAction("Index"); // eğer kayıt yok ise index e göndersin.
                                                  // tabi burada normalde yoksa, adama öyle kayıt yok falan demek daha doğru : )
            }
        }

        
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                // şimdi o ekrandan değişikliği yaptık ve buraya post edeceğiz, sonrasında
                // burada update edip db ye kaydetmemiz gerekli.
                _dbProjectContext.Update(category);
                _dbProjectContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            // tabi burada bir sürü validasyon falan yapılabilir, kurallar falan vardır ama bizde yok şu anda.
        }
    }
}


    






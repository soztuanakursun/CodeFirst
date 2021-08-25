using CodeFirstProject.Contexts;
using CodeFirstProject.Entities;
using Microsoft.AspNetCore.Mvc;
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
            _dbProjectContext.Categories.Add(category);
            _dbProjectContext.SaveChanges();

            return RedirectToAction("Index");
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
            var category = _dbProjectContext.Categories.Find(id);
            if (category != null) 
            {
                return View(category);
            }
            else
            {
                return RedirectToAction("Index"); 
                
            }
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
          
            _dbProjectContext.Update(category);
            _dbProjectContext.SaveChanges();

            return RedirectToAction("Index");
            
        }
    }

}

    


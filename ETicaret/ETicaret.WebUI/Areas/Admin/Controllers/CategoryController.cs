using ETicaret.Model.Context;
using ETicaret.Service.DbService;
using ETicaret.Core.Service;
using ETicaret.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Intercom.Data;

namespace ETicaret.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IDbService<Category> _db;
        public CategoryController(IDbService<Category> db)
        {
            _db = db;
          
        }


        // Kategoriler Liste olarakss gösterir
        public IActionResult Index()
        {
            return View(_db.GetAll());
        }
       
        // Kategori Ekleme Sayfasını gösterir
        public IActionResult Add()
        {
            return View();
        }

        // Kategori ekler
        [HttpPost]
        public IActionResult Add(Category c)
        {
            if (c.CategoryName != null && c.CategoryDescription != null)
            {
                return _db.Add(c) ? RedirectToAction("Index") : View();
            }

            ViewBag.CategoryAddError = "Yeni Kategori için Bütün Değerleri Giriniz";
            return View();
        }

        // Güncellemeyi gösterir
        public IActionResult Update(int id)
        {
            return View(_db.GetById(id));
        }

        // Httppost ile güncelleme yapar
        [HttpPost]
        public IActionResult Update(Category c)
        {
            if (c.CategoryName != null && c.CategoryDescription != null)
            {
                return _db.Update(c) ? RedirectToAction("Index") : View();
            }

            ViewBag.CategoryUpdateError = "Kategori güncellemek için bütün değerleri giriniz";
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
               
                return _db.Delete(_db.GetById(id)) ? RedirectToAction("Index") : View();
            }

            return View();
        }
    }
}

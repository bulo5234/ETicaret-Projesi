
using ETicaret.Core.Service;
using ETicaret.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IDbService<Product> _db;

        public CategoryController(IDbService<Product> db)
        {
            _db = db;
        }

        public IActionResult Products(int id)
        {
            return View(_db.GetAll().Where(x => x.CategoryId == id).ToList());
        }
    }
}

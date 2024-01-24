
using ETicaret.Core.Service;
using ETicaret.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IDbService<Product> _db;

        public ProductController(IDbService<Product> db)
        {
            _db = db;
        }

        public IActionResult Detail(int id)
        {
            return View(_db.GetById(id));
        }
    }
}


using ETicaret.Core.Service;
using ETicaret.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbService<Category> _db;

        public HomeController(IDbService<Category> db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.GetAll());
        }

    }
}

using ETicaret.Core.Service;
using ETicaret.Model.Context;
using ETicaret.Model.Entities;
using Intercom.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Admin = ETicaret.Model.Entities.LoginGiris;
using System.Security.Claims;

namespace ETicaret.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly ETicaretContext _db;

        public LoginController(ETicaretContext db)
        {
            _db = db;
        }

        
        public IActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GirisYap(LoginGiris p)
        {

            var bilgiler = _db.Admins.FirstOrDefault(x => x.Kullanıcı == p.Kullanıcı && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.Kullanıcı)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");

            }
            return View();
        }

    }


}

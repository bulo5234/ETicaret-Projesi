using ETicaret.Core.Service;
using ETicaret.Model.Context;
using ETicaret.Service.DbService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;    




namespace ETicaret.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
            {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMvc();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/Admin/Login/GirisYap/";
            });

            builder.Services.AddDbContext<ETicaretContext>(options => options.UseSqlServer("Server=DESKTOP-8I6AJOR;Database=ETicaret;TrustServerCertificate=True;Integrated security=true;"));
            
            // Dependency Injection(Baðýmlýlýklarýn Enjekte Edilmesi) ile IDbService türünde bir nesne örneði oluþturmak istediðimizde geriye bize CoreDbService sýnýfýna ait bir nesne örneði döner ve sorgularýmýzý aslýnda bu sýnýf üzerinden yazabilir hale geliriz.
            builder.Services.AddScoped(typeof(IDbService<>), typeof(CoreDbService<>));

            builder.Services.AddSession(); // Session oturum yönetimi servis olarak ekle
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();
          

            app.UseRouting();

            app.UseAuthorization();
          
            
            // Area tarafý için bir routing yazýmý yaptýk
            app.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "Admin/{Controller=Home}/{Action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{Controller=Home}/{Action=Index}/{id?}"
            );

            app.Run();
        }
        
           
                
        }
        
    }
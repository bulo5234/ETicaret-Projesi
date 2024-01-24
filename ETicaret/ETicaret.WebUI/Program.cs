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
            
            // Dependency Injection(Ba��ml�l�klar�n Enjekte Edilmesi) ile IDbService t�r�nde bir nesne �rne�i olu�turmak istedi�imizde geriye bize CoreDbService s�n�f�na ait bir nesne �rne�i d�ner ve sorgular�m�z� asl�nda bu s�n�f �zerinden yazabilir hale geliriz.
            builder.Services.AddScoped(typeof(IDbService<>), typeof(CoreDbService<>));

            builder.Services.AddSession(); // Session oturum y�netimi servis olarak ekle
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
          
            
            // Area taraf� i�in bir routing yaz�m� yapt�k
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
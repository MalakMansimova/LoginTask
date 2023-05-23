using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebFrontToBack.DAL;
using WebFrontToBack.Models.Auth;

namespace WebFrontToBack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(opt=>
            {
                opt.IdleTimeout = TimeSpan.FromSeconds(5);


            });
            builder.Services.AddIdentity<AppUser, IdentityRole>()
                            .AddEntityFrameworkStores<AppDbContext>()
                            .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = true;
                //opt.Password.RequiredUniqueChars= 8;
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;

                opt.User.RequireUniqueEmail = true;
                //opt.User.AllowedUserNameCharacters = "Mm123456789";
                opt.Lockout.MaxFailedAccessAttempts = 5; //en ashagisi 5dir defaultu olaragdan
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                opt.Lockout.AllowedForNewUsers = true;

            });


            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
                options.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]);

            });
            var app = builder.Build();
            app.UseSession();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
   
                endpoints.MapDefaultControllerRoute();
            });

            app.Run();
        }
    }
}
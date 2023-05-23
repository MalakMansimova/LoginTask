using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFrontToBack.DAL;
using WebFrontToBack.Models;
using WebFrontToBack.ViewModel;

namespace WebFrontToBack.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            HttpContext.Session.SetString("name","Malak");//SetStrinle yazib SetStringle oxuyuram,bu Session uchundur.
            Response.Cookies.Append("surname","Mansimova",new CookieOptions {MaxAge=TimeSpan.FromSeconds(20)});//cookiesi yazanda bele yaziriq

            HomeVM homeVM = new HomeVM() {
            //Sliders = await _appDbContext.Sliders.ToListAsync(),
            Categories = await _appDbContext.Categories.Where(c => !c.IsDeleted).ToListAsync()
            //Services= await _appDbContext.Services
            //    .Include(s => s.Category)
            //    .Include(s => s.ServiceImages)
            //    .OrderByDescending(s => s.Id)
            //    .Where(s=>!s.IsDeleted)
            //    .Take(8)
            //    .ToListAsync()
        };

            //new DateTime(2023, 11, 01);
            return View(homeVM);
        }
        //public IActionResult GetSession()
        //{
        //    string name=HttpContext.Session.GetString("name");
        //    return Json(name);
        //}
    }
}

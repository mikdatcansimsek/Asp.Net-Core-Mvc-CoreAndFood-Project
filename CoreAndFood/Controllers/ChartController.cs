using CoreAndFood.Data;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<Class1> ProList()
        {
            List<Class1> cs1 = new List<Class1>();
            cs1.Add(new Class1()
            {
                proname = "Computer",
                stock = 100
            });
            cs1.Add(new Class1()
            {
                proname = "Lcd",
                stock = 200
            });
            cs1.Add(new Class1()
            {
                proname = "Usb Disk",
                stock = 300
            });
            return cs1;
        }
        
        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }
        public List<Class2> FoodList()
        {
            List<Class2> cs2 = new List<Class2>();
            using (var context = new Context())
            {
                cs2 = context.Foods.Select(x => new Class2
                {
                    foodname = x.Name,
                    stock = x.Stock
                }).ToList();
            }
            return cs2;
        }

        public IActionResult Statisticks()
        {
            Context c = new Context();

            var deger1 = c.Foods.Count();
            ViewBag.d1 = deger1;

            var deger2 = c.Categories.Count();
            ViewBag.d2 = deger2;

            var deger3 = c.Foods.Where(X => X.CategoryID == 9).Count();
            ViewBag.d3 = deger3;

            var deger4 = c.Foods.Where(X => X.CategoryID == 11).Count();
            ViewBag.d4 = deger4;

            var deger5 = c.Foods.Sum(X => X.Stock);
            ViewBag.d5 = deger5;
            return View();
        }
    }
}

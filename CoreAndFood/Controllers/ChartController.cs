using CoreAndFood.Data;
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
    }
}

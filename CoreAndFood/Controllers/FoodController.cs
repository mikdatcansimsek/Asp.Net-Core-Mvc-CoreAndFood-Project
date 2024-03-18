using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        Context c = new Context();
        FoodRepository fr = new FoodRepository();
        public IActionResult Index(int page = 1)
        {
            return View(fr.TList("Category").ToPagedList(page, 3));
        }
        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;

            return View();
        }
        [HttpPost]
        public IActionResult AddFood(UrunEkle p)
        {
            Food f = new Food();
            if (p.ImageURL != null)
            {
                var extension = Path.GetExtension(p.ImageURL.FileName);
                var newimagename=Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Resimler/",newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageURL.CopyTo(stream);
                f.ImageURL = newimagename;
            }
            f.Name = p.Name;
            //f.Description = p.Description;
            f.Stock = p.Stock;
            f.Price = p.Price;
            f.CategoryID = p.CategoryID;

            fr.TAdd(f);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteFood(int id)
        {
            fr.TRemove(new Food { FoodID = id });
            return RedirectToAction("Index");
        }
        public IActionResult FoodGet(int id)
        {
            var x = fr.TGetById(id);
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;

            Food f = new Food()
            {
                FoodID = x.FoodID,
                CategoryID = x.CategoryID,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Description = x.Description,
                ImageURL = x.ImageURL,
            };
            return View(f);
        }
        [HttpPost]
        public IActionResult FoodUpdate(Food p)
        {
            var x = fr.TGetById(p.FoodID);
            x.CategoryID = p.CategoryID;
            x.Name = p.Name;
            x.Price = p.Price;
            x.Stock = p.Stock;
            x.Description = p.Description;
            x.ImageURL = p.ImageURL;
            fr.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}

using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
    public class FoodListByCategory:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            FoodRepository fr = new FoodRepository();
            var foodList = fr.List(x=>x.CategoryID == id);

            return View(foodList);
        }
    }
}

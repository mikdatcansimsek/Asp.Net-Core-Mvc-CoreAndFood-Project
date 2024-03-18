using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
    public class FoodListByCategory:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            id = 9;
            FoodRepository fr = new FoodRepository();
            var foodList = fr.TList(x=>x.CategoryID == id);

            return View(foodList);
        }
    }
}

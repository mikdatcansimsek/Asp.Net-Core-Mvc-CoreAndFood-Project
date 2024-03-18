using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
    public class CategoryGet: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository cr = new CategoryRepository();
            var categories = cr.TList();
            return View(categories);
        }
    }
}

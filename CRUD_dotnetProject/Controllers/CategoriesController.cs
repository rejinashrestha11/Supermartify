using CRUD_dotnetProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_dotnetProject.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var category = CategoriesRepository.GetCategories();
            return View(category);
        }

        public IActionResult Edit(int ? id)
        {
            ViewBag.Action = "edit";
            var category = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0 );
            return View(category);

        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
           if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
           return View(category);
        }
         
        public IActionResult Add ()
        {
            ViewBag.Action = "add";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Delete (int CategoryId)
        {
            CategoriesRepository.DeleteCategory(CategoryId);
            return RedirectToAction(nameof(Index));
        }

    }
}

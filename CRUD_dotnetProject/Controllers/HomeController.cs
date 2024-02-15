using Microsoft.AspNetCore.Mvc;

namespace CRUD_dotnetProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}

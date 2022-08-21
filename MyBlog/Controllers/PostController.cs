using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers
{
    public class PostController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}

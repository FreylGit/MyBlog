using Microsoft.AspNetCore.Mvc;
using MyBlog.Data.Interfaces;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        private  IBlogRepository _blogRepository;
        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        [HttpGet]
        public ViewResult Edit(Guid id)
        {
            var blog = _blogRepository.Blogs.FirstOrDefault(b=>b.Id==id);
            if(blog != null)
            {
                return View(blog);
            }
            return View("List");
        }

        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            if (blog.CreateData == default)
            {
                blog.CreateData = DateTime.Now;
            }
            if (ModelState.IsValid)
            {
                
                _blogRepository.Save(blog);
            }
            else
            {
                return View(blog);
            }
            return RedirectToAction("Index","Home");
        }
        public ViewResult Create()
        {
            ViewBag.Title = "Создать";
            return View("Edit",new Blog()); 
        }

        public ViewResult List()
        {
            return View(_blogRepository.Blogs);
        }

        public ViewResult Index(Guid id)
        {
            var blog = _blogRepository.Blogs.FirstOrDefault(b=>b.Id==id);
            if (blog != null)
            {
                return View(blog);
            }
            else
            {
                return View();
            }
            
        }
    }
}

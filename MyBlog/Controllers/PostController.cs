using Microsoft.AspNetCore.Mvc;
using MyBlog.Data.Interfaces;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                _postRepository.Save(post);
                return RedirectToAction("Index", "Blog",new { id = post.BlogId });
            }
            return View(post);
        }

        public ViewResult Create(Guid id)
        {   
            return View("Edit", new Post() { BlogId=id});
        }
    }
}

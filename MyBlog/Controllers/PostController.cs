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
        #region EDIT
        [HttpPost]
        public IActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                _postRepository.Save(post);
                return RedirectToAction("Index", "Blog", new { id = post.BlogId });
            }
            return View(post);
        }
        public ViewResult Edit(Guid id)
        {
            var post = _postRepository.Posts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                return View(post);
            }
            else
            {
                return View();
            }
        }
        public ViewResult Create(Guid id)
        {
            return View("Edit", new Post() { BlogId = id });
        }
        #endregion
        public IActionResult Delete(Guid id)
        {
            _postRepository.Delete(id);
            
            return RedirectToAction("Index","Home");

        }
    }
}

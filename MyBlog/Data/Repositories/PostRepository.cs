using Microsoft.AspNetCore.Mvc;
using MyBlog.Data.Interfaces;
using MyBlog.Models;

namespace MyBlog.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        public IQueryable<Post> Posts => _context.Posts;
        private readonly ApplicationDbContext _context;
        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Save(Post post)
        {
            if (_context != null)
            {
                var postEntity = _context.Posts.FirstOrDefault(p => p.Id == post.Id);
                if (postEntity != null)
                {
                    postEntity.Title = post.Title;
                    postEntity.Text  = post.Text;
                }
                else
                {
                    var blog = _context.Blogs.FirstOrDefault(b => b.Id == post.BlogId);
                    if (blog != null)
                    {
                        _context.Posts.Add(post);
                    }
                }
                _context.SaveChanges();
            }
        }
        public void Delete(Guid postId)
        {
            if (_context != null)
            {
                var post = _context.Posts.FirstOrDefault(p => p.Id == postId);
                if (post != null)
                {
                    _context.Posts.Remove(post);
                    _context.SaveChanges();
                }
                return post;
            }
            return null;
        }
    }
}

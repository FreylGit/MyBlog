using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Interfaces;
using MyBlog.Models;

namespace MyBlog.Data.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        public IQueryable<Blog> Blogs => _context.Blogs.Include(p=>p.Posts);

        private  ApplicationDbContext _context;
        public BlogRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Delete(Guid blogId)
        {
            if (_context != null)
            {
                var blog = _context.Blogs.FirstOrDefault(b => b.Id == blogId);
                if (blog != null)
                {
                    _context.RemoveRange(blog.Posts);
                    _context.Remove(blog);
                    _context.SaveChanges();
                }
            }
        }

        public void Save(Blog blog)
        {
            if (_context != null)
            {
                if (_context.Blogs.FirstOrDefault(b => b.Id == blog.Id) != null)
                {
                    _context.Blogs.Update(blog);
                }
                else
                {
                    _context.Blogs.Add(blog);
                }
                _context.SaveChanges();
            }
                
        }
    }
}

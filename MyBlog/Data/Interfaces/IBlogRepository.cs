using MyBlog.Models;

namespace MyBlog.Data.Interfaces
{
    public interface IBlogRepository
    {
        public IQueryable<Blog> Blogs { get; }
        public void Save(Blog blog);
        public void Delete(Guid blogId);

    }
}

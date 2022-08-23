using MyBlog.Data.Interfaces;
using MyBlog.Models;

namespace MyBlog.Data.Repositories
{
    public class FakeBlogRepository : IBlogRepository
    {
        public IQueryable<Blog> Blogs => new List<Blog>() {
            new Blog() { Id = Guid.NewGuid(), Name = "Test1", Description = "Descr1", CreateData = DateTime.Now } ,
            new Blog() { Id = Guid.NewGuid(),Name = "Test2",Description="Descr2",CreateData=DateTime.Now},
            new Blog() { Id = Guid.NewGuid(),Name = "Test3",Description="Descr3",CreateData=DateTime.Now}

        }.AsQueryable();

        public FakeBlogRepository()
        {

        }

        public void Add(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid blogId)
        {
            throw new NotImplementedException();
        }

        public void Save(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}

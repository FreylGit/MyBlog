using MyBlog.Models;

namespace MyBlog.Data.Interfaces
{
    public interface IPostRepository
    {
        public IQueryable<Post>Posts { get; }
        public void Save(Post post);
        public void Delete(Guid postId);

    }
}

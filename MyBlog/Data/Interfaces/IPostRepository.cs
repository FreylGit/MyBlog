using MyBlog.Models;

namespace MyBlog.Data.Interfaces
{
    public interface IPostRepository
    {
        public IQueryable<Post>Posts { get; }
        public void Add(Post post);
        public void Update(Post post);
        public void Delete(Guid postId);

    }
}

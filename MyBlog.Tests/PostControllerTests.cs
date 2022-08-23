using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using MyBlog.Controllers;
using MyBlog.Data.Interfaces;
using MyBlog.Models;

namespace MyBlog.Tests
{
    public class PostControllerTests
    {
        [Fact]
        public void Can_Create_Post()
        {
            var idBlog = Guid.NewGuid();
            var idPost = Guid.NewGuid();
            var blog = new Blog
            {
                Id = idBlog,
                Name = "Name1"
            };
            Mock<IPostRepository> mock = new Mock<IPostRepository>();
            mock.Setup(m => m.Posts).Returns((new Post[]
            {
                new Post{Id = idPost,BlogId =blog.Id,Blog = blog,Title="title"},
            }).AsQueryable<Post>());

            PostController controller = new PostController(mock.Object);
            var result = controller.Create(idBlog).ViewData.Model as Post;
            Assert.NotNull(result);
            Assert.Equal(result.BlogId, idBlog);
        }

        [Fact]
        public void Can_Edit_Post()
        {
            var idBlog = Guid.NewGuid();
            var idPost = Guid.NewGuid();
            var blog = new Blog { Id = idBlog, Name = "NameBlog" };
            Mock<IPostRepository> mock = new Mock<IPostRepository>();
            mock.Setup(m => m.Posts).Returns((new Post[]
            {
                new Post{Id = Guid.NewGuid(),BlogId =blog.Id,Blog = blog, }
            }).AsQueryable<Post>());

            var post = new Post { Id = idPost,Blog = blog,Title="title",Text="Text"};
            var controller = new PostController(mock.Object);
            IActionResult result = controller.Edit(post);
            mock.Verify(m=>m.Save(post));
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", (result as RedirectToActionResult).ActionName);
        }

        [Fact]
        public void Cannot_Edit_Nonexistent_Post()
        {
            var idPost = Guid.NewGuid();
            var idPostNotRepository = Guid.NewGuid();
            Mock<IPostRepository> mock = new Mock<IPostRepository>();
            mock.Setup(m => m.Posts).Returns((new Post[]
            {
                new Post{ Id = idPost}
            }).AsQueryable<Post>());

            PostController controller = new PostController(mock.Object);
            var result = controller.Edit(idPostNotRepository).ViewData.Model as Post;
            Assert.Null(result);
        }

        
        
    }
}

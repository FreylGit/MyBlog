using Microsoft.AspNetCore.Mvc;
using Moq;
using MyBlog.Controllers;
using MyBlog.Data.Interfaces;
using MyBlog.Models;

namespace MyBlog.Tests
{
    public class BlogControllerTests
    {
        [Fact]
        public void Blog_Is_Being_Created()
        {
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            Mock<IBlogRepository> mock = new Mock<IBlogRepository>();
            mock.Setup(m => m.Blogs).Returns(new Blog[]
            {
                new Blog{Id = id1,Name="B1"},
                new Blog{Id = id2,Name="B2"},
            }.AsQueryable<Blog>());
            BlogController controller = new BlogController(mock.Object);
            var blog = new Blog { Name = "test" };
            IActionResult result = controller.Edit(blog);
            mock.Verify(m => m.Save(blog));
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", (result as RedirectToActionResult)?.ActionName);
        }
        [Fact]
        public void Blog_search_by_id()
        {
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            Mock<IBlogRepository> mock = new Mock<IBlogRepository>();
            mock.Setup(m => m.Blogs).Returns(new Blog[]
            {
                new Blog{Id = id1,Name="B1"},
                new Blog{Id = id2,Name="B2"},
            }.AsQueryable<Blog>());
            BlogController controller = new BlogController(mock.Object);
            var result = controller.Edit(id2).ViewData.Model as Blog;
            Assert.NotNull(result);
        }

        [Fact]
        public void Defunct_Blog()
        {
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            Mock<IBlogRepository> mock = new Mock<IBlogRepository>();
            mock.Setup(m => m.Blogs).Returns(new Blog[]
            {
                new Blog{Id = id1,Name="B1"},
                new Blog{Id = id2,Name="B2"},
            }.AsQueryable<Blog>());
            BlogController controller = new BlogController(mock.Object);
            var blog = new Blog { Id = Guid.NewGuid(), Name = "test" };
            var result = controller.Edit(blog.Id).ViewData.Model as Blog;
            Assert.Null(result);
        }

        [Fact]
        public void Show_Blog_By_Id()
        {
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            Mock<IBlogRepository> mock = new Mock<IBlogRepository>();
            mock.Setup(m => m.Blogs).Returns((new Blog[] {
                new Blog {Id = id1,Name ="B1"},
                new Blog {Id = id2,Name ="B2"},
            }).AsQueryable<Blog>());

            BlogController controller = new BlogController(mock.Object);
            var result = controller.Index(id1).ViewData.Model as Blog;

            Assert.Equal(result.Name, "B1");
        }

        [Fact]
        public void Check_Delte_Blog()
        {
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            Mock<IBlogRepository> mock = new Mock<IBlogRepository>();
            mock.Setup(m => m.Blogs).Returns((new Blog[] {
                new Blog {Id = id1,Name ="B1"},
                new Blog {Id = id2,Name ="B2"},
            }).AsQueryable<Blog>());

            BlogController controller = new BlogController(mock.Object);
            var result = controller.Delete(id1);
            mock.Verify(m => m.Delete(id1));

        }
    }
}

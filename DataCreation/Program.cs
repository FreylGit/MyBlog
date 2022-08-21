using DataCreation.Factory;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Data.Repositories;
using MyBlog.Models;

DbContextOptions<ApplicationDbContext> options = new DbContextOptions<ApplicationDbContext>();
ApplicationDbContext context = new ApplicationDbContext(options);

BlogRepository repository = new BlogRepository(context);




void CreateBlogs()
{
    var blogs = new List<Blog>();
    for (int i = 0; i < 10; i++)
    {
        blogs.Add(new Blog { Name = $"name{i}", Description = $"description{i}", CreateData = DateTime.Now });
    }
    context.Blogs.AddRange(blogs);
    context.SaveChanges();
}
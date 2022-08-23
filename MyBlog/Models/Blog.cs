using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Blog
    {
        [BindNever]
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Введите название блога")]
        [MaxLength(100)]
        [Display(Name = "Названи блога")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите описание блога")]
        [MaxLength(100)]
        [Display(Name = "Описание блога")]
        public string Description { get; set; }
        public DateTime CreateData { get; set; }
        public ICollection<Post>? Posts { get; set; }

        public override string ToString()
        {
            return $"name: {Name}, description: {Description}";
        }
    }
}

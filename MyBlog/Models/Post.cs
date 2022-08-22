using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Post
    {
        [BindNever]
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Укажите название поста")]
        [MaxLength(100)]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Введите текст поста")]
        [MaxLength(500)]
        [Display(Name ="Текст")]
        
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public Blog? Blog { get; set; }
        public Guid BlogId { get; set; }
        public override string ToString()
        {
            return $"title: {Title}, text: {Text}";
        }
    }
}

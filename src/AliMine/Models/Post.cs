using System.ComponentModel.DataAnnotations;

namespace AliMine.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указан заголовок")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Не указано содержание")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Не указан путь к картинке")]
        public string ImgAlias { get; set; }

        [Required(ErrorMessage = "Не указана категория")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

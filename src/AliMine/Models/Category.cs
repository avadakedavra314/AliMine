using System.ComponentModel.DataAnnotations;

namespace AliMine.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указано описание")]
        public string Description { get; set; }
    }
}

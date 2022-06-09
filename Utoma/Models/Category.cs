using System.ComponentModel.DataAnnotations;

namespace Utoma.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public string CategoryName { get; set; }
    }
}

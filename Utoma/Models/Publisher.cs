using System.ComponentModel.DataAnnotations;

namespace Utoma.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public string PublisherName { get; set; }
    }
}

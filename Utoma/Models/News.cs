using System.ComponentModel.DataAnnotations;

namespace Utoma.Models
{
    public class News
    {
        public int newsId { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public string PublishDate { get; set; }
        public string Author { get; set; }
        public string NewsCategory { get; set; }
        public string NewsDescription { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public string Link { get; set; }

        
        public string Tags { get; set; }
        public string Newspapers { get; set; }

    }
}

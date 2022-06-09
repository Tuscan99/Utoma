using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Utoma.Models
{
    public class Periodical
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public string ISSN { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название")]
        public string Name { get; set; }
        public int NumPages { get; set; }
        public int TimesInMonth { get; set; }

        [Required]
        [Range(0.00, 1000000, ErrorMessage = "Некорректное значение")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public string Thumbnail { get; set; }

        [Required]
        [Range(1, 1000000, ErrorMessage = "Некорректное значение")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        [Range(1, 1000000, ErrorMessage = "Некорректное значение")]
        public int PublicationTypeId { get; set; }
        public PublicationType PublicationType { get; set; }

        [Required]
        [Range(1, 1000000, ErrorMessage = "Некорректное значение")]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}

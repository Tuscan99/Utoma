using System.ComponentModel.DataAnnotations;

namespace Utoma.Models
{
    public class PublicationType
    {
        public int PublicationTypeId { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public string PublicationTypeName { get; set; }

    }
}
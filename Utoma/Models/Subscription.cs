using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Utoma.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public int PeriodicalId { get; set; }
        public Periodical Periodical { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public string City { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public string Address { get; set; }
        public string PostIndex { get; set; }
        public string ContactPhoneNumber { get; set; }
    }
}

using Utoma.Models;
using System.Collections.Generic;

namespace Utoma.Models.ViewModels
{
    public class DetailsSubscribeViewModel
    {
        public Periodical Periodical { get; set; }
        public Subscription Subscription { get; set; }
        //public List<string> Cities { get; set; }
        public IEnumerable<string> Cities { get; set; }

    }
}

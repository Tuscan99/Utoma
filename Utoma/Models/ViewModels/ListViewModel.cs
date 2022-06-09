using System.Collections.Generic;
using Utoma.Models;

namespace Utoma.Models.ViewModels
{
    public class ListViewModel
    {
        public IEnumerable<Periodical> periodicalsToPage { get; set; }
        public IEnumerable<Category> categoriesToPage { get; set; }
        public string selectedCategory { get; set; }
    }
}

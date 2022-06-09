using System.Collections.Generic;
using System.Linq;

namespace Utoma.Models
{
    public interface IPeriodicalRepository
    {
        IQueryable<Periodical> periodicals { get; }
        void SavePeriodical(Periodical periodical);
        Periodical DeletePeriodical(int periodicalId);
    }
}

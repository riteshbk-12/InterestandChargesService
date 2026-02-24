using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Domain.Enum.Penalty
{
    public enum PenaltyStatus
    {
        Pending = 1,
        Paid = 2,
        Waived = 3,
        PartiallyPaid = 4
    }
}

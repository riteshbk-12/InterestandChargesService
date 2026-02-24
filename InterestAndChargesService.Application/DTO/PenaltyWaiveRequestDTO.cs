using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Application.DTO
{
    public class PenaltyWaiveRequestDTO
    {
        public int PenaltyId { get; set; }
        public decimal? WaiverAmount { get; set; }
        public string? WaiverReason { get; set; }
        public string? WaiverApprovedBy { get; set; }
    }
}

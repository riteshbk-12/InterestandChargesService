using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Application.DTO
{
    public class PenaltyResponseDTO
    {
        public int PenaltyId { get; set; }
        public int ScheduleId { get; set; }
        public string ChargeType { get; set; }
        public decimal ChargeAmount { get; set; }
        public decimal OutstandingAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public int DaysOverdue { get; set; }
        public decimal PenaltyRate { get; set; }
        public string PenaltyStatus { get; set; }
        public DateTime ChargeDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}

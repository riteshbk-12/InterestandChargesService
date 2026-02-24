using InterestAndChargesService.Domain.Enum.Penalty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Domain.Models
{
    public class Penalty
    {
        public int PenaltyId { get; set; }
        public int LoanId { get; set; }
        public int ScheduleId { get; set; }
        public ChargeType ChargeType { get; set; }
        public decimal ChargeAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? OutstandingAmount { get; set; }
        public decimal? WaiverAmount { get; set; }
        public DateTime ChargeDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal PenaltyRate { get; set; }
        public string CalculationBase { get; set; }
        public int DaysOverdue { get; set; }
        public PenaltyStatus PenaltyStatus { get; set; }
        public string? WaiverReason { get; set; }
        public string? WaiverApprovedBy { get; set; }
        public DateTime? WaiverDate { get; set; }
        public string? Remarks { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifyBy { get; set; }

        public int? DeletedBy { get; set; }
    }
}

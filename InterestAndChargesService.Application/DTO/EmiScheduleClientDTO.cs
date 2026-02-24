using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Application.DTO
{
    public class EmiScheduleClientDTO
    {
        public int ScheduleId { get; set; }

        public int LoanId { get; set; }
        public int InstallmentNumber { get; set; }

        public DateTime DueDate { get; set; }

        public decimal EmiAmount { get; set; }

        public decimal PrincipalComponent { get; set; }

        public decimal InterestComponent { get; set; }

        public decimal OpeningBalance { get; set; }

        public decimal ClosingBalance { get; set; }

        public string PaymentStatus { get; set; }

        public decimal PenaltyAmount { get; set; }
        public int daysOverdue { get; set; }
        public DateTime? DeletedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }


        public string? CreatedBy { get; set; }


        public string? DeletedBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Application.DTO
{
    public class LoanAccountClient
    {
        public long LoanId { get; set; }
        public long DealId { get; set; }
        public long SanctionId { get; set; }
        public long DisbursementId { get; set; }
        public long CustomerId { get; set; }
        public long ScorecardId { get; set; }
        public int LoanTypeId { get; set; }
        public int BranchId { get; set; }
        public string SanctionNo { get; set; }
        public decimal SanctionedAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int TenureMonths { get; set; }
        public decimal EmiAmount { get; set; }
        public decimal DisbursedAmount { get; set; }
        public DateTime DisbursementDate { get; set; }
        public string TransactionReference { get; set; }
        public int EmiDay { get; set; }
        public DateTime MaturityDate { get; set; }
        public DateTime FirstEmiDate { get; set; }
        public decimal OutstandingPrincipal { get; set; }
        public decimal OutstandingInterest { get; set; }
        public decimal TotalOutstanding { get; set; }
        public int RemainingTenure { get; set; }
        public int Dpd { get; set; }
        public string AccountStatus { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public DateTime? NextEmiDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}

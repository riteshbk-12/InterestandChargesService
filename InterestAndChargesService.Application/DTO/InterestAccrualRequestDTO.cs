using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Application.DTO
{
    public class InterestAccrualRequestDTO
    {
        public int LoanId { get; set; }

        public DateTime AccrualDate { get; set; }
        public decimal PrincipalBalance { get; set; }
        public decimal InterestRate { get; set; }
        public decimal DailyInterestRate { get; set; }
        public decimal AccruedInterest { get; set; }
        
    }
}

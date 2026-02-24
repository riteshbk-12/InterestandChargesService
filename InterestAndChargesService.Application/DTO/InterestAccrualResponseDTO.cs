using InterestAndChargesService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Application.DTO
{
    public class InterestAccrualResponseDTO
    {
        public int AccrualId { get; set; }
        public int LoanId { get; set; }

        public DateTime AccrualDate { get; set; }
        public decimal PrincipalBalance { get; set; }
        public decimal InterestRate { get; set; }
        public decimal DailyInterestRate { get; set; }
        public decimal AccruedInterest { get; set; }
        public decimal CumulativeInterest { get; set; }

        public string AccrualType { get; set; }          // regular / penal / compound
        public string CalculationMethod { get; set; }    // flat / reducing / compound
        public int DaysInMonth { get; set; }
        public string AccrualStatus { get; set; }        // pending / posted / reversed

        public string? Remarks { get; set; }

    }
}

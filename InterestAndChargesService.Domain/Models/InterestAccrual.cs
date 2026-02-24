using InterestAndChargesService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Domain.Models
{
    public class InterestAccrual
    {
        [Key]
        public int AccrualId { get; set; }
        public int LoanId { get; set; }

        public DateTime AccrualDate { get; set; }
        public decimal PrincipalBalance { get; set; }
        public decimal InterestRate { get; set; }
        public decimal DailyInterestRate { get; set; }
        public decimal AccruedInterest { get; set; }
        public decimal CumulativeInterest { get; set; }

        public AccrualType AccrualType { get; set; }          // regular / penal / compound
        public CalculationMethod CalculationMethod { get; set; }    // flat / reducing / compound
        public int DaysInMonth { get; set; }
        public AccrualStatus AccrualStatus { get; set; }        // pending / posted / reversed

        public string? Remarks { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public int CreatedBy { get; set; }
        public int? ModifyBy { get; set; }
        public int? DeletedBy { get; set; }
    }
}

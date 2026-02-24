using InterestAndChargesService.Application.Interface;
using InterestAndChargesService.Domain.Enum.Penalty;
using InterestAndChargesService.Domain.Models;
using InterestAndChargesService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Application.Services
{
    public class PenaltyJobService
    {
        ApplicationDbContext context;
        IEmiScheduleClientService emiClient;
        public PenaltyJobService(ApplicationDbContext context,IEmiScheduleClientService emiclient)
        {
            this.context = context;
            this.emiClient = emiclient;
        }
        public async Task CalculatePenaltyAsync()
        {
            var emis = await emiClient.GetOverDueEmi();

            foreach(var emi in emis)
            {

                var today = DateTime.Now;
                decimal emiAmount = emi.EmiAmount;
                decimal PenaltyRate=2;
                int DaysOverDue =(today-emi.DueDate).Days;
                decimal chargeAmount = (decimal)(emiAmount/1000) * PenaltyRate * DaysOverDue;
                var penalty = new Penalty
                {
                
                    LoanId = emi.LoanId,
                    ScheduleId = emi.ScheduleId,
                    ChargeType = ChargeType.LateFee,
                    ChargeAmount = chargeAmount,
                    PaidAmount = 0,
                    OutstandingAmount = chargeAmount,
                    WaiverAmount = 0,
                    ChargeDate = today,
                    DueDate = today.AddDays(7),
                    DaysOverdue = DaysOverDue,
                    PenaltyRate = PenaltyRate,
                    CalculationBase = "emiAmount",
                    PenaltyStatus =PenaltyStatus.Pending
                };

                await context.Penalties.AddAsync(penalty);
                emi.PenaltyAmount += chargeAmount;
                await emiClient.UpdateEmiSchedulesForPenalty(emi);
            }

            

            //// 5️⃣ Update LoanAccount PenaltyOutstanding
            //var loanAccount = await _context.LoanAccounts
            //    .FirstOrDefaultAsync(l => l.LoanId == emi.LoanId);

            //if (loanAccount != null)
            //{
            //    loanAccount.PenaltyOutstanding += chargeAmount;
            //    loanAccount.TotalPenaltyGenerated += chargeAmount;
            //}


            await context.SaveChangesAsync();
        }
    }
}

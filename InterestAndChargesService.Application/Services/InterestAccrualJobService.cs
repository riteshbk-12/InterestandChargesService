using AutoMapper;
using InterestAndChargesService.Application.DTO;
using InterestAndChargesService.Application.Interface;
using InterestAndChargesService.Domain.Enum;
using InterestAndChargesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Infrastructure.Repository
{
    public class InterestAccrualJobService
    {
        IMapper mapper;
        IInterestAccrualRepo repo;
        ILoanAccountClientService loanclient;
        IEmiScheduleClientService emiClient;
        
        public InterestAccrualJobService(IMapper mapper,IInterestAccrualRepo repo,ILoanAccountClientService loanclient,IEmiScheduleClientService emiClient)
        {
            this.emiClient = emiClient;
            this.mapper = mapper;
            this.repo = repo;
            this.loanclient = loanclient;
        }
        public async Task CalculateInterestAccrual()
        {
            var emischedule =await emiClient.GetEmiSchedules();
            foreach(var emi in emischedule)
            {

            
                var loanaccount = await loanclient.GetLoanById(emi.LoanId);
                var principaloutstanding = loanaccount.OutstandingPrincipal;
                var interestRate = loanaccount.InterestRate;
                var mappeddata = new InterestAccrual();
                mappeddata.LoanId = emi.LoanId;
                mappeddata.PrincipalBalance = principaloutstanding;
                mappeddata.InterestRate = interestRate;
                mappeddata.DailyInterestRate = (decimal)(interestRate) / 365;
                mappeddata.AccruedInterest = principaloutstanding * mappeddata.DailyInterestRate/100;
                mappeddata.AccrualDate = DateTime.Now;

                mappeddata.CumulativeInterest = mappeddata.CumulativeInterest + mappeddata.AccruedInterest;
                mappeddata.AccrualStatus = AccrualStatus.Pending;
                mappeddata.AccrualType = AccrualType.Regular;
                mappeddata.CalculationMethod = CalculationMethod.Reducing;
                mappeddata.DaysInMonth = 30;
                mappeddata.Remarks = "Interest Accrued";
                await repo.DailyAccrual(mappeddata);
                loanaccount.OutstandingInterest += principaloutstanding * mappeddata.DailyInterestRate / 100;
                await loanclient.UpdateLoanBy(loanaccount);
            }
        }
    }
}

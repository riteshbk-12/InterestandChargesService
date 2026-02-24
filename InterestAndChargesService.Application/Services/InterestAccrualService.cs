using AutoMapper;
using InterestAndChargesService.Application.DTO;
using InterestAndChargesService.Application.Interface;
using InterestAndChargesService.Domain.Models;
using InterestAndChargesService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Application.Services
{
    public class InterestAccrualService : IInterestAccrualService
    {
        IMapper mapper;
        IInterestAccrualRepo repo;
        public InterestAccrualService(IMapper mapper,IInterestAccrualRepo repo)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        //public async Task AddInterestAccrual(int loanId)
        //{
        //    var principaloutstanding = 100000;
        //    var interestRate = 6;
        //    var mappeddata = new InterestAccrual();
        //    mappeddata.LoanId = loanId;
        //    mappeddata.PrincipalBalance= principaloutstanding;
        //    mappeddata.InterestRate= interestRate;
        //    mappeddata.DailyInterestRate = (decimal)interestRate / 365;
        //    mappeddata.AccruedInterest = principaloutstanding * interestRate / 365;
        //    mappeddata.AccrualDate= DateTime.Now;

        //    mappeddata.CumulativeInterest = mappeddata.CumulativeInterest + mappeddata.AccruedInterest;
        //    mappeddata.AccrualStatus = AccrualStatus.Pending;
        //    mappeddata.AccrualType = AccrualType.Regular;
        //    mappeddata.CalculationMethod = CalculationMethod.Reducing;
        //    mappeddata.DaysInMonth = 30;
        //    mappeddata.Remarks = "Interest Accrued";
        //    await repo.DailyAccrual(mappeddata);
        //}

        public async Task<List<InterestAccrualResponseDTO>> GetInterest(int loanId)
        {
            var datalist = await repo.GetAccrual(loanId);
            var mappeddatalist = mapper.Map<List<InterestAccrualResponseDTO>>(datalist);
            return mappeddatalist;
        }

        public async Task UpdatInterestAccrualAndUpdateLoanTableEMISchedular(int loanId)
        {
            decimal interestsum=0 ;
            var datalist =await repo.GetPendingAccrual(loanId);
            interestsum = datalist.Sum(x => x.AccruedInterest);
            repo.UpdateInterestAccrual(loanId);
        }
    }
}

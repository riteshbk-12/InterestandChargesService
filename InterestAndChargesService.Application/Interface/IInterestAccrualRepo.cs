using InterestAndChargesService.Application.DTO;
using InterestAndChargesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Application.Interface
{
    public interface IInterestAccrualRepo
    {
        public Task<List<InterestAccrual>> GetAccrual(int loanid);
        public Task DailyAccrual(InterestAccrual interest);
        public Task UpdateInterestAccrual(int loanid);
        public Task<List<InterestAccrual>> GetPendingAccrual(int loanId);
    }
}

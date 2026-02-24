using AutoMapper;
using InterestAndChargesService.Application.DTO;
using InterestAndChargesService.Application.Interface;
using InterestAndChargesService.Domain.Models;
using InterestAndChargesService.Domain.Enum;
using InterestAndChargesService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Infrastructure.Repository
{
    public class InterestAccrualRepo : IInterestAccrualRepo
    {
        ApplicationDbContext context;
        public InterestAccrualRepo(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
        }
        public async Task DailyAccrual(InterestAccrual interest)
        {
            await context.InterestAccruals.AddAsync(interest);
            await context.SaveChangesAsync();
        }

        public async Task<List<InterestAccrual>> GetAccrual(int loanid)
        {
            var interestAccrualList = await context.InterestAccruals.Where(x => x.LoanId == loanid).ToListAsync();
            return interestAccrualList;
        }

        public async Task UpdateInterestAccrual(int loanId)
        {
            await context.InterestAccruals.Where(x => x.LoanId == loanId && x.AccrualStatus == AccrualStatus.Pending)
                .ExecuteUpdateAsync(set => set.SetProperty(x => x.AccrualStatus, AccrualStatus.Posted));
            await context.SaveChangesAsync();
        }
        public async Task<List<InterestAccrual>> GetPendingAccrual(int loanId)
        {
            var interestaccrual = await context.InterestAccruals.Where(x => x.LoanId == loanId && x.AccrualStatus == AccrualStatus.Pending).ToListAsync();
            return interestaccrual;
        }
    }
}

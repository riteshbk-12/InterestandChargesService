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

namespace InterestAndChargesService.Infrastructure.Repository
{
    public class PenaltyRepo : IPenaltyRepo
    {
        ApplicationDbContext context;
        public PenaltyRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        

        public async Task<Penalty> GetById(int penaltyid)
        {
            var data = await context.Penalties.FindAsync(penaltyid);
            return data;
        }

        public async Task<List<Penalty>> GetPenaltiesOverDues(int loanId)
        {
            var datalist=await context.Penalties.Where(x => x.PenaltyStatus != PenaltyStatus.Paid && x.PenaltyStatus != PenaltyStatus.Waived && x.LoanId==loanId).ToListAsync();
            return datalist; 
        }

        public async Task<List<Penalty>> GetPenalty(int loanId)
        {
            var datalist=await context.Penalties.Where(x => x.LoanId == loanId).ToListAsync();
            return datalist;
        }

        public async Task UpdatePenalty(Penalty penalty)
        {
            context.Penalties.Update(penalty);
            await context.SaveChangesAsync();
        }
    }
}

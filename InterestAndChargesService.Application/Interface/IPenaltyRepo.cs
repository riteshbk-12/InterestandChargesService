using InterestAndChargesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Application.Interface
{
    public interface IPenaltyRepo
    {
        Task<List<Penalty>> GetPenalty(int loanId);
        Task<Penalty> GetById(int penaltyid);
        Task<List<Penalty>> GetPenaltiesOverDues(int loanId);
        Task UpdatePenalty(Penalty penalty);
    }
}

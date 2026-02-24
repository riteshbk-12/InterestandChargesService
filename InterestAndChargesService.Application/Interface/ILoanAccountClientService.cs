using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestAndChargesService.Application.DTO;

namespace InterestAndChargesService.Application.Interface
{
    public interface ILoanAccountClientService
    {
        Task<LoanAccountClient> GetLoanById(int loanId);
        Task UpdateLoanBy(LoanAccountClient dto);

    }
}

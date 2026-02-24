using InterestAndChargesService.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Application.Interface
{
    public interface IInterestAccrualService
    {
        Task<List<InterestAccrualResponseDTO>> GetInterest(int loanId);
        //Task AddInterestAccrual(int loanId);
        Task UpdatInterestAccrualAndUpdateLoanTableEMISchedular(int loanId);
    }
}

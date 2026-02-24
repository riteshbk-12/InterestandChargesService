using InterestAndChargesService.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Application.Interface
{
    public interface IPenaltyService
    {
        public Task<List<PenaltyResponseDTO>> GetPenalty(int loanid);
        public Task Addpenalty(PenaltyRequestDTO dto);
        public Task<List<PenaltyResponseDTO>> GetPenaltiesOverDue(int loanId);
        Task WaivePenalty(PenaltyWaiveRequestDTO dto);
        Task<GetPenaltyResponseDTO> GetPenaltySum(int loanid);
    }
}

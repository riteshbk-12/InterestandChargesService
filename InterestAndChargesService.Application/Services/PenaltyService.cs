using AutoMapper;
using InterestAndChargesService.Application.DTO;
using InterestAndChargesService.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Application.Services
{
    public class PenaltyService : IPenaltyService
    {
        IMapper mapper;
        IPenaltyRepo repo;
        public PenaltyService(IMapper mapper,IPenaltyRepo repo)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public Task Addpenalty(PenaltyRequestDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PenaltyResponseDTO>> GetPenaltiesOverDue(int loanId)
        {
            var datalist = await repo.GetPenaltiesOverDues(loanId);
            var mappeddatalist = mapper.Map<List<PenaltyResponseDTO>>(datalist);
            return mappeddatalist;
        }

        public async Task<List<PenaltyResponseDTO>> GetPenalty(int loanid)
        {
            var datalist = await repo.GetPenalty(loanid);
            var mappeddatalist = mapper.Map<List<PenaltyResponseDTO>>(datalist);
            return mappeddatalist;
        }

        public async Task<GetPenaltyResponseDTO> GetPenaltySum(int loanid)
        {
            var datalist = await repo.GetPenaltiesOverDues(loanid);
            var penaltysum = datalist.Sum(x => x.ChargeAmount);
            var mappeddata = new GetPenaltyResponseDTO()
            {
                PenaltySum = penaltysum
            };
            return mappeddata;
        }

        public async Task WaivePenalty(PenaltyWaiveRequestDTO dto)
        {
            var penaltydata = await repo.GetById(dto.PenaltyId);
            penaltydata.WaiverAmount = dto.WaiverAmount;
            penaltydata.WaiverApprovedBy=dto.WaiverApprovedBy;
            penaltydata.WaiverReason=dto.WaiverReason;
            penaltydata.WaiverDate = DateTime.Now;
            await repo.UpdatePenalty(penaltydata);
        }
        
    }
}

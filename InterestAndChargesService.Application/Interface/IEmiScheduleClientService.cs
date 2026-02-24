using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestAndChargesService.Application.DTO;

namespace InterestAndChargesService.Application.Interface
{
    public interface IEmiScheduleClientService
    {
        Task<EmiScheduleClientDTO> GetEmiSchedule(int loanid);
        Task<List<EmiScheduleClientDTO>> GetEmiSchedules();
        Task<List<EmiScheduleClientDTO>> GetOverDueEmi();
        Task UpdateEmiSchedulesForPenalty(EmiScheduleClientDTO dto);
    }
}

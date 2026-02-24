using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using InterestAndChargesService.API.Helper;
using InterestAndChargesService.Application.DTO;
using InterestAndChargesService.Application.Interface;

namespace InterestAndChargesService.Infrastructure.ExternalServices
{
    public class EmiScheduleClientService:IEmiScheduleClientService
    {
        HttpClient httpClient;
        public EmiScheduleClientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<EmiScheduleClientDTO> GetEmiSchedule(int loanid)
        {
            var response = await httpClient.GetFromJsonAsync<ApiResponse<EmiScheduleClientDTO>>("");
            return response.data;
        }

        public async Task<List<EmiScheduleClientDTO>> GetEmiSchedules()
        {
            var response = await httpClient.GetFromJsonAsync<ApiResponse<List<EmiScheduleClientDTO>>>("Emi/currentEmis");
            return response.data;
        }
        public async Task<List<EmiScheduleClientDTO>> GetOverDueEmi()
        {
            var response = await httpClient.GetFromJsonAsync<ApiResponse<List<EmiScheduleClientDTO>>>("Emi/getOverDueEMI");
            return response.data;
        }
        public async Task UpdateEmiSchedulesForPenalty(EmiScheduleClientDTO dto)
        {
            var resposnse = await httpClient.PutAsJsonAsync<EmiScheduleClientDTO>("Emi/updatePenalty", dto);
            if (!resposnse.IsSuccessStatusCode)
            {
                return;
            }
        }
    }
}

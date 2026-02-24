using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using InterestAndChargesService.API.Helper;
using InterestAndChargesService.Application.DTO;
using InterestAndChargesService.Application.Interface;

namespace InterestAndChargesService.Infrastructure.ExternalServices
{
    public class LoanAccountClientService:ILoanAccountClientService
    {
        HttpClient httpclient;
        public LoanAccountClientService(HttpClient httpclient)
        {
            this.httpclient = httpclient;
        }

        public async Task<LoanAccountClient> GetLoanById(int loanId)
        {
            var response = await httpclient.GetFromJsonAsync<ApiResponse<LoanAccountClient>>($"LoanAccount/{loanId}");
            return response.data;
        }

        public async Task UpdateLoanBy(LoanAccountClient dto)
        {
            var response=  await httpclient.PutAsJsonAsync<LoanAccountClient>("LoanAccount/update",dto);
            if (response.StatusCode!= HttpStatusCode.OK)
            {
                ApiResponse<string>.FailureResponse(code: response.StatusCode.ToString(), Details: "API response Failed");
            }

        }
    }
}

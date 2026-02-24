using InterestAndChargesService.API.Helper;
using InterestAndChargesService.Application.DTO;
using InterestAndChargesService.Application.Interface;
using InterestAndChargesService.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterestAndChargesService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestAccrualController : ControllerBase
    {
        IInterestAccrualService service;
        public InterestAccrualController(IInterestAccrualService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetInterestAccrual(int loanId)
        {
            var interestaccrual=await service.GetInterest(loanId);
            var response = ApiResponse<List<InterestAccrualResponseDTO>>.SuccessResponse(interestaccrual);
            return Ok(response);
        }
        //[HttpPost]
        //public async Task<IActionResult> AddinterestAccrual(int loanid)
        //{
        //    await service.AddInterestAccrual(loanid);
        //    var response = ApiResponse<object>.SuccessResponse(null);
        //    return Ok(response);
        //}
        [HttpPut("udpateloantable")]
        public async Task<IActionResult> UpdateInterestAccrual(int loanid)
        {
            await service.UpdatInterestAccrualAndUpdateLoanTableEMISchedular(loanid);
            var response = ApiResponse<object>.SuccessResponse(null);
            return Ok(response);
        }
    }
}

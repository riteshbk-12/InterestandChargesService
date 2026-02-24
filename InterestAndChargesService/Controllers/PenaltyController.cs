using InterestAndChargesService.API.Helper;
using InterestAndChargesService.Application.DTO;
using InterestAndChargesService.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterestAndChargesService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenaltyController : ControllerBase
    {
        IPenaltyService service;
        public PenaltyController(IPenaltyService service)
        {
            this.service = service;
            
        }
        [HttpGet("getPenaltyOverDues")]
        public async Task<IActionResult> getPenaltyOverDues(int loanid)
        {
            var data = await service.GetPenaltiesOverDue(loanid);
            var response = ApiResponse<List<PenaltyResponseDTO>>.SuccessResponse(data);

            return Ok(response);
        }
        [HttpGet("getAllPenalties")]
        public async Task<IActionResult> getPenalties(int loanid)
        {
            var data = await service.GetPenalty(loanid);
            var response = ApiResponse<List<PenaltyResponseDTO>>.SuccessResponse(data);
            return Ok(response);
        }
        [HttpPut("waivePenalty")]
        public async Task<IActionResult> WaivePenalty(PenaltyWaiveRequestDTO dto)
        {
            await service.WaivePenalty(dto);
            var response = ApiResponse<object>.SuccessResponse(null);
            return Ok(response);
        }
        [HttpGet("getPenaltySum/{loanid}")]
        public async Task<IActionResult> getPenaltySum(int loanid)
        {
            var reponse = await service.GetPenaltySum(loanid);
            return Ok(ApiResponse<GetPenaltyResponseDTO>.SuccessResponse(reponse));
        }
    }
}

using DGI.Application.Common.BaseResponse;
using DGI.Application.Features.Taxpayers.Requests;
using DGI.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace DGI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxpayersController : ControllerBase
    {
        private readonly ITaxpayerService _taxpayerService;

        public TaxpayersController(ITaxpayerService taxpayerService)
        {
            _taxpayerService = taxpayerService;
        }

        [HttpGet("getReceipt/{id}")]
        [SwaggerOperation(Summary = "Gets Taxpayer with the total sum of ITBIS by Id")]
        public async Task<IActionResult> GetTaxpayerWithTotalItbisById(string id)
        {
            try
            {
                var result = await _taxpayerService.GetTaxPayerById(id);
                return Ok(BaseResponse.Ok(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse(HttpStatusCode.BadRequest, ex.Message, null));
            }
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets Taxpayers in the database")]
        public async Task<IActionResult> GetTaxpayers()
        {
            try
            {
                var taxpayers = await _taxpayerService.GetTaxPayer();
                return Ok(BaseResponse.Ok(taxpayers));
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse(HttpStatusCode.BadRequest, ex.Message, null));
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new Taxpayer")]
        public async Task<IActionResult> Post([FromBody] CreateTaxpayerRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _taxpayerService.CreateTaxPayer(request, cancellationToken);
                return CreatedAtRoute(new { id = result.Id }, BaseResponse.Created(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse(HttpStatusCode.BadRequest, ex.Message, null));
            }
        }
    }
}

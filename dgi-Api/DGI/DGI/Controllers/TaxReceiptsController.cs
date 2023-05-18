using DGI.Application.Common.BaseResponse;
using DGI.Application.Features.TaxReceipt.Requests;
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
    public class TaxReceiptsController : ControllerBase
    {
        private readonly ITaxReceiptService _taxReceiptService;

        public TaxReceiptsController(ITaxReceiptService taxReceiptService)
        {
            _taxReceiptService = taxReceiptService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets taxReceipt in the database")]
        public async Task<IActionResult> GetTaxReceipts()
        {
            try
            {
                var taxReceipt = await _taxReceiptService.GetTaxReceipt();
                return Ok(BaseResponse.Ok(taxReceipt));
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse(HttpStatusCode.BadRequest, ex.Message, null));
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create taxReceipt in the database")]
        public async Task<IActionResult> Post([FromBody] CreateTaxReceiptRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _taxReceiptService.CreateTaxReceipt(request, cancellationToken);
                return CreatedAtRoute(new { id = result.Id }, BaseResponse.Created(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse(HttpStatusCode.BadRequest, ex.Message, null));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BeautyPro.CRM.Contract.DTO.UI;
using BeautyProCRM.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyPro.CRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : BeautyProBaseController
    {
        private readonly ICustomerScheduleTreatmentService _customerScheduleTreatmentService;
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(
            IHttpContextAccessor httpContextAccessor,
            ICustomerScheduleTreatmentService customerScheduleTreatmentService,
            IInvoiceService invoiceService) : base(httpContextAccessor)
        {
            _customerScheduleTreatmentService = customerScheduleTreatmentService;
            _invoiceService = invoiceService;
        }

        [HttpGet("treatments")]
        public IActionResult GetCustomerInvoiceableTreatments([FromQuery]InvoiceTreatmentRequest request)
        {
            return Ok(_customerScheduleTreatmentService.GetInvoiceableScheduledTreatments(request));
        }

        [HttpPost("save")]
        public IActionResult SaveInvoice([FromBody]InvoiceSaveRequest request)
        {
            try
            {
                _invoiceService.SaveInvoice(request, BranchId, UserId);
                return Ok(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using BeautyProCRM.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyPro.CRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VouchersController : BeautyProBaseController
    {
        private readonly ICustomerGiftVoucherService _customerGiftVoucherService;

        public VouchersController(
            IHttpContextAccessor httpContextAccessor,
            ICustomerGiftVoucherService customerGiftVoucherService) : base(httpContextAccessor)
        {
            this._customerGiftVoucherService = customerGiftVoucherService;
        }

        [HttpGet("filter")]
        [Authorize]
        [ProducesResponseType(typeof(CustomerGiftVoucherDTO), (int)HttpStatusCode.OK)]
        public ActionResult GetFilteredVouchers([FromQuery]VoucherRequest request)
        {
            return Ok(_customerGiftVoucherService.GetAllVouchers(request));
        }

        [HttpPost("save")]
        [Authorize]
        public ActionResult AddNewVoucher([FromBody]CustomerGiftVoucherDTO voucher)
        {
            voucher.EnteredBy = UserId;
            return Ok(_customerGiftVoucherService.AddNewVoucher(voucher));
        }

        [HttpGet("paymentTypes")]
        public IActionResult GetPaymentTypes()
        {
            return Ok(_customerGiftVoucherService.GetPaymentTypes());
        }
    }
}
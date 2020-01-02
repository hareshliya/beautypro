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
            return Ok(_customerGiftVoucherService.GetFilteredVouchers(request));
        }

        [HttpGet("issued-vouchers")]
        [Authorize]
        [ProducesResponseType(typeof(CustomerGiftVoucherDTO), (int)HttpStatusCode.OK)]
        public ActionResult GetIssuedVouchers([FromQuery]IssuedVoucherRequest request)
        {
            return Ok(_customerGiftVoucherService.GetIssuedVouchers(request));
        }

        [HttpPost("save")]
        [Authorize]
        public ActionResult AddEditVoucher([FromBody]CustomerGiftVoucherDTO request)
        {
            try
            {
                _customerGiftVoucherService.AddEditVoucher(request, UserId, BranchId);
                return Ok(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "SystemAdmin,GeneralManager")]
        public IActionResult DeleteVoucher([FromQuery]VoucherDeleteRequest request)
        {
            try
            {
                _customerGiftVoucherService.DeleteVoucher(request, UserId);
                return Ok(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("paymentTypes")]
        public IActionResult GetPaymentTypes()
        {
            return Ok(_customerGiftVoucherService.GetPaymentTypes());
        }

        [HttpPost("edit-voucher-status")]
        public IActionResult ChangeVoucherStatus(VoucherStatusRequest request)
        {
            try
            {
                _customerGiftVoucherService.ChangeVoucherStatus(request);
                return Ok(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
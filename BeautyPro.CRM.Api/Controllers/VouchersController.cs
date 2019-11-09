using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using BeautyProCRM.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyPro.CRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VouchersController : ControllerBase
    {
        private readonly ICustomerGiftVoucherService _customerGiftVoucherService;

        public VouchersController(
            ICustomerGiftVoucherService customerGiftVoucherService)
        {
            this._customerGiftVoucherService = customerGiftVoucherService;
        }

        [HttpPost]
        public ActionResult GetVouchers([FromBody]VoucherRequest request)
        {
            return Ok(_customerGiftVoucherService.GetAllVouchers(request));
        }

        [HttpPost]
        public ActionResult AddNewVoucher([FromBody]CustomerGiftVoucherDTO voucher)
        {
            return Ok(_customerGiftVoucherService.AddNewVoucher(voucher));
        }
    }
}
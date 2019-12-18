using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BeautyPro.CRM.Contract.DTO.UI;
using BeautyPro.CRM.EF.Interfaces;
using BeautyProCRM.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyPro.CRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BeautyProBaseController
    {
        private readonly ICustomerService _customerservice;

        public CustomersController(
            IHttpContextAccessor httpContextAccessor,
            ICustomerService customerservice) : base(httpContextAccessor)
        {
            this._customerservice = customerservice;
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdmin,GeneralManager,Receiption,Director,Accountant")]
        public IActionResult GetCustomer([FromQuery]string customerId)
        {
            return Ok(_customerservice.GetCustomer(customerId));
        }

        [HttpGet("search")]
        [Authorize(Roles = "SystemAdmin,GeneralManager,Receiption,Director,Accountant")]
        public IActionResult SearchCustomer([FromQuery]CustomerSearchRequest request)
        {
            return Ok(_customerservice.SearchCustomer(request));
        }

        [HttpGet("search-confirmed-schedule-customer")]
        [Authorize(Roles = "SystemAdmin,GeneralManager,Receiption,Director,Accountant")]
        public IActionResult SearchCustomersForConfirmedSchedulesForToday([FromQuery]CustomerSearchRequest request)
        {
            return Ok(_customerservice.SearchCustomersForConfirmedSchedulesForToday(request));
        }

        [HttpPost]
        [Authorize(Roles = "SystemAdmin,GeneralManager")]
        public IActionResult AddEditCustomer([FromBody]NewCustomerRequest request)
        {
            try
            {
                _customerservice.AddEditCustomer(request, UserId, BranchId);
                return Ok(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "SystemAdmin,GeneralManager,Receiption")]
        public IActionResult DeleteCustomer([FromQuery]string customerId)
        {
            try
            {
                _customerservice.RemoveCustomer(customerId, UserId);
                return Ok(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
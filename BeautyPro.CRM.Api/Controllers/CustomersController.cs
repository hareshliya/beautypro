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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerservice;

        public CustomersController(ICustomerService customerservice)
        {
            this._customerservice = customerservice;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetCustomer([FromQuery]string customerId)
        {
            return Ok(_customerservice.GetCustomer(customerId));
        }

        [Authorize]
        [HttpGet("search")]
        public IActionResult SearchCustomer([FromQuery]CustomerSearchRequest request)
        {
            return Ok(_customerservice.SearchCustomer(request));
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddEditCustomer([FromBody]NewCustomerRequest request)
        {
            try
            {
                _customerservice.AddEditCustomer(request);
                return Ok(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeleteCustomer([FromQuery]string customerId)
        {
            try
            {
                _customerservice.RemoveCustomer(customerId);
                return Ok(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyPro.CRM.Contract.DTO.UI;
using BeautyProCRM.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyPro.CRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulersController : ControllerBase
    {
        private readonly ICustomerScheduleService _customerScheduleService;
        public SchedulersController(
            ICustomerScheduleService customerScheduleService)
        {
            _customerScheduleService = customerScheduleService;
        }

        [Authorize(Roles = "SystemAdmin,GeneralManager,Receiption")]
        [Authorize]
        public IActionResult GetShedules([FromQuery]ScheduleRequest request)
        {
            return Ok(_customerScheduleService.GetShedules(request));
        }
    }
}
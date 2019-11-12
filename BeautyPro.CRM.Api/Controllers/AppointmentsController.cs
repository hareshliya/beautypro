using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyProCRM.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyPro.CRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly ICustomerScheduleService _customerScheduleService;

        public AppointmentsController(ICustomerScheduleService customerScheduleService)
        {
            _customerScheduleService = customerScheduleService;
        }


    }
}
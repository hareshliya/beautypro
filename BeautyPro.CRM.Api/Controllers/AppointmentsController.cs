using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class AppointmentsController : ControllerBase
    {
        private readonly ICustomerScheduleTreatmentService _customerScheduleTreatmentService;
        private readonly ICustomerScheduleService _customerScheduleService;

        public AppointmentsController(
            ICustomerScheduleTreatmentService customerScheduleTreatmentService,
            ICustomerScheduleService customerScheduleService)
        {
            _customerScheduleTreatmentService = customerScheduleTreatmentService;
            _customerScheduleService = customerScheduleService;
        }

        [HttpGet("filter")]
        [Authorize]
        public IActionResult GetFilteredAppointments([FromQuery]AppointmentFilterRequest request)
        {
            return Ok(_customerScheduleTreatmentService.GetFilteredAppointments(request));
        }

        [HttpPost]
        public IActionResult AddNewTreatment([FromBody]NewAppointmentRequest request)
        {
            try
            {
                _customerScheduleService.AddNewAppointment(request);
                return Ok(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
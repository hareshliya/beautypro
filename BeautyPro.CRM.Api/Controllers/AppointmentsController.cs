using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using BeautyPro.CRM.Mapper;
using BeautyProCRM.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyPro.CRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : BeautyProBaseController
    {
        private readonly ICustomerScheduleTreatmentService _customerScheduleTreatmentService;
        private readonly ICustomerScheduleService _customerScheduleService;
        

        public AppointmentsController(
            IHttpContextAccessor httpContextAccessor,
            ICustomerScheduleTreatmentService customerScheduleTreatmentService,
            ICustomerScheduleService customerScheduleService) : base(httpContextAccessor)
        {
            _customerScheduleTreatmentService = customerScheduleTreatmentService;
            _customerScheduleService = customerScheduleService;
        }

        [HttpGet("filter")]
        [Authorize(Roles = "SystemAdmin,GeneralManager,Receiption,Director,Accountant")]
        public IActionResult GetFilteredAppointments([FromQuery]AppointmentFilterRequest request)
        {
            return Ok(_customerScheduleTreatmentService.GetFilteredAppointments(request));
        }

        [HttpPost("save")]
        [Authorize(Roles = "SystemAdmin,GeneralManager,Receiption")]
        public IActionResult AddEditAppointment([FromBody]NewAppointmentRequest request)
        {
            try
            {
                _customerScheduleService.AddEditAppointment(request, UserId, BranchId);
                return Ok(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "SystemAdmin,GeneralManager")]
        public IActionResult DeleteAppointment([FromQuery] int csid)
        {
            try
            {
                _customerScheduleService.DeleteAppointment(csid, UserId);
                return Ok(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("employees")]
        [Authorize(Roles = "SystemAdmin,GeneralManager,Receiption,Director,Accountant")]
        [ProducesResponseType(typeof(EmployeeDetailDTO), (int)HttpStatusCode.OK)]
        public IActionResult GetFilteredEmployees([FromBody]EmployeeRosterRequest request)
        {
            return Ok(_customerScheduleService.GetFilteredEmployees(request));
        }

        [HttpPost("status")]
        [Authorize(Roles = "SystemAdmin,GeneralManager,Receiption")]
        public IActionResult UpdateAppoinmentStatus([FromBody]AppoinmentStatusRequest request)
        {
            try
            {
                _customerScheduleService.UpdateAppoinmentStatus(request, UserId);
                return Ok(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
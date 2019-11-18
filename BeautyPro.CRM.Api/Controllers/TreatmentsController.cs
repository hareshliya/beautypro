﻿using System;
using System.Linq;
using System.Net;
using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using BeautyPro.CRM.EF.Interfaces;
using BeautyPro.CRM.Mapper;
using BeautyProCRM.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyPro.CRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentsController : BeautyProBaseController
    {
        private readonly ITreatmentTypeRepository _treatmentTypeRepository;
        private readonly ITreatmentService _treatmentService;
        public TreatmentsController(
            IHttpContextAccessor httpContextAccessor,
            ITreatmentService treatmentService,
            ITreatmentTypeRepository treatmentTypeRepository) : base(httpContextAccessor)
        {
            _treatmentTypeRepository = treatmentTypeRepository;
            _treatmentService = treatmentService;
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdmin,GeneralManager,Receiption,Director,Accountant")]
        [ProducesResponseType(typeof(TreatmentTypeDTO), (int)HttpStatusCode.OK)]
        public IActionResult GetAllTreatments()
        {
            return Ok(DomainDTOMapper.ToTreatmentTypesDTOs(_treatmentTypeRepository.GetAll().ToList()));
        }

        [HttpPost("employee")]
        [Authorize(Roles = "SystemAdmin,GeneralManager,Receiption,Director,Accountant")]
        public IActionResult GetTreatmentForUser([FromBody]TreatmentRequest request)
        {
            return Ok(_treatmentService.GetTreatmentsForEmployee(request));
        }

        [HttpGet("departments")]
        [Authorize(Roles = "SystemAdmin,GeneralManager,Receiption,Director,Accountant")]
        public IActionResult GetDepartments()
        {
            return Ok(_treatmentService.GetDepartments());
        }

        [HttpPost("save")]
        [Authorize(Roles = "SystemAdmin,GeneralManager")]
        public IActionResult AddNewTreatment([FromBody]TreatmentTypeDTO treatment)
        {
            treatment.BranchId = BranchId;
            treatment.EnteredBy = UserId;
            return Ok(_treatmentService.AddNewTreatment(treatment));
        }

        [HttpGet("filter")]
        [Authorize(Roles = "SystemAdmin,GeneralManager,Receiption,Director,Accountant")]
        [ProducesResponseType(typeof(CustomerGiftVoucherDTO), (int)HttpStatusCode.OK)]
        public IActionResult GetFilteredTreatments([FromQuery]TreatmentFilterRequest request)
        {
            return Ok(_treatmentService.GetFilteredTreatments(request));
        }

        [HttpDelete]
        [Authorize(Roles = "SystemAdmin,GeneralManager")]
        public IActionResult DeleteTreatment(int treatmentTypeId)
        {
            try
            {
                _treatmentService.DeleteTreatment(treatmentTypeId, UserId);
                return Ok(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
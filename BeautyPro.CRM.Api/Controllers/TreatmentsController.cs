using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
    public class TreatmentsController : ControllerBase
    {
        private readonly ITreatmentTypeRepository _treatmentTypeRepository;
        private readonly ITreatmentService _treatmentService;
        public TreatmentsController(
            ITreatmentService treatmentService,
            ITreatmentTypeRepository treatmentTypeRepository)
        {
            this._treatmentTypeRepository = treatmentTypeRepository;
            this._treatmentService = treatmentService;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(TreatmentTypeDTO), (int)HttpStatusCode.OK)]
        public ActionResult GetAllTreatments()
        {
            return Ok(DomainDTOMapper.ToTreatmentTypesDTOs(_treatmentTypeRepository.GetAll().ToList()));
        }

        [HttpPost("employee")]
        public ActionResult GetTreatmentForUser([FromBody]TreatmentRequest request)
        {
            return Ok(_treatmentService.GetTreatmentsForEmployee(request));
        }

        [HttpGet("departments")]
        public ActionResult GetDepartments()
        {
            return Ok(_treatmentService.GetDepartments());
        }

        [HttpPost]
        public ActionResult AddNewTreatment([FromBody]TreatmentTypeDTO treatment)
        {
            return Ok(_treatmentService.AddNewTreatment(treatment));
        }
    }
}
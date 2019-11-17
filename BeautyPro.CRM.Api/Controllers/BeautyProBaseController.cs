using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyPro.CRM.Api.Controllers
{
    [ApiController]
    public abstract class BeautyProBaseController : ControllerBase
    {
        protected int UserId { get; }

        public BeautyProBaseController(IHttpContextAccessor contextAccessor)
        {
            var userContext = contextAccessor.HttpContext.User;
            var userIdClaim = userContext.FindFirst(ClaimTypes.Name)?.Value;

            bool isValidUserId = int.TryParse(userIdClaim, out int userId);

            if (!isValidUserId)
            {
                throw new Exception("user id claim doesn't exist");
            }

            UserId = userId;
        }
    }
}
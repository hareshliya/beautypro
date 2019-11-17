using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BeautyPro.CRM.Api.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyPro.CRM.Api.Controllers
{
    [ApiController]
    public abstract class BeautyProBaseController : ControllerBase
    {
        protected int UserId { get; }
        protected int BranchId { get; }

        public BeautyProBaseController(IHttpContextAccessor contextAccessor)
        {
            var userContext = contextAccessor.HttpContext.User;
            var userIdClaim = userContext.FindFirst(ClaimTypes.Name)?.Value;
            var branchIdClaim = userContext.FindFirst(ClaimConstants.BARNCH_ID)?.Value;

            bool isValidUserId = int.TryParse(userIdClaim, out int userId);
            bool isValidBranchId = int.TryParse(branchIdClaim, out int branchId);

            if (!isValidUserId || !isValidBranchId)
            {
                throw new Exception("user id or/and branch id claim(s) doesn't exist");
            }

            UserId = userId;
            BranchId = branchId;
        }
    }
}
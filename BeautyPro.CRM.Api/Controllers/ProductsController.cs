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
    public class ProductsController : BeautyProBaseController
    {

        private readonly IProductService _productService;

        public ProductsController(
            IHttpContextAccessor httpContextAccessor,
            IProductService productService) : base(httpContextAccessor)
        {
            _productService = productService;
        }

        [HttpGet()]
        public IActionResult GetAllProducts()
        {
            return Ok(_productService.GetAllProducts(BranchId));
        }

    }
}
using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.EF.Interfaces;
using BeautyPro.CRM.Mapper;
using BeautyProCRM.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyProCRM.Business
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductDTO> GetAllProducts(int branchId)
        {
            var products = _productRepository
                .All
                .Include(c => c.ProductSellingPrice)
                .Where(c => !c.IsDeleted && c.BranchId == branchId).ToList();

            return DomainDTOMapper.ToProductDTOs(products);
        }
    }
}

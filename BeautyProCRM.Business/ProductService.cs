using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.EF.Interfaces;
using BeautyPro.CRM.Mapper;
using BeautyProCRM.Business.Interfaces;
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
            return DomainDTOMapper.ToProductDTOs(_productRepository.All
                .Where(c => !c.IsDeleted && c.BranchId == branchId).ToList());
        }
    }
}

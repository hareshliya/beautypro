using BeautyPro.CRM.Contract.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyProCRM.Business.Interfaces
{
    public interface IProductService
    {
        List<ProductDTO> GetAllProducts(int branchId);
    }
}

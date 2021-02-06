using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetAllByUnitPrice(decimal min, decimal max);

        List<ProductDetailDto> GetProductDetails();
    }
}

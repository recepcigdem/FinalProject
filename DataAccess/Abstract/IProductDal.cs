using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        List<Product> GetAll();
        //Product GetProductById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        List<Product> GetAllByCategoryId(int categoryId);
    }
}

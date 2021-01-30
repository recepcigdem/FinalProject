using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICategoryDal
    {
        List<Category> GetAll();
       // Category GetCategoryById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}

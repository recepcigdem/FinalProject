using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCategoryDal:ICategoryDal
    {
        private List<Category> _categories;

        public InMemoryCategoryDal()
        {
            _categories = new List<Category>
            {
                new Category {CategoryId = 1,CategoryName = "Bilgisayar"},

                new Category {CategoryId = 2,CategoryName = "Aksesuar"},
            };
        }


        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return _categories;
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public void Update(Category category)
        {
            Category categoryToUpdate = _categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);

           categoryToUpdate.CategoryId = category.CategoryId;
           categoryToUpdate.CategoryName = category.CategoryName;
        }

        public void Delete(Category category)
        {
            Category categoryToDelete = _categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);

            _categories.Remove(categoryToDelete);
        }
    }
}

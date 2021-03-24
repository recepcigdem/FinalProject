using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private ICategoryService _categoryService;


        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [CacheAspect]//key,value
        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 23)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintrnanceTime);
            //}
            return new SuccessDataResult<List<Product>>(true, Messages.ProductListed, _productDal.GetAll());
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {

            return new SuccessDataResult<List<Product>>(true, Messages.ProductListed, _productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(true, Messages.ProductListed, _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintrnanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(true, Messages.ProductListed, _productDal.GetProductDetails());
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(true, Messages.ProductListed, _productDal.Get(p => p.ProductId == productId));
        }

        [SecuredOperation("admin,product.add")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product), CheckIfProductNameExists(product), CheckIfCategoryLimitExceded(product.CategoryId));

            if (result != null)
            {
                return result;

            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product), CheckIfProductNameExists(product), CheckIfCategoryLimitExceded(product.CategoryId));

            if (result != null)
            {
                return result;

            }
            _productDal.Update(product);

            return new SuccessResult(Messages.ProductUpdated);


        }
        [TransactionScopeAspect]
        public IResult AddTransactionTest(Product product)
        {
            Add(product);

            Add(product);

            return null;
        }

        private IResult CheckIfProductCountOfCategoryCorrect(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;

            if (result >= 10)
                new ErrorResult(Messages.ProductCountOfCategoryError);

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(Product product)
        {
            var result = _productDal.GetAll(p => p.ProductName == product.ProductName).Any();

            if (result)
                new ErrorResult(Messages.ProductNameAlreadyExists);

            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded(int categoryId)
        {
            var result = _categoryService.GetAll();

            if (result.Data.Count > 15)
                new ErrorResult(Messages.CategoryLimitExceded);

            return new SuccessResult();
        }

    }
}

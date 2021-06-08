using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
            
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {

            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),KategoriLimitiKolntrol()); // bu kurallar uyuyorsa result boş dönecektir

            if (result != null)//kurala uymayan bir durum oluşmusa 
            {
                return result;
            }
                 
             _productDal.Add(product);
             return new SuccessResult(Messages.ProductAdded);

        }

        public IResult Delete(int Id)
        {

            var result = _productDal.Get(p => p.ProductId == Id);
            _productDal.Delete(result);
            return new SuccessResult(Messages.ProductDeleted);

        }


        [CacheAspect] // key, value 
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {

                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int productid)
        {
            
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productid));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }


        
 
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId) // iş kuralı parçacığı, kategoriye max 15 ürün eklenebilir 
        {
            //Select count(*) from products where productId=1 link querisini oluşturup db ye yolluyoruz
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName) 
        {
            //Select count(*) from products where productId=1 link querisini oluşturup db ye yolluyoruz
            var result = _productDal.GetAll(p => p.ProductName == productName).Any(); // any var mı yok mu kontrol eder bool değer döndürür
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult KategoriLimitiKolntrol()    // iş kuralı parçacığı, kategoriye max 15 ürün eklenebilir 
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count >= 15)
            {
                return new ErrorResult(Messages.KategoriLimitiAsildi);
            }
            return new SuccessResult();     
        }


    }
}

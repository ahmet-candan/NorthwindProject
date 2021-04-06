using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{

    
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product> {
            new Product{CategoryId=1,ProductId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
            new Product{CategoryId=1,ProductId=2,ProductName="Kşık",UnitPrice=2,UnitsInStock=20},
            new Product{CategoryId=2,ProductId=3,ProductName="Fare",UnitPrice=50,UnitsInStock=25},
            new Product{CategoryId=2,ProductId=4,ProductName="Mouse",UnitPrice=100,UnitsInStock=30},
            new Product{CategoryId=2,ProductId=5,ProductName="Monitör",UnitPrice=500,UnitsInStock=35}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p=> p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int catttegoryId)
        {
            // where içindeki şarta uyan tüm elemanları liste haline getirir ve onu döndürür 
            return _products.Where(p => p.CategoryId == catttegoryId).ToList();
             
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
           

        }
    }
}

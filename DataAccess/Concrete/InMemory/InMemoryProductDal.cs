﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal :IProductDal
    {
        private readonly List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>()
            {
                new Product{ProductId = 1, CategoryId = 1,ProductName = "Laptop" , UnitPrice = 2000 , UnitsInStock = 15},
                new Product{ProductId = 2,CategoryId = 1,ProductName = "Kamera" , UnitPrice = 2500 , UnitsInStock = 12},
                new Product{ProductId = 3,CategoryId = 2,ProductName = "Bardak" , UnitPrice = 2 , UnitsInStock = 10},
                new Product{ProductId = 4,CategoryId = 2,ProductName = "Tencere" , UnitPrice = 140 , UnitsInStock = 1},
                new Product{ProductId = 5,CategoryId = 2,ProductName = "Fare" , UnitPrice = 100 , UnitsInStock = 6}
            };
        }
        
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.UnitPrice = product.UnitPrice;
                productToUpdate.UnitsInStock = product.UnitsInStock;
            }
            else
            {
                Console.WriteLine("Ürün Bulunamadı..");
            }
        }

        public void Delete(Product product)
        {
            var productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;
using DomainModel.Abstract;

namespace DomainModel.Concrete
{
    public class FakeProductsRepository : IProductsRepository
    {
        // Fake hard-coded list of products
        private static IQueryable<Product> fakeProducts = new List<Product> {
            new Product { Name = "California Roll", Price = 5 },
            new Product { Name = "Shrimp Tempura Roll", Price = 8 },
            new Product { Name = "Spicy Tuna Roll", Price = 6 }
        }.AsQueryable();

        public IQueryable<Product> Products
        {
            get { return fakeProducts; }
        }
    }
}

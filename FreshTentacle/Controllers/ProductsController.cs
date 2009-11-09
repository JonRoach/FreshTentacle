using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DomainModel.Abstract;
using DomainModel.Concrete;

namespace FreshTentacle.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsRepository productsRepository;
        public ProductsController()
        {
            // Temporary hard-coded connection string until we setup Inversion of Control
            string connString = @"Server=.\SQLEXPRESS;Database=FreshTentacle;Trusted_Connection=yes;";
            productsRepository = new SqlProductsRepository(connString);
            
        }

        public ViewResult List()
        {
            return View(productsRepository.Products.ToList());
        }

    }
}

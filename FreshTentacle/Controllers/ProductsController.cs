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
        public ProductsController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public ViewResult List()
        {
            return View(productsRepository.Products.ToList());
        }

    }
}

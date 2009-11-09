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
        public int PageSize = 4; // Will change later
        private IProductsRepository productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public ViewResult List(int page)
        {
            int numProducts = productsRepository.Products.Count();
            ViewData["TotalPages"] = (int)Math.Ceiling((double)numProducts / PageSize);
            ViewData["CurrentPage"] = page;

            return View(productsRepository.Products
                                          .Skip((page - 1) * PageSize)
                                          .Take(PageSize)
                                          .ToList()
                        );
        }

    }
}

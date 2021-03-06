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

        public ViewResult List(string category, int page)
        {
            var productsInCategory = (category == null) ? productsRepository.Products : productsRepository.Products.Where(x => x.Category == category);

            int numProducts = productsInCategory.Count();
            ViewData["TotalPages"] = (int)Math.Ceiling((double)numProducts / PageSize);
            ViewData["CurrentPage"] = page;
            ViewData["CurrentCategory"] = category; // For use when generating page links

            return View(productsInCategory
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize)
                            .ToList()
                        );
        }

    }
}

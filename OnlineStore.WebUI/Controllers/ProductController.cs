using OnlineStore.Domain.Abstract;
using OnlineStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.WebUI.HtmlHelpers;

namespace OnlineStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductRepository repository;
        public int PageSize = 2;
        
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? 
                      repository.Products.Count() + PageSize :
                      repository.Products.Where(p => p.Category == category).Count() + PageSize
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}
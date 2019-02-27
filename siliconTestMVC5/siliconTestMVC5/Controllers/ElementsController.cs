using siliconTestMVC5.Models;
using siliconTestMVC5.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;
using System.Data.Entity;

namespace siliconTestMVC5.Controllers
{
    public class ElementsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Elements
        public object CategoriesIndex(int? page)
        {

           // List<Category> categories = context.Categories.ToList(); //returns IQueryable<Product> representing an unknown number of products. a thousand maybe?

           var categories =  context.Categories.Select(p => new ViewCategoriesModel { Item = p, ChildrenCount = p.Products.Count() }).ToList();

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfProducts = categories.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
        }

        public object ProductsIndex(int? page)
        {
            int pagesInList = 10;

            var products = context.Products.ToList<Product>();


            var pageNumber = page ?? 1;
            var onePageOfProducts = products.ToPagedList(pageNumber, pagesInList);

            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
        }

        

    }
}
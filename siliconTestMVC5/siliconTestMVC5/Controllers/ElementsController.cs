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
        readonly ApplicationDbContext _context = new ApplicationDbContext();
        private static int _itemsInView = 10;
        private static int _lastOrdered = 0;

        // GET: Elements
        public object CategoriesIndex(int? page)
        {

           // List<Category> categories = context.Categories.ToList(); //returns IQueryable<Product> representing an unknown number of products. a thousand maybe?

           var categories =  _context.Categories.Select(p => new ViewCategoriesModel { Item = p, ChildrenCount = p.Products.Count() }).ToList();

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfProducts = categories.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
        }

        public object ProductsIndex(int? page, int? itemsCount, int? sortCase)
        {

            _itemsInView = itemsCount ?? _itemsInView; 
            var pageNumber = page ?? 1;

            var products = Order(_context.Products.ToList<Product>(), sortCase);

            var onePageOfProducts = products.ToPagedList(pageNumber, _itemsInView);

            ViewBag.SelectedList = new SelectList(new[] {10, 25, 50, 100});
            ViewBag.ItemsCount = _itemsInView.ToString();
            ViewBag.CurrentPage = page;
            ViewBag.OnePageOfProducts = onePageOfProducts;

            return View();
        }


        private List<Product> Order(List<Product> items, int? caseType)
        {
            switch (caseType)
            {
                case 1:
                    if (_lastOrdered == 0 || _lastOrdered != 1)
                    {
                        _lastOrdered = 1;
                        return items.OrderBy(p => p.Name).ToList();
                    }
                    _lastOrdered = 0;
                    return items.OrderByDescending(p => p.Name).ToList();
                case 2:
                    if (_lastOrdered == 0 || _lastOrdered != 2)
                    {
                        _lastOrdered = 2;
                        return items.OrderBy(p => p.Price).ToList();
                    }
                    _lastOrdered = 2;
                    return items.OrderByDescending(p => p.Price).ToList();
                case 3:
                    if (_lastOrdered == 0 || _lastOrdered != 3)
                    {
                        _lastOrdered = 3;
                        return items.OrderBy(p => p.Count).ToList();
                    }
                    _lastOrdered = 3;
                    return items.OrderByDescending(p => p.Count).ToList();
                default:
                    
                    _lastOrdered = 0;
                    return items;
            }
        }
    }
}
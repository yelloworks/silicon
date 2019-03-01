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

        // GET: Elements
        public object CategoriesIndex(int? page)
        {
            var categories = _context.Categories
                .Select(p => new ViewCategoriesModel {Item = p, ChildrenCount = p.Products.Count()}).ToList();

            var pageNumber = page ?? 1;
            var onePageOfProducts = categories.ToPagedList(pageNumber, 10);

            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
        }

        public object ProductsIndex(int? page, int? itemsCount, int? sortCase)
        {

            sortCase = sortCase ?? 0;
            _itemsInView = itemsCount ?? _itemsInView; 
            var pageNumber = page ?? 1;

            var products = Order(_context.Products.ToList<Product>(), sortCase);

            var onePageOfProducts = products.ToPagedList(pageNumber, _itemsInView);

            var categories = new SelectList(_context.Categories.ToList(), "Name", "Name");
            

            ViewBag.SelectedList = new SelectList(new[] {10, 25, 50, 100}, itemsCount);
            ViewBag.SortStatus = sortCase;
            ViewBag.ItemsCount = _itemsInView.ToString();
            ViewBag.CurrentPage = page;
            ViewBag.OnePageOfProducts = onePageOfProducts;

            return View(categories);
        }


        private List<Product> Order(List<Product> items, int? caseType)
        {
            switch (caseType)
            {
                case 10:
                    return items.OrderBy(p => p.Name).ToList();
                case 11:
                    return items.OrderByDescending(p => p.Name).ToList();
                case 20:
                    return items.OrderBy(p => p.Price).ToList();
                case 21:
                    return items.OrderByDescending(p => p.Price).ToList();
                case 30:
                    return items.OrderBy(p => p.Count).ToList();
                case 31:
                    return items.OrderByDescending(p => p.Count).ToList();
                default:
                    return items;
            }
        }
    }
}
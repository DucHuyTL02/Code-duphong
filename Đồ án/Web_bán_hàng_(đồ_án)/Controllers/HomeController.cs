using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_bán_hàng__đồ_án_.Models;
using Web_bán_hàng__đồ_án_.Models.ViewModel;

namespace Web_bán_hàng__đồ_án_.Controllers
{
    public class HomeController : Controller
    { 
        LTWEntities csdl = new LTWEntities();
        public ActionResult trangchu(string searchTerm ,int? page)
        { 
            var model = new HomeProductVM();
            var products = csdl.Products.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                model.SearchTerm = searchTerm;
                products = products.Where(p => p.ProductName.Contains(searchTerm) || p.ProductDescription.Contains(searchTerm) || p.Category.CategoryName.Contains(searchTerm));
            }
            int pageNumber = page ?? 1;
            int pageSize = 4;
            model.FeaturedProducts = products.OrderByDescending(p=>p.OrderDetails.Count()).Take(4).ToList();
            model.NewProducts=products.OrderBy(p => p.OrderDetails.Count()).Take(10).ToPagedList(pageNumber, pageSize);
            return View(model);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult MenWatches()
        {

            return View(csdl.Products.ToList());
        }
        public ActionResult WomenWatches()
        {

            return View();
        }
        public ActionResult CoupleWatches()
        {

            return View();
        }
        public ActionResult Banner()
        {
            return View();
        }
    }
}
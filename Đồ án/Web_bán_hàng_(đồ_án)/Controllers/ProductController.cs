using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_bán_hàng__đồ_án_.Models;
using Web_bán_hàng__đồ_án_.Models.ViewModel;

namespace Web_bán_hàng__đồ_án_.Controllers
{
    public class ProductController : Controller
    {
        LTWEntities csdl = new LTWEntities();   
        // GET: Product
        public ActionResult ProductDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = csdl.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult ProductList()
        {
            var products = csdl.Products.ToList();
            return View(products);
        }
        public ActionResult Category(int categoryId)
        {
            // Lấy danh sách sản phẩm theo danh mục
            var products = csdl.Products
                .Where(p => p.CategoryID == categoryId)
                .ToList();

            // Lấy thông tin danh mục để hiển thị tên trên View
            var category = csdl.Categories
                .FirstOrDefault(c => c.CategoryID == categoryId);

            if (category == null)
            {
                return HttpNotFound("Danh mục không tồn tại.");
            }

            // Truyền dữ liệu vào ViewModel (nếu cần thiết)
            var viewModel = new HomeProductVM()
            {
                Products = products,
                CategoryName = category.CategoryName
            };

            return View(viewModel);
        }

        public ActionResult Xacnhan()
        {
            return View();
        }

        public ActionResult Thanhtoan()
        {
            return View();
        }

        public ActionResult Giohang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateQuantity(int id, int quantity)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RemoveItem(int id)
        {
            return View();
        }
    }
}
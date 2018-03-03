using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMedia.Core.Models;
using WebMedia.DAL.DataContext;

namespace WebMedia.Controllers
{
    public class ProductController : Controller
    {
        ProductDC pdc = new ProductDC();

        public ActionResult ProductList()
        {
            List<Product> products = pdc.ProductList();
            return View(products);
        }
        public ActionResult AddProductPage()
        {
            return View();
        }
        public ActionResult AddProduct(Product product)
        {
            Product productToCreate = new Product(product.Name,product.Category,product.Price);
            string test = product.Id;
            pdc.AddProduct(productToCreate);
            return RedirectToAction("ProductList");
        }
    }
}
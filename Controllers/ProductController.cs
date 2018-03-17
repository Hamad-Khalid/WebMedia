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
            Product productToCreate = new Product(product.Name, product.Category, product.Price);
            pdc.AddProduct(productToCreate);
            return RedirectToAction("ProductList");
        }
        public ActionResult DeleteProductPage(int Height, string id, string message = "")
        {
            Product productToDelete = pdc.FindProductById(id);
            ViewBag.message = message;
            return View(productToDelete);
        }

        public ActionResult DeleteProduct(string Id)
        {
            if (pdc.DeleteProduct(Id)) return RedirectToAction("ProductList");
            else
            {
                return RedirectToAction("DeleteProductPage", new { Height =20, id = Id, message = "Not Found" });
            }

        }

        public ActionResult UpdateProductPage(string id)
        {
            Product product = pdc.FindProductById(id);
            return View(product);
        }

        public ActionResult UpdateProduct(Product product) 
        {
            pdc.UpdateProduct(product);
            return RedirectToAction("UpdateProductPage",new { id = product.Id});
        }
    }
}
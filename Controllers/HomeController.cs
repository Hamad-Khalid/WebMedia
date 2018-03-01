using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMedia.Core.Models;
using WebMedia.DAL.DataContext;
    namespace WebMedia.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Product product = new Product("Chess", "Board Game", 10);
            ProductDC pdc = new ProductDC();
            pdc.AddProduct(product);
            return View();
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3.Models;

namespace MVC3.Controllers
{
    public class ProductController : Controller
    {
        ProductList ProductList = new ProductList();

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/

        public ActionResult Index()
        {
            List<PLProduct> plProduct = new List<PLProduct>();

            List<SLProduct.ProductInfo> ProductList = this.ProductList.GettheProductList();

            for (int i = 0; i < ProductList.Count; i++)
            {
                plProduct.Add(ProductClientService.DTO_to_PL_Product(ProductList[i]));
            }


            return View("Index", plProduct);
        }

        public ActionResult Details(int id)
        {
            SLProduct.ProductInfo Product = this.ProductList.GetProductDetail(id - 1);

            PLProduct plProduct = ProductClientService.DTO_to_PL_Product(Product);

            return View("Details", plProduct);
        }

        public ActionResult Edit(int id)
        {
            SLProduct.ProductInfo Product = this.ProductList.GetProductDetail(id - 1);

            PLProduct plProduct = ProductClientService.DTO_to_PL_Product(Product);

            return View("Edit", plProduct);
        }

        public ActionResult GetAll()
        {
            List<PLProduct> plProduct = new List<PLProduct>();

            List<SLProduct.ProductInfo> ProductList = this.ProductList.GettheProductList();

            for (int i = 0; i < ProductList.Count; i++)
            {
                plProduct.Add(ProductClientService.DTO_to_PL_Product(ProductList[i]));
            }


            return View("Index", plProduct);
        }

        public ActionResult GetAvailable()
        {
            List<PLProduct> plProduct = new List<PLProduct>();

            List<SLProduct.ProductInfo> ProductList = this.ProductList.GettheProductList();

            for (int i = 0; i < ProductList.Count; i++)
            {
                plProduct.Add(ProductClientService.DTO_to_PL_Product(ProductList[i]));
            }


            return View("Index", plProduct);
        }

        public ActionResult GetDeleted()
        {
            List<PLProduct> plProduct = new List<PLProduct>();

            List<SLProduct.ProductInfo> ProductList = this.ProductList.GettheProductList();

            for (int i = 0; i < ProductList.Count; i++)
            {
                plProduct.Add(ProductClientService.DTO_to_PL_Product(ProductList[i]));
            }


            return View("Index", plProduct);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3.Models;

namespace MVC3.Controllers
{
    public class ProductVariationController : Controller
    {
        ProductVariationList pvList = new ProductVariationList();

        public ActionResult Create()
        {
            AllProductInfo api = new AllProductInfo();
            return View("Create", api);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                PLProductVariation plpv = new PLProductVariation();
                plpv.pv_id = 10;
                plpv.product_id = int.Parse(collection["product_id"]);
                plpv.brand_id = int.Parse(collection["brand_id"]);
                plpv.product_color_id = int.Parse(collection["color_id"]);
                plpv.product_cutting_id = int.Parse(collection["cutting_id"]);
                plpv.product_type_id = int.Parse(collection["type_id"]);
                plpv.sex = char.Parse(collection["sex"]);
                plpv.size = collection["size"];
                plpv.stock = int.Parse(collection["stock"]);
                plpv.price = float.Parse(collection["price"]);
                plpv.condition = char.Parse(collection["condition"]);

                ProductVariationClientService.CreateProductVariation(plpv);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        //
        // GET: /ProductVariation/

        public ActionResult Index()
        {
            List<PLProductVariation> plpv = new List<PLProductVariation>();

            List<SLProductVariation.ProductVariationInfo> pvList = this.pvList.GetPVList('z');

            for (int i = 0; i < pvList.Count; i++)
            {
                plpv.Add(ProductVariationClientService.DTO_to_PL(pvList[i]));
            }

            AllProductInfo api = new AllProductInfo();
            api.pvList = plpv;
            return View("Index", api);
        }

        public ActionResult Details(int id)
        {
            SLProductVariation.ProductVariationInfo pv = this.pvList.GetPVDetail(id - 1);

            PLProductVariation plpv = ProductVariationClientService.DTO_to_PL(pv);

            return View("Details", plpv);
        }

        public ActionResult Edit(int id)
        {
            SLProductVariation.ProductVariationInfo pv = this.pvList.GetPVDetail(id);

            PLProductVariation plpv = ProductVariationClientService.DTO_to_PL(pv);

            AllProductInfo api = new AllProductInfo();

            api.pvList[0] = plpv;

            return View("Edit", api);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                PLProductVariation plpv = new PLProductVariation();
                plpv.pv_id = int.Parse(collection["pv_id"]);
                plpv.product_id = int.Parse(collection["products"]);
                plpv.brand_id = int.Parse(collection["brands"]);
                plpv.product_color_id = int.Parse(collection["colors"]);
                plpv.product_cutting_id = int.Parse(collection["cuttings"]);
                plpv.product_type_id = int.Parse(collection["types"]);
                plpv.sex = char.Parse(collection["sexes"]);
                plpv.size = collection["sizes"];
                plpv.stock = int.Parse(collection["stocks"]);
                plpv.price = float.Parse(collection["prices"]);
                plpv.condition = char.Parse(collection["condition"]);

                ProductVariationClientService.UpdateProductVariation(plpv);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("HERE IS THE ERROR: " + e.ToString());
                AllProductInfo api = new AllProductInfo();
                return View("Index", api);
            }
        }

        public ActionResult Delete(int id)
        {
            SLProductVariation.SLProductVariationClient slpv = new SLProductVariation.SLProductVariationClient();
            string[] errors = new string[0];
            slpv.DeletePV(id, ref errors);
            AllProductInfo api = new AllProductInfo();
            //api.pvList[id] = ProductVariationClientService.ReadProductVariationDetail(id);
            return View("Index", api);
        }

        public ActionResult GetAll()
        {
            List<PLProductVariation> plpv = new List<PLProductVariation>();

            List<SLProductVariation.ProductVariationInfo> pvList = this.pvList.GetPVList('z');

            for (int i = 0; i < pvList.Count; i++)
            {
                plpv.Add(ProductVariationClientService.DTO_to_PL(pvList[i]));
            }

            AllProductInfo api = new AllProductInfo();
            api.pvList = plpv;
            return View("Index", api);
        }

        public ActionResult GetAvailable()
        {
            List<PLProductVariation> plpv = new List<PLProductVariation>();

            List<SLProductVariation.ProductVariationInfo> pvList = this.pvList.GetPVList('a');

            AllProductInfo api = new AllProductInfo();

            for (int i = 0; i < pvList.Count; i++)
            {
                plpv.Add(ProductVariationClientService.DTO_to_PL(pvList[i]));
            }

            api.pvList = plpv;

            return View("Index", api);
        }

        public ActionResult GetDeleted()
        {
            List<PLProductVariation> plpv = new List<PLProductVariation>();

            List<SLProductVariation.ProductVariationInfo> pvList = this.pvList.GetPVList('d');

            AllProductInfo api = new AllProductInfo();

            for (int i = 0; i < pvList.Count; i++)
            {
                plpv.Add(ProductVariationClientService.DTO_to_PL(pvList[i]));
            }

            api.pvList = plpv;

            return View("Index", api);
        }
    }
}

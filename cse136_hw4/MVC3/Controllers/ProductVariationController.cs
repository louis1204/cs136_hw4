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

            
            return View("Index", plpv);
        }

        public ActionResult Details(int id)
        {
            SLProductVariation.ProductVariationInfo pv = this.pvList.GetPVDetail(id - 1);

            PLProductVariation plpv = ProductVariationClientService.DTO_to_PL(pv);

            return View("Details", plpv);
        }

        public ActionResult Edit(int id)
        {
            SLProductVariation.ProductVariationInfo pv = this.pvList.GetPVDetail(id - 1);

            PLProductVariation plpv = ProductVariationClientService.DTO_to_PL(pv);

            return View("Edit", plpv);
        }

        public ActionResult GetAll()
        {
            List<PLProductVariation> plpv = new List<PLProductVariation>();

            List<SLProductVariation.ProductVariationInfo> pvList = this.pvList.GetPVList('z');

            for (int i = 0; i < pvList.Count; i++)
            {
                plpv.Add(ProductVariationClientService.DTO_to_PL(pvList[i]));
            }


            return View("Index", plpv);
        }

        public ActionResult GetAvailable()
        {
            List<PLProductVariation> plpv = new List<PLProductVariation>();

            List<SLProductVariation.ProductVariationInfo> pvList = this.pvList.GetPVList('a');

            for (int i = 0; i < pvList.Count; i++)
            {
                plpv.Add(ProductVariationClientService.DTO_to_PL(pvList[i]));
            }


            return View("Index", plpv);
        }

        public ActionResult GetDeleted()
        {
            List<PLProductVariation> plpv = new List<PLProductVariation>();

            List<SLProductVariation.ProductVariationInfo> pvList = this.pvList.GetPVList('d');

            for (int i = 0; i < pvList.Count; i++)
            {
                plpv.Add(ProductVariationClientService.DTO_to_PL(pvList[i]));
            }


            return View("Index", plpv);
        }
    }
}

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

            List<SLProductVariation.ProductVariationInfo> pvList = this.pvList.GetPVList();

            for (int i = 0; i < pvList.Count; i++)
            {
                plpv.Add(ProductVariationClientService.DTO_to_PL(pvList[i]));
            }

            
            return View("Index", plpv);
        }

        public ActionResult Details(int id)
        {
            SLProductVariation.ProductVariationInfo pv = this.pvList.GetPVDetail(id);
            return View("Details", pv);
        }
    }
}

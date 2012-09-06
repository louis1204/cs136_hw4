using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3.Models;

namespace MVC3.Controllers
{
    public class BrandController : Controller
    {
        BrandList BrandList = new BrandList();

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
        // GET: /Brand/

        public ActionResult Index()
        {
            List<PLBrand> plBrand = new List<PLBrand>();

            List<SLBrand.BrandInfo> BrandList = this.BrandList.GetBrandList();

            for (int i = 0; i < BrandList.Count; i++)
            {
                plBrand.Add(BrandClientService.DTO_to_PL_Brand(BrandList[i]));
            }


            return View("Index", plBrand);
        }

        public ActionResult Details(int id)
        {
            SLBrand.BrandInfo Brand = this.BrandList.GetBrandDetail(id - 1);

            PLBrand plBrand = BrandClientService.DTO_to_PL_Brand(Brand);

            return View("Details", plBrand);
        }

        public ActionResult Edit(int id)
        {
            SLBrand.BrandInfo Brand = this.BrandList.GetBrandDetail(id - 1);

            PLBrand plBrand = BrandClientService.DTO_to_PL_Brand(Brand);

            return View("Edit", plBrand);
        }

        public ActionResult GetAll()
        {
            List<PLBrand> plBrand = new List<PLBrand>();

            List<SLBrand.BrandInfo> BrandList = this.BrandList.GetBrandList();

            for (int i = 0; i < BrandList.Count; i++)
            {
                plBrand.Add(BrandClientService.DTO_to_PL_Brand(BrandList[i]));
            }


            return View("Index", plBrand);
        }

        public ActionResult GetAvailable()
        {
            List<PLBrand> plBrand = new List<PLBrand>();

            List<SLBrand.BrandInfo> BrandList = this.BrandList.GetBrandList();

            for (int i = 0; i < BrandList.Count; i++)
            {
                plBrand.Add(BrandClientService.DTO_to_PL_Brand(BrandList[i]));
            }


            return View("Index", plBrand);
        }

        public ActionResult GetDeleted()
        {
            List<PLBrand> plBrand = new List<PLBrand>();

            List<SLBrand.BrandInfo> BrandList = this.BrandList.GetBrandList();

            for (int i = 0; i < BrandList.Count; i++)
            {
                plBrand.Add(BrandClientService.DTO_to_PL_Brand(BrandList[i]));
            }


            return View("Index", plBrand);
        }
    }
}

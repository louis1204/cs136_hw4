using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
    public class AllProductInfo
    {
        //
        // GET: /AllProductInfo/
        public List<PLProductVariation> pvList {get; set;}
        public List<PLProduct> productList{get;set;}
        public List<PLBrand> brandList{get;set;}
        public List<PLProductColor> colorList{get;set;}
        public List<PLProductCutting> cuttingList{get;set;}
        public List<PLProductType> typeList{get;set;}

        public AllProductInfo()
        {
            pvList = ProductVariationClientService.ReadAllPV();
            productList = ProductClientService.ReadAllProduct();
            brandList = BrandClientService.ReadAllBrand();
            colorList = ProductColorClientService.ReadAllProductColor();
            cuttingList = ProductCuttingClientService.ReadAllProductCutting();
            typeList = ProductTypeClientService.ReadAllProductType();
        }

    }
}

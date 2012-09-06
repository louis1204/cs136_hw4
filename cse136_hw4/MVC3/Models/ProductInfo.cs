using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models
{

    public class ProductInfo
    {
        public int product_id { get; set; }
        public string product_name { get; set; }

        public ProductInfo(int product_id_in, string product_name_in)
        {
            this.product_id = product_id_in;
            this.product_name = product_name_in;
        }
    }
}
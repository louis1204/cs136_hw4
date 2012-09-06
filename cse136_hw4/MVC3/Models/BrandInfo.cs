using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models
{

    public class BrandInfo
    {
        public int brand_id { get; set; }
        public string brand_name { get; set; }

        public BrandInfo(int brand_id_in, string brand_name_in)
        {
            this.brand_id = brand_id_in;
            this.brand_name = brand_name_in;
        }
    }
}
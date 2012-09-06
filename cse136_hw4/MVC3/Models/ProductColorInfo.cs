using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models
{

    public class ProductColorInfo
    {
        public int Color_id { get; set; }
        public string Color_name { get; set; }

        public ProductColorInfo(int Color_id_in, string Color_name_in)
        {
            this.Color_id = Color_id_in;
            this.Color_name = Color_name_in;
        }
    }
}

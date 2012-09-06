using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models
{

    public class ProductCuttingInfo
    {
        public int Cutting_id { get; set; }
        public string Cutting_name { get; set; }

        public ProductCuttingInfo(int Cutting_id_in, string Cutting_name_in)
        {
            this.Cutting_id = Cutting_id_in;
            this.Cutting_name = Cutting_name_in;
        }
    }
}

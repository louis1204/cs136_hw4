using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models
{

    public class ProductTypeInfo
    {
        public int Type_id { get; set; }
        public string Type_name { get; set; }

        public ProductTypeInfo(int Type_id_in, string Type_name_in)
        {
            this.Type_id = Type_id_in;
            this.Type_name = Type_name_in;
        }
    }
}

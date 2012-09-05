using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models
{

    public class ProductVariationInfo
    {
        public int product_variation_id { get; set; }
        public int product_id { get; set; }
        public int product_brand_id { get; set; }
        public int product_cutting_id { get; set; }
        public int product_color_id { get; set; }
        public int product_type_id { get; set; }
        public char sex { get; set; }
        public string size { get; set; }
        public int stock { get; set; }
        public float price { get; set; }
        public char condition { get; set; }

        public ProductVariationInfo(int product_variation_id_in, int product_id_in,
            int product_brand_id_in, int product_cutting_id_in,
            int product_color_id_in, int product_type_id_in,
            char sex_in, string size_in, int stock_in, float price_in, char condition_in)
        {
            this.product_variation_id = product_variation_id_in;
            this.product_id = product_color_id_in;
            this.product_brand_id = product_brand_id_in;
            this.product_cutting_id = product_cutting_id_in;
            this.product_color_id = product_color_id_in;
            this.product_type_id = product_type_id_in;
            this.sex = sex_in;
            this.size = size_in;
            this.stock = stock_in;
            this.price = price_in;
            this.condition = condition_in;
        }
    }
}
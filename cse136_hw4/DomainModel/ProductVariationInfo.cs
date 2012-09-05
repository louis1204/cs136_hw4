using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace DomainModel
{
    [DataContract]
    public class ProductVariationInfo
    {
        [DataMember]
        public int product_variation_id { get; set; }
        [DataMember]
        public int product_id { get; set; }
        [DataMember]
        public int product_brand_id { get; set; }
        [DataMember]
        public int product_cutting_id { get; set; }
        [DataMember]
        public int product_color_id { get; set; }
        [DataMember]
        public int product_type_id { get; set; }
        [DataMember]
        public char sex { get; set; }
        [DataMember]
        public string size { get; set; }
        [DataMember]
        public int stock { get; set; }
        [DataMember]
        public float price { get; set; }
        [DataMember]
        public char condition { get; set; }


        public ProductVariationInfo(ProductVariationInfo pv)
        {
            this.product_variation_id = pv.product_variation_id;
            this.product_id = pv.product_color_id;
            this.product_brand_id = pv.product_brand_id;
            this.product_cutting_id = pv.product_cutting_id;
            this.product_color_id = pv.product_color_id;
            this.product_type_id = pv.product_type_id;
            this.sex = pv.sex;
            this.size = pv.size;
            this.stock = pv.stock;
            this.price = pv.price;
            this.condition = pv.condition;
        }


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

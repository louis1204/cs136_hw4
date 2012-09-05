using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace DomainModel
{
    [DataContract]
    public class ProductInfo
    {
        [DataMember]
        public int product_id { get; set; }
        [DataMember]
        public String product_name { get; set; }

        public ProductInfo(int product_id_in, String product_name_in)
        {
            this.product_id = product_id_in;
            this.product_name = product_name_in;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace DomainModel
{
    [DataContract]
    public class ProductCuttingInfo
    {
        [DataMember]
        public int product_cutting_id { get; set; }
        [DataMember]
        public String product_cutting_name { get; set; }

        public ProductCuttingInfo(int product_cutting_id_in, String product_cutting_name_in)
        {
            this.product_cutting_id = product_cutting_id_in;
            this.product_cutting_name = product_cutting_name_in;
        }
    }
}

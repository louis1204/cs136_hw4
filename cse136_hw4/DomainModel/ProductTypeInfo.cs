using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace DomainModel
{
    [DataContract]
    public class ProductTypeInfo
    {
        [DataMember]
        public int product_type_id { get; set; }
        [DataMember]
        public String product_type_name { get; set; }

        public ProductTypeInfo(int product_type_id_in, String product_type_name_in)
        {
            this.product_type_id = product_type_id_in;
            this.product_type_name = product_type_name_in;
        }
    }
}

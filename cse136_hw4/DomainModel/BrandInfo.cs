using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace DomainModel
{
    [DataContract]
    public class BrandInfo
    {
        [DataMember]
        public int brand_id { get; set; }
        [DataMember]
        public String brand_name { get; set; }

        public BrandInfo(int brand_id_in, String brand_name_in)
        {
            this.brand_id = brand_id_in;
            this.brand_name = brand_name_in;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required


namespace DomainModel
{
    [DataContract]
    public class Order_item
    {
        [DataMember]
        public int order_id;

        [DataMember]
        public int product_variation_id;

        [DataMember]
        public float tax = 0;

        [DataMember]
        public int quantity = 0;

        [DataMember]
        public float sale_price = 0;

        [DataMember]
        public char condition = 'a';

    }
}

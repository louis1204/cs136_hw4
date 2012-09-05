using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace DomainModel
{
    [DataContract]
    public class Orders
    {
        [DataMember]
        public int order_id;

        [DataMember]
        public int customer_id;

        [DataMember]
        public float subtotal = 0;

        [DataMember]
        public float tax_total = 0;

        [DataMember]
        public float grand_total = 0;

        [DataMember]
        public DateTime date_created;

        [DataMember]
        public char condition = 'a';

        [DataMember]
        public List<Order_item> oil;
    }
}

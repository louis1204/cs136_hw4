using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DomainModel;
using BL;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SLCustomer" in code, svc and config file together.
    public class SLCustomer : ISLCustomer
    {
        public void CreateCustomer(Customer users, ref List<string> errors)
        {
            BLCustomer.CreateCustomer(users, ref errors);
        }

        public Customer ReadCustomer(int id, ref List<string> errors)
        {
            return BLCustomer.ReadCustomer(id, ref errors);
        }

        public List<Customer> ReadCustomers(ref List<string> errors)
        {
            return BLCustomer.ReadCustomers(ref errors);
        }

        public void UpdateCustomer(Customer customers, ref List<string> errors)
        {
            BLCustomer.UpdateCustomer(customers, ref errors);
        }
    }
}

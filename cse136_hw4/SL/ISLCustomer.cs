using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DomainModel; // this is required
using BL; // this is required

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISLCustomer" in both code and config file together.
    [ServiceContract]
    public interface ISLCustomer
    {
        [OperationContract]
        void CreateCustomer(Customer users, ref List<string> errors);

        [OperationContract]
        Customer ReadCustomer(int id, ref List<string> errors);

        [OperationContract]
        List<Customer> ReadCustomers(ref List<string> errors);

        [OperationContract]
        void UpdateCustomer(Customer customers, ref List<string> errors);

    }
}

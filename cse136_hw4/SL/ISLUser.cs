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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISLUser" in both code and config file together.
    [ServiceContract]
    public interface ISLUser
    {
        [OperationContract]
        void CreateUser(Users users, ref List<string> errors);

        [OperationContract]
        Users ReadUser(int id, ref List<string> errors);

        [OperationContract]
        List<Users> ReadUsers(ref List<string> errors);

        [OperationContract]
        void UpdateUser(Users users, ref List<string> errors);

        [OperationContract]
        void DeleteUser(int id, ref List<string> errors);

    }
}

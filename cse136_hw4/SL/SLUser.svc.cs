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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SLUser" in code, svc and config file together.
    public class SLUser : ISLUser
    {
        public void CreateUser(Users users, ref List<string> errors)
        {
            BLUser.CreateUser(users, ref errors);
        }
        
        public Users ReadUser(int id, ref List<string> errors)
        {
            return BLUser.ReadUser(id, ref errors);
        }

        public List<Users> ReadUsers(ref List<string> errors)
        {
            return BLUser.ReadUsers(ref errors);
        }

        public void UpdateUser(Users users, ref List<string> errors)
        {
            BLUser.UpdateUser(users, ref errors);
        }

        public void DeleteUser(int id, ref List<string> errors)
        {
            BLUser.DeleteUser(id, ref errors);
        }
    }
}

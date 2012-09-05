using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DomainModel;
using System.Text.RegularExpressions;

namespace BL
{
    public static class BLUser
    {
        public static int CreateUser(Users users, ref List<string> errors)
        {
            if (users == null)
            {
                errors.Add("Users cannot be null");
            }

            if (errors.Count > 0)
                return -1;

            if (users.users_id <= 0)
            {
                errors.Add("Invalid users_id");
            }
            if (users.customer_id <= 0)
            {
                errors.Add("Invalid customer_id");
            }
            if (!Regex.IsMatch(users.email, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                errors.Add("Invalid email");
            }
            if (users.user_level != 'u' && 
                        users.user_level != 'a')
            {
                errors.Add("Invalid user_level");
            }
            if (users.condition != 'a' && users.condition != 'd')
            {
                errors.Add("Invalid condition");
            }

            if (errors.Count > 0)
                return -1;

            return DALUser.CreateUser(users, ref errors);

        }
        public static Users ReadUser(int id, ref List<string> errors)
        {
            if (id <= 0)
            {
                errors.Add("Invalid id");
            }

            if (errors.Count > 0)
                return null;

            return DALUser.ReadUser(id, ref errors);
        }
        public static List<Users> ReadUsers(ref List<string> errors)
        {
            return DALUser.ReadUsers(ref errors);
        }
        public static int UpdateUser(Users users, ref List<string> errors)
        {
            if (users == null)
            {
                errors.Add("Users cannot be null");
            }

            if (errors.Count > 0)
                return -1;

            if (users.users_id <= 0)
            {
                errors.Add("Invalid users_id");
            }
            if (users.customer_id <= 0)
            {
                errors.Add("Invalid customer_id");
            }
            if (!Regex.IsMatch(users.email, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                errors.Add("Invalid email");
            }
            if (users.user_level != 'u' &&
                        users.user_level != 'a')
            {
                errors.Add("Invalid user_level");
            }
            if (users.condition != 'a' && users.condition != 'd')
            {
                errors.Add("Invalid condition");
            }

            if (errors.Count > 0)
                return -1;

            return DALUser.UpdateUser(users, ref errors);
        }
        public static int DeleteUser(int id, ref List<string> errors)
        {
            if (id <= 0)
            {
                errors.Add("Invalid id");
            }
            
            if (errors.Count > 0)
                return -1;

            return DALUser.DeleteUser(id, ref errors);
        }
    }
}

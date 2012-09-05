using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace DomainModel
{
    [DataContract]
    public class Users
    {
        [DataMember]
        public int users_id { get; set; }
        [DataMember]
        public int customer_id { get; set; }
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public char user_level { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public DateTime last_login { get; set; }
        [DataMember]
        public DateTime create_date { get; set; }
        [DataMember]
        public char condition { get; set; }


        public Users() { }

        public Users(int users_id, int customer_id, string username, string password, char user_level,
                        string email, DateTime last_login, DateTime create_date, char condition)
        {
            this.users_id = users_id;
            this.customer_id = customer_id;
            this.user_level = user_level;
            this.email = email;
            this.username = username;
            this.password = password;
            this.last_login = last_login;
            this.create_date = create_date;
            this.condition = condition;
        }
    }
}

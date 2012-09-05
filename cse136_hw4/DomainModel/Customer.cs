using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace DomainModel
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int customer_id { get; set; }
        [DataMember]
        public string first_name { get; set; }
        [DataMember]
        public string last_name { get; set; }
        [DataMember]
        public string address1 { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public int zip { get; set; }
        [DataMember]
        public int age { get; set; }
        [DataMember]
        public char gender { get; set; }
        [DataMember]
        public string hobby { get; set; }
        [DataMember]
        public int income { get; set; }
        [DataMember]
        public int children { get; set; }
        [DataMember]
        public string degree { get; set; }
        [DataMember]
        public int ownHouse { get; set; }

  
        public Customer(){}


        public Customer(int customer_id, string first_name, string last_name, string address1, string city, string state,
                        int zip, int age, char gender, string hobby, int income, int children, string degree, int ownHouse)
        {
            this.customer_id = customer_id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.address1 = address1;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.age = age;
            this.gender = gender;
            this.hobby = hobby;
            this.income = income;
            this.children = children;
            this.degree = degree;
            this.ownHouse = ownHouse;
        }

    }
}
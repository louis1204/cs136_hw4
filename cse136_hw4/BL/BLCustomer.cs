using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DomainModel;
using System.Text.RegularExpressions;

namespace BL
{
    public static class BLCustomer
    {
        public static int CreateCustomer(Customer customer, ref List<string> errors)
        {
            if (customer == null)
            {
                errors.Add("Customer cannot be null");
            }
            
            if (errors.Count > 0)
                return -1;
            
            if (customer.customer_id <= 0)
            {
                errors.Add("Invalid customer_id");
            }
            if (customer.age <= 0 || customer.age >= 200)
            {
                errors.Add("Invalid age");
            }
            if (!Regex.IsMatch(customer.zip.ToString(), @"^\d{5}(?:[-\s]\d{4})?$"))
            {
                errors.Add("Invalid zip code");
            }
            if (customer.gender != 'F' && customer.gender != 'M' && customer.gender != 'U')
            {
                errors.Add("Invalid gender");
            }
            if (customer.income < 0)
            {
                errors.Add("Invalid income");
            }
            if (customer.children < 0 || customer.children > 20)
            {
                errors.Add("Invalid number of children");
            }
            if (customer.degree != "None" &&
                        customer.degree != "High School" &&
                        customer.degree != "Partial High School" && 
                        customer.degree != "Bachelors" &&
                        customer.degree != "Partial College" &&
                        customer.degree != "Graduate Degree")
            {
                errors.Add("Invalid degree");
            }
            if (customer.ownHouse < 0)
            {
                errors.Add("Invalid number of owned houses");
            }

            if (errors.Count > 0)
                return -1;

            return DALCustomer.CreateCustomer(customer, ref errors);
        }

        public static Customer ReadCustomer(int id, ref List<string> errors)
        {
            if (id <= 0)
            {
                errors.Add("Invalid customer_id");
            }

            if (errors.Count > 0)
                return null;

            return DALCustomer.ReadCustomer(id, ref errors);
        }

        public static List<Customer> ReadCustomers(ref List<string> errors)
        {
            return DALCustomer.ReadCustomers(ref errors);
        }

        public static int UpdateCustomer(Customer customer, ref List<string> errors)
        {
            if (customer == null)
            {
                errors.Add("Customer cannot be null");
            }

            if (errors.Count > 0)
                return -1;

            if (customer.customer_id <= 0)
            {
                errors.Add("Invalid customer_id");
            }
            if (customer.age <= 0 || customer.age >= 200)
            {
                errors.Add("Invalid age");
            }
            if (!Regex.IsMatch(customer.zip.ToString(), @"^\d{5}(?:[-\s]\d{4})?$"))
            {
                errors.Add("Invalid zip code");
            }
            if (customer.gender != 'F' && customer.gender != 'M' && customer.gender != 'U')
            {
                errors.Add("Invalid gender");
            }
            if (customer.income < 0)
            {
                errors.Add("Invalid income");
            }
            if (customer.children <= 0 || customer.children >= 20)
            {
                errors.Add("Invalid number of children");
            }
            if (customer.degree != "None" &&
                        customer.degree != "High School" &&
                        customer.degree != "Partial High School" &&
                        customer.degree != "Bachelors" &&
                        customer.degree != "Partial College" &&
                        customer.degree != "Graduate Degree")
            {
                errors.Add("Invalid degree");
            }
            if (customer.ownHouse < 0)
            {
                errors.Add("Invalid number of owned houses");
            }

            if (errors.Count > 0)
                return -1;

            return DALCustomer.UpdateCustomer(customer, ref errors);
        }
    }
}

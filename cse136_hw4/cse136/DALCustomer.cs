using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel;  // must add this...
using System.Configuration; // must add this... make sure to add "System.Configuration" first
using System.Data.SqlClient; // must add this...
using System.Data; // must add this...

namespace DAL
{
    public static class DALCustomer
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];

        public static int CreateCustomer(Customer customer, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "create_customer";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter cc = new SqlParameter("@customer_id", SqlDbType.Int);
                cc.Direction = ParameterDirection.Output;

                mySA.SelectCommand.Parameters.Add(cc);
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.NVarChar, 255));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.NVarChar, 255));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@address1", SqlDbType.NVarChar, 255));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@city", SqlDbType.NVarChar, 255));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@state", SqlDbType.NVarChar, 255));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@zip", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@age", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@gender", SqlDbType.Char));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@hobby", SqlDbType.NVarChar, 255));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@income", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@children", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@degree", SqlDbType.NVarChar, 255));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@ownHouse", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@first_name"].Value = customer.first_name;
                mySA.SelectCommand.Parameters["@last_name"].Value = customer.last_name;
                mySA.SelectCommand.Parameters["@address1"].Value = customer.address1;
                mySA.SelectCommand.Parameters["@city"].Value = customer.city;
                mySA.SelectCommand.Parameters["@state"].Value = customer.state;
                mySA.SelectCommand.Parameters["@zip"].Value = customer.zip;
                mySA.SelectCommand.Parameters["@age"].Value = customer.age;
                mySA.SelectCommand.Parameters["@gender"].Value = customer.gender;
                mySA.SelectCommand.Parameters["@hobby"].Value = customer.hobby;
                mySA.SelectCommand.Parameters["@income"].Value = customer.income;
                mySA.SelectCommand.Parameters["@children"].Value = customer.children;
                mySA.SelectCommand.Parameters["@degree"].Value = customer.degree;
                mySA.SelectCommand.Parameters["@ownHouse"].Value = customer.ownHouse;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                Console.WriteLine(mySA.GetFillParameters()[0].Value);

                return (int)mySA.GetFillParameters()[0].Value;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("THIS IS THE ERROR: " + e.ToString());
                errors.Add("Error: " + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }
            return -1;
        }

        public static Customer ReadCustomer(int id, ref List<string> errors)
        {
            Customer customer = null;
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "read_customer";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@customer_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@customer_id"].Value = id;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                customer = new Customer();
                customer.customer_id = int.Parse(myDS.Tables[0].Rows[0]["customer_id"].ToString());
                customer.first_name = myDS.Tables[0].Rows[0]["first_name"].ToString();
                customer.last_name = myDS.Tables[0].Rows[0]["last_name"].ToString();
                customer.address1 = myDS.Tables[0].Rows[0]["address1"].ToString();
                customer.city = myDS.Tables[0].Rows[0]["city"].ToString();
                customer.state = myDS.Tables[0].Rows[0]["state"].ToString();
                customer.zip = int.Parse(myDS.Tables[0].Rows[0]["zip"].ToString());
                customer.age = int.Parse(myDS.Tables[0].Rows[0]["age"].ToString());
                customer.gender = myDS.Tables[0].Rows[0]["gender"].ToString()[0];
                customer.hobby = myDS.Tables[0].Rows[0]["hobby"].ToString();
                customer.income = int.Parse(myDS.Tables[0].Rows[0]["income"].ToString());
                customer.children = int.Parse(myDS.Tables[0].Rows[0]["children"].ToString());
                customer.degree = myDS.Tables[0].Rows[0]["degree"].ToString();
                customer.ownHouse = int.Parse(myDS.Tables[0].Rows[0]["ownHouse"].ToString());

                return customer;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("THIS IS THE ERROR: " + e.ToString());
                errors.Add("Error: " + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }
            return customer;
        }

        public static List<Customer> ReadCustomers(ref List<string> errors)
        {
            List<Customer> cl = null;
            Customer customer = null;
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "read_customers";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                cl = new List<Customer>();

                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {

                    customer = new Customer();
                    customer.customer_id = int.Parse(myDS.Tables[0].Rows[0]["customer_id"].ToString());
                    customer.first_name = myDS.Tables[0].Rows[0]["first_name"].ToString();
                    customer.last_name = myDS.Tables[0].Rows[0]["last_name"].ToString();
                    customer.address1 = myDS.Tables[0].Rows[0]["address1"].ToString();
                    customer.city = myDS.Tables[0].Rows[0]["city"].ToString();
                    customer.state = myDS.Tables[0].Rows[0]["state"].ToString();
                    customer.zip = int.Parse(myDS.Tables[0].Rows[0]["zip"].ToString());
                    customer.age = int.Parse(myDS.Tables[0].Rows[0]["age"].ToString());
                    customer.gender = myDS.Tables[0].Rows[0]["gender"].ToString()[0];
                    customer.hobby = myDS.Tables[0].Rows[0]["hobby"].ToString();
                    customer.income = int.Parse(myDS.Tables[0].Rows[0]["income"].ToString());
                    customer.children = int.Parse(myDS.Tables[0].Rows[0]["children"].ToString());
                    customer.degree = myDS.Tables[0].Rows[0]["degree"].ToString();
                    customer.ownHouse = int.Parse(myDS.Tables[0].Rows[0]["ownHouse"].ToString());

                    cl.Add(customer);

                }

                return cl;
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }
            return cl;
        }

        public static int UpdateCustomer(Customer customer, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "update_customer";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@customer_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.NVarChar, 255));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.NVarChar, 255));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@address1", SqlDbType.NVarChar, 255));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@city", SqlDbType.NVarChar, 255));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@state", SqlDbType.NVarChar, 255));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@zip", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@age", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@gender", SqlDbType.Char));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@hobby", SqlDbType.NVarChar, 255));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@income", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@children", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@degree", SqlDbType.NVarChar, 255));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@ownHouse", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@customer_id"].Value = customer.customer_id;
                mySA.SelectCommand.Parameters["@first_name"].Value = customer.first_name;
                mySA.SelectCommand.Parameters["@last_name"].Value = customer.last_name;
                mySA.SelectCommand.Parameters["@address1"].Value = customer.address1;
                mySA.SelectCommand.Parameters["@city"].Value = customer.city;
                mySA.SelectCommand.Parameters["@state"].Value = customer.state;
                mySA.SelectCommand.Parameters["@zip"].Value = customer.zip;
                mySA.SelectCommand.Parameters["@age"].Value = customer.age;
                mySA.SelectCommand.Parameters["@gender"].Value = customer.gender;
                mySA.SelectCommand.Parameters["@hobby"].Value = customer.hobby;
                mySA.SelectCommand.Parameters["@income"].Value = customer.income;
                mySA.SelectCommand.Parameters["@children"].Value = customer.children;
                mySA.SelectCommand.Parameters["@degree"].Value = customer.degree;
                mySA.SelectCommand.Parameters["@ownHouse"].Value = customer.ownHouse;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                Console.WriteLine(mySA.GetFillParameters()[0].Value);

                return 0;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("THIS IS THE ERROR: " + e.ToString());
                errors.Add("Error: " + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }
            return -1;
        }
    }
}

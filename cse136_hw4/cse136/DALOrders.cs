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
    public static class DALOrders
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];
        public static int CreateOrder(Orders order, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "create_orders";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter a = new SqlParameter("@order_id", SqlDbType.Int);
                a.Direction = ParameterDirection.Output;

                mySA.SelectCommand.Parameters.Add(a);

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@customer_id", SqlDbType.Char));
                mySA.SelectCommand.Parameters["@customer_id"].Value = order.customer_id;

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@condition", SqlDbType.Char));
                mySA.SelectCommand.Parameters["@condition"].Value = order.condition;

                DataSet myDS = new DataSet();

                mySA.Fill(myDS);

          
                return (int)mySA.GetFillParameters()[0].Value;
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }
            return -1;
        }
        public static int UpdateOrder(Orders order, ref List<string> errors){
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {

                string strSQL = "update_orders";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@order_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@order_id"].Value = order.order_id;

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@condition", SqlDbType.Char));

                mySA.SelectCommand.Parameters["@condition"].Value = order.condition;

                DataSet myDS = new DataSet();

                mySA.Fill(myDS);


                if (myDS.Tables[0].Rows.Count == 0)
                {
                    return 0;
                }

                return 1;
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

            return 0;
        }
        public static int DeleteOrder(int o, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {

                string strSQL = "delete_orders";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@order_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@order_id"].Value = o;

                DataSet myDS = new DataSet();

                mySA.Fill(myDS);


                if (myDS.Tables[0].Rows.Count == 0)
                {
                    return 0;
                }

                if (myDS.Tables[0].Rows[0]["condition"].ToString() == "d")
                {
                    return 1;
                }

                return 1;
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

            return 0;
        }
        public static Orders ReadOrder(int o, ref List<string> errors)
        {
            Orders order = null;

            SqlConnection conn = new SqlConnection(connection_string);

            try
            {

                string strSQL = "read_orders";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@order_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@order_id"].Value = o;

                DataSet myDS = new DataSet();

                mySA.Fill(myDS,"orders");
 
                if (myDS.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                order = new Orders();
                order.order_id = int.Parse(myDS.Tables[0].Rows[0]["order_id"].ToString());
                order.customer_id =int.Parse(myDS.Tables[0].Rows[0]["customer_id"].ToString());
                order.subtotal = float.Parse(myDS.Tables[0].Rows[0]["subtotal"].ToString());
                order.tax_total = float.Parse(myDS.Tables[0].Rows[0]["tax_total"].ToString());
                order.grand_total = float.Parse(myDS.Tables[0].Rows[0]["grand_total"].ToString());
                order.date_created = DateTime.Parse(myDS.Tables[0].Rows[0]["date_created"].ToString());
                order.condition = char.Parse(myDS.Tables[0].Rows[0]["condition"].ToString());


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


            return order;
        }    
    }
}

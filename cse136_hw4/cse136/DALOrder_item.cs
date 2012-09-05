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
    public static class DALOrder_item
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];
        public static int CreateOrderItem(Orders order, Order_item oi, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {
                string strSQL = "create_order_item";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@order_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters["@order_id"].Value = order.order_id;

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_variation_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters["@product_variation_id"].Value = oi.product_variation_id;

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@tax", SqlDbType.Float));
                mySA.SelectCommand.Parameters["@tax"].Value = oi.tax;

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@quantity", SqlDbType.Int));
                mySA.SelectCommand.Parameters["@quantity"].Value = oi.quantity;

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@condition", SqlDbType.Char));
                mySA.SelectCommand.Parameters["@condition"].Value = oi.condition;

                DataSet myDS = new DataSet();

                mySA.Fill(myDS);

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
            return -1;
        }
        public static int UpdateOrderItem(Order_item oi, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {

                string strSQL = "update_order_item";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@order_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@order_id"].Value = oi.order_id;

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_variation_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@product_variation_id"].Value = oi.product_variation_id;

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@quantity", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@quantity"].Value = oi.quantity;

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
        public static int DeleteOrderItem(int o, int pv, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {

                string strSQL = "delete_order_item";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@order_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@order_id"].Value = o;

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_variation_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@product_variation_id"].Value = pv;

                DataSet myDS = new DataSet();

                mySA.Fill(myDS);


                if (myDS.Tables[1].Rows.Count == 0)
                {
                    return 0;
                }

                if (myDS.Tables[1].Rows[0]["condition"].ToString() == "d")
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
        public static Order_item ReadOrderItem(int o, int pv, ref List<string> errors)
        {
            Order_item order = null;

            SqlConnection conn = new SqlConnection(connection_string);
            try
            {

                string strSQL = "read_order_item";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@order_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@order_id"].Value = o;

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_variation_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@product_variation_id"].Value = pv;

                DataSet myDS = new DataSet();

                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                order = new Order_item();
                order.order_id = int.Parse(myDS.Tables[0].Rows[0]["order_id"].ToString());
                order.product_variation_id = int.Parse(myDS.Tables[0].Rows[0]["product_variation_id"].ToString());
                order.tax = float.Parse(myDS.Tables[0].Rows[0]["tax"].ToString());
                order.quantity = int.Parse(myDS.Tables[0].Rows[0]["quantity"].ToString());
                order.sale_price = float.Parse(myDS.Tables[0].Rows[0]["sale_price"].ToString());
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
        public static List<Order_item> ReadOrderItems(int o, ref List<string> errors)
        {
            List<Order_item> oil = null;
            Order_item order = null;

            SqlConnection conn = new SqlConnection(connection_string);

            try
            {

                string strSQL = "read_order_items";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@order_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@order_id"].Value = o;

                DataSet myDS = new DataSet();

                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                oil = new List<Order_item>();

                for(int i=0; i < myDS.Tables[0].Rows.Count; i++){
        
                    order = new Order_item();
                    order.order_id = int.Parse(myDS.Tables[0].Rows[i]["order_id"].ToString());
                    order.product_variation_id = int.Parse(myDS.Tables[0].Rows[i]["product_variation_id"].ToString());
                    order.tax = float.Parse(myDS.Tables[0].Rows[i]["tax"].ToString());
                    order.quantity = int.Parse(myDS.Tables[0].Rows[i]["quantity"].ToString());
                    order.sale_price = int.Parse(myDS.Tables[0].Rows[i]["sale_price"].ToString());
                    order.condition = char.Parse(myDS.Tables[0].Rows[i]["condition"].ToString());

                    oil.Add(order);

                }

                return oil;

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


            return oil;
        }    
    }
}

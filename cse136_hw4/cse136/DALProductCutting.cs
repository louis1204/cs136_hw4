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
    public static class DALProductCutting
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];

        public static int CreateProductCutting(String product_cutting_name, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "create_product_cutting";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_cutting_name", SqlDbType.VarChar, 50));

                SqlParameter ProductCuttingIdParmOut = new SqlParameter("@product_cutting_id_output", SqlDbType.Int);
                ProductCuttingIdParmOut.Direction = ParameterDirection.Output;
                mySA.SelectCommand.Parameters.Add(ProductCuttingIdParmOut);

                mySA.SelectCommand.Parameters["@product_cutting_name"].Value = product_cutting_name;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                return (int)ProductCuttingIdParmOut.Value; // ADDED

                //return 1;
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

        public static ProductCuttingInfo ReadProductCuttingDetail(int product_cutting_id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            ProductCuttingInfo ProductCutting = null;

            try
            {
                string strSQL = "read_product_cutting";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_cutting_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@product_cutting_id"].Value = product_cutting_id;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                ProductCutting = new ProductCuttingInfo(int.Parse(myDS.Tables[0].Rows[0]["product_cutting_id"].ToString()),
                    myDS.Tables[0].Rows[0]["product_cutting_name"].ToString());
                return ProductCutting;
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
            return null;
        }

        public static List<ProductCuttingInfo> ReadProductCuttingList(ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            ProductCuttingInfo Product = null;
            List<ProductCuttingInfo> ProductCuttingList = new List<ProductCuttingInfo>();

            try
            {
                string strSQL = "read_all_product_cutting";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {
                    Product = new ProductCuttingInfo(int.Parse(myDS.Tables[0].Rows[i]["product_cutting_id"].ToString()),
                        myDS.Tables[0].Rows[i]["product_cutting_name"].ToString());
                    ProductCuttingList.Add(Product);
                }
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

            return ProductCuttingList;
        }

        public static int UpdateProductCutting(int ProductCutting_id, string ProductCutting_name, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "update_product_cutting";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_cutting_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_cutting_name", SqlDbType.VarChar, 50));

                mySA.SelectCommand.Parameters["@product_cutting_id"].Value = ProductCutting_id;
                mySA.SelectCommand.Parameters["@product_cutting_name"].Value = ProductCutting_name;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);
                return 1;
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
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
    public static class DALProduct
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];

        public static int CreateProduct(String product_name, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "create_product";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_name", SqlDbType.VarChar, 255));

                SqlParameter productIdParmOut = new SqlParameter("@product_id_output", SqlDbType.Int);
                productIdParmOut.Direction = ParameterDirection.Output;
                mySA.SelectCommand.Parameters.Add(productIdParmOut);

                mySA.SelectCommand.Parameters["@product_name"].Value = product_name;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);
                return (int)productIdParmOut.Value;
            }

            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("THIS IS THE ERROR: " + e.ToString());
                errors.Add("Error: " + e.ToString());
                return -1;
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }
        }

        public static ProductInfo ReadProductDetail(int product_id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            ProductInfo Product = null;

            try
            {
                string strSQL = "read_product";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@product_id"].Value = product_id;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                Product = new ProductInfo(int.Parse(myDS.Tables[0].Rows[0]["product_id"].ToString()),
                    myDS.Tables[0].Rows[0]["product_name"].ToString());
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

            return Product;
        }

        public static List<ProductInfo> ReadProductList(ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            ProductInfo Product = null;
            List<ProductInfo> ProductList = new List<ProductInfo>();

            try
            {
                string strSQL = "read_all_product";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {
                    Product = new ProductInfo(int.Parse(myDS.Tables[0].Rows[i]["product_id"].ToString()),
                        myDS.Tables[0].Rows[i]["product_name"].ToString());
                    ProductList.Add(Product);
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

            return ProductList;
        }

        public static int UpdateProduct(int product_id, string product_name, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "update_product";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_name", SqlDbType.VarChar, 255));

                mySA.SelectCommand.Parameters["@product_id"].Value = product_id;
                mySA.SelectCommand.Parameters["@product_name"].Value = product_name;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);
                return 1;
            }

            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("THIS IS THE ERROR: " + e.ToString());
                errors.Add("Error: " + e.ToString());
                return -1;
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }
        }
    }
}

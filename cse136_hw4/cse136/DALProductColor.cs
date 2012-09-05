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
    public static class DALProductColor
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];

        public static int CreateProductColor(String product_color_name, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "create_product_color";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_color_name", SqlDbType.VarChar, 50));

                SqlParameter ProductColorIdParmOut = new SqlParameter("@product_color_id_output", SqlDbType.Int);
                ProductColorIdParmOut.Direction = ParameterDirection.Output;
                mySA.SelectCommand.Parameters.Add(ProductColorIdParmOut);

                mySA.SelectCommand.Parameters["@product_color_name"].Value = product_color_name;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);
                return (int)ProductColorIdParmOut.Value;
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

        public static ProductColorInfo ReadProductColorDetail(int product_color_id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            ProductColorInfo ProductColor = null;

            try
            {
                string strSQL = "read_product_color";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_color_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@product_color_id"].Value = product_color_id;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                ProductColor = new ProductColorInfo(int.Parse(myDS.Tables[0].Rows[0]["product_color_id"].ToString()),
                    myDS.Tables[0].Rows[0]["product_color_name"].ToString());
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

            return ProductColor;
        }

        public static List<ProductColorInfo> ReadProductColorList(ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            ProductColorInfo ProductColor = null;
            List<ProductColorInfo> ProductColorList = new List<ProductColorInfo>();

            try
            {
                string strSQL = "read_all_product_color";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {
                    ProductColor = new ProductColorInfo(int.Parse(myDS.Tables[0].Rows[i]["product_color_id"].ToString()),
                        myDS.Tables[0].Rows[i]["product_color_name"].ToString());
                    ProductColorList.Add(ProductColor);
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

            return ProductColorList;
        }

        public static int UpdateProductColor(int ProductColor_id, string ProductColor_name, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "update_product_color";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_color_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_color_name", SqlDbType.VarChar, 50));

                mySA.SelectCommand.Parameters["@product_color_id"].Value = ProductColor_id;
                mySA.SelectCommand.Parameters["@product_color_name"].Value = ProductColor_name;

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

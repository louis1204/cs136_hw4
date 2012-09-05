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
    public static class DALType
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];

        public static int CreateProductType(String product_type_name, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "create_product_type";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_type_name", SqlDbType.VarChar, 30));

                SqlParameter ProductTypeIdParmOut = new SqlParameter("@product_type_id_output", SqlDbType.Int);
                ProductTypeIdParmOut.Direction = ParameterDirection.Output;
                mySA.SelectCommand.Parameters.Add(ProductTypeIdParmOut);

                mySA.SelectCommand.Parameters["@product_type_name"].Value = product_type_name;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);
                return (int)ProductTypeIdParmOut.Value;
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

        public static ProductTypeInfo ReadProductTypeDetail(int product_type_id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            ProductTypeInfo ProductType = null;

            try
            {
                string strSQL = "read_product_type";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_type_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@product_type_id"].Value = product_type_id;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                ProductType = new ProductTypeInfo(int.Parse(myDS.Tables[0].Rows[0]["product_type_id"].ToString()),
                    myDS.Tables[0].Rows[0]["product_type_name"].ToString());
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

            return ProductType;
        }

        public static List<ProductTypeInfo> ReadProductTypeList(ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            ProductTypeInfo ProductType = null;
            List<ProductTypeInfo> ProductTypeList = new List<ProductTypeInfo>();

            try
            {
                string strSQL = "read_all_product_type";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {
                    ProductType = new ProductTypeInfo(int.Parse(myDS.Tables[0].Rows[i]["product_type_id"].ToString()),
                        myDS.Tables[0].Rows[i]["product_type_name"].ToString());
                    ProductTypeList.Add(ProductType);
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

            return ProductTypeList;
        }

        public static int UpdateProductType(int ProductType_id, string ProductType_name, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "update_product_type";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_type_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@product_type_name", SqlDbType.VarChar, 30));

                mySA.SelectCommand.Parameters["@product_type_id"].Value = ProductType_id;
                mySA.SelectCommand.Parameters["@product_type_name"].Value = ProductType_name;

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
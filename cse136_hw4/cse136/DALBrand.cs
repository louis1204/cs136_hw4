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
    public static class DALBrand
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];

        public static int CreateBrand(String brand_name, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "create_brand";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@brand_name", SqlDbType.VarChar, 60));

                SqlParameter BrandIdParmOut = new SqlParameter("@brand_id_output", SqlDbType.Int);
                BrandIdParmOut.Direction = ParameterDirection.Output;
                mySA.SelectCommand.Parameters.Add(BrandIdParmOut);

                mySA.SelectCommand.Parameters["@brand_name"].Value = brand_name;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);
                return (int)BrandIdParmOut.Value;
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

        public static BrandInfo ReadBrandDetail(int brand_id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            BrandInfo brand = null;

            try
            {
                string strSQL = "read_brand";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@brand_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@brand_id"].Value = brand_id;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                brand = new BrandInfo(int.Parse(myDS.Tables[0].Rows[0]["brand_id"].ToString()),
                    myDS.Tables[0].Rows[0]["brand_name"].ToString());
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

            return brand;
        }

        public static List<BrandInfo> ReadBrandList(ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            BrandInfo Brand = null;
            List<BrandInfo> BrandList = new List<BrandInfo>();

            try
            {
                string strSQL = "read_all_brand";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {
                    Brand = new BrandInfo(int.Parse(myDS.Tables[0].Rows[i]["brand_id"].ToString()),
                        myDS.Tables[0].Rows[i]["brand_name"].ToString());
                    BrandList.Add(Brand);
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

            return BrandList;
        }

        public static int UpdateBrand(int brand_id, string brand_name, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "update_brand";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@brand_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@brand_name", SqlDbType.VarChar, 255));

                mySA.SelectCommand.Parameters["@brand_id"].Value = brand_id;
                mySA.SelectCommand.Parameters["@brand_name"].Value = brand_name;

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

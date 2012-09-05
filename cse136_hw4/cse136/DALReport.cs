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
    public static class DALReport
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];

        public static int CreateError( string error, DateTime dt, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "create_error";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@error", SqlDbType.Text));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@dt", SqlDbType.DateTime));

                SqlParameter IdParmOut = new SqlParameter("@id", SqlDbType.Int);
                IdParmOut.Direction = ParameterDirection.Output;
                mySA.SelectCommand.Parameters.Add(IdParmOut);

                mySA.SelectCommand.Parameters["@error"].Value = error;
                mySA.SelectCommand.Parameters["@dt"].Value = dt;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);
                return (int)IdParmOut.Value;
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

    }
}

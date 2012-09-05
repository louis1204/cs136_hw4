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
    public static class DALUser
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];

        public static int CreateUser(Users users, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "create_user";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter cc = new SqlParameter("@users_id", SqlDbType.Int);
                cc.Direction = ParameterDirection.Output;

                mySA.SelectCommand.Parameters.Add(cc);
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@customer_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 200));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, int.MaxValue));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@user_level", SqlDbType.Char));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 250));

                mySA.SelectCommand.Parameters["@users_id"].Value = users.users_id;
                mySA.SelectCommand.Parameters["@customer_id"].Value = users.customer_id;
                mySA.SelectCommand.Parameters["@username"].Value = users.username;
                mySA.SelectCommand.Parameters["@password"].Value = users.password;
                mySA.SelectCommand.Parameters["@user_level"].Value = users.user_level;
                mySA.SelectCommand.Parameters["@email"].Value = users.email;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                Console.WriteLine(mySA.GetFillParameters()[0].Value);

                return (int)mySA.GetFillParameters()[0].Value;
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

        public static Users ReadUser(int id, ref List<string> errors)
        {
            Users users = null;
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "read_user";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@users_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@users_id"].Value = id;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                users = new Users();
                users.users_id = int.Parse(myDS.Tables[0].Rows[0]["users_id"].ToString());
                users.customer_id = int.Parse(myDS.Tables[0].Rows[0]["customer_id"].ToString());
                users.username = myDS.Tables[0].Rows[0]["username"].ToString();
                users.password = myDS.Tables[0].Rows[0]["password"].ToString();
                users.user_level = myDS.Tables[0].Rows[0]["user_level"].ToString()[0];
                users.email = myDS.Tables[0].Rows[0]["email"].ToString();
                users.last_login = DateTime.Parse(myDS.Tables[0].Rows[0]["last_login"].ToString());
                users.create_date = DateTime.Parse(myDS.Tables[0].Rows[0]["create_date"].ToString());
                users.condition = myDS.Tables[0].Rows[0]["condition"].ToString()[0];

                return users;
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
            return users;
        }

        public static List<Users> ReadUsers(ref List<string> errors)
        {
            List<Users> ul = null;
            Users users = null;
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "read_users";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                ul = new List<Users>();

                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {

                    users = new Users();
                    users.users_id = int.Parse(myDS.Tables[0].Rows[0]["users_id"].ToString());
                    users.customer_id = int.Parse(myDS.Tables[0].Rows[0]["customer_id"].ToString());
                    users.username = myDS.Tables[0].Rows[0]["username"].ToString();
                    users.password = myDS.Tables[0].Rows[0]["password"].ToString();
                    users.user_level = myDS.Tables[0].Rows[0]["user_level"].ToString()[0];
                    users.email = myDS.Tables[0].Rows[0]["email"].ToString();
                    users.last_login = DateTime.Parse(myDS.Tables[0].Rows[0]["last_login"].ToString());
                    users.create_date = DateTime.Parse(myDS.Tables[0].Rows[0]["create_date"].ToString());
                    users.condition = myDS.Tables[0].Rows[0]["condition"].ToString()[0];

                    ul.Add(users);
                }

                return ul;
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
            return ul;
        }

        public static int UpdateUser(Users users, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "update_user";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@users_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@customer_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, int.MaxValue));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@user_level", SqlDbType.Char));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 250));

                mySA.SelectCommand.Parameters["@users_id"].Value = users.users_id;
                mySA.SelectCommand.Parameters["@customer_id"].Value = users.customer_id;
                mySA.SelectCommand.Parameters["@password"].Value = users.password;
                mySA.SelectCommand.Parameters["@user_level"].Value = users.user_level;
                mySA.SelectCommand.Parameters["@email"].Value = users.email;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                return 0;

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

        public static int DeleteUser(int id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {
                string strSQL = "delete_user";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@users_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@users_id"].Value = id;
                //mySA.SelectCommand.Parameters["@condition"].Value = 'd';

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                return 0;

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

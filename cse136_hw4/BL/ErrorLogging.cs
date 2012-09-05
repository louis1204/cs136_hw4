using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration; // must add this... make sure to add "System.Configuration" first
using System.Diagnostics;
using DAL;

///
/// Note, in real world practice, each class definition should be in its own
/// file because the logic is much more complicated.  For 136, it's all in one
/// file for simplicity.
///
namespace BL
{
	// this is the interface definition
	public interface IErrorLogging
	{
		void LogError(List<string> errorList);
	}

	public class LogToFile : IErrorLogging
	{

		public void LogError(List<string> errorList)
		{
            // 136 Students TODO: Write to local file system somewhere
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Louis\Desktop\error_136.txt", true))
            {
                file.WriteLine("=========================================");
                file.WriteLine("Datetime : " + DateTime.Now.ToString());
                for (int i = 0; i < errorList.Count; i++)
                {
                    file.WriteLine(errorList[i].ToString());
                }
                file.WriteLine();
            }
			
		}
	}

	public class LogToDB : IErrorLogging
	{
		public void LogError(List<string> errorList)
		{
            List<string> e = new List<string>();
			// 136 Students TODO: write to database table.
            for (int i = 0; i < errorList.Count; i++)
                DALReport.CreateError(errorList[i], DateTime.Now ,ref e);
		}
	}

	public class ErrorLogFactory
	{

		static string logDestination = ConfigurationManager.AppSettings["logDestination"];

		public IErrorLogging logInstance = null;

		public IErrorLogging GetErrorLogInstance()
		{
			switch (logDestination)
			{
				case "file":
					logInstance = new LogToFile();
					break;
				case "db":
					logInstance = new LogToDB();
					break;
				default:
					break;
			}
			return logInstance;
		}
	}

	public class AsynchLog
	{
		delegate void MethodDelegate(List<string> strError);

		public static void LogNow(List<string> strError)
		{
			IErrorLogging log = new ErrorLogFactory().GetErrorLogInstance();

			MethodDelegate callGenerateFileAsync = new MethodDelegate(log.LogError);
			IAsyncResult ar = callGenerateFileAsync.BeginInvoke(strError, null, null);
		}
	}

}

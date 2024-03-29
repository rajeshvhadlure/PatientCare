﻿using DBManagement.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBManagement.Models
{
	public class ExceptionLogModel
	{
		public string Exception { get; set; }
		public string ControllerName { get; set; }
		public string FunctionName { get; set; }
		public string StackTrace { get; set; }
		public long UserID { get; set; }

		public static string SaveExceptionLogDetails_SP = "SP_InsertErrorLog";

		public void LogException()
		{
			Dictionary<object, object> parameters = new Dictionary<object, object>();
			parameters.Add("@Exception", Exception);
			parameters.Add("@ControllerName", ControllerName);
			parameters.Add("@FunctionName", FunctionName);
			parameters.Add("@StackTrace", StackTrace);
			parameters.Add("@UserID", UserID);

			DBManager.CreateUpdateData(SaveExceptionLogDetails_SP, parameters);
		}
	}
}
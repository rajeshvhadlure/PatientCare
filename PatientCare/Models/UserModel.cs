using DBManagement.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DBManagement.Models
{
	public class UserModel
	{
		public Int64 Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Mobile { get; set; }
		public string Pincode { get; set; }
		public string Parliamentary { get; set; }
		public string Legislative { get; set; }
		public string State { get; set; }
		public string City { get; set; }

		public int CurrentPage { get; set; }
		public int NumberOfRecords { get; set; }
		public string OrderBy { get; set; }
		public int TotalCount { get; set; }

		private static string GetUserDataForList_SP = "SP_GetUserData_Forlist";

		internal List<UserModel> GetUserData_ForList()
		{
			Dictionary<object, object> parameters = new Dictionary<object, object>();
			parameters.Add("@CurrentPage", CurrentPage);
			parameters.Add("@NumberOfRecords", NumberOfRecords);
			parameters.Add("@OrderBy", OrderBy);
			parameters.Add("@Mobile", Mobile);
			parameters.Add("@Pincode", Pincode);
			parameters.Add("@State", State);
			parameters.Add("@City", City);
			parameters.Add("@Parliamentary", Parliamentary);
			parameters.Add("@Legislative", Legislative);
			return TransformUserDataForList(DBManager.GetData(GetUserDataForList_SP, parameters));
		}

		private List<UserModel> TransformUserDataForList(DataTable data)
		{
			List<UserModel> userList = new List<UserModel>();
			if (data.Rows.Count > 0)
			{
				userList = (from DataRow row in data.Rows
							  select new UserModel()
							  {
								  Name = row.Field<string>("Name"),
								  Address = row.Field<string>("Address"),
								  Mobile = row.Field<string>("Mobile"),
								  Pincode = row.Field<string>("Pincode"),
								  State = row.Field<string>("State"),
								  City = row.Field<string>("City"),
								  Parliamentary = row.Field<string>("Parliamentary"),
								  Legislative = row.Field<string>("Legislative"),
								  TotalCount = row.Field<int>("TotalCount"),
							  }).ToList();
			}
			return userList;
		}
	}
}
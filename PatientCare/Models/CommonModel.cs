using PatientCare.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PatientCare.Models
{
	public class CommonModel
	{
		public long CityID { get; set; }
		public string CityName { get; set; }

		public long StateID { get; set; }
		public string StateName { get; set; }

		public static string GetCityData_SP = "SP_GetCityData";
		public static string GetStateData_SP = "SP_GetStateData";

		public List<CommonModel> GetCityData()
		{
			return TransfromCitiesData(DBManager.GetData(GetCityData_SP));
		}

		private List<CommonModel> TransfromCitiesData(DataTable dataTable)
		{
			List<CommonModel> cityList = new List<CommonModel>();

			foreach (var item in dataTable.AsEnumerable())
			{
				CommonModel model = new CommonModel();
				model.CityID = Convert.ToInt64(item["ID"]);
				model.CityName = Convert.ToString(item["Name"]);
				cityList.Add(model);
			}

			return cityList;
		}

		public List<CommonModel> GetStateData()
		{
			return TransfromStateData(DBManager.GetData(GetStateData_SP));
		}

		private List<CommonModel> TransfromStateData(DataTable dataTable)
		{
			List<CommonModel> stateList = new List<CommonModel>();

			foreach (var item in dataTable.AsEnumerable())
			{
				CommonModel model = new CommonModel();
				model.StateID = Convert.ToInt64(item["ID"]);
				model.StateName = Convert.ToString(item["Name"]);
				stateList.Add(model);
			}

			return stateList;
		}
	}
}
using DBManagement.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DBManagement.Models
{
	public class CommonModel
	{
		public long CityID { get; set; }
		public string CityName { get; set; }

		public long StateID { get; set; }
		public string StateName { get; set; }

		public long ParliamentID { get; set; }
		public string ParliamentName { get; set; }

		public long LegislativeID { get; set; }
		public string LegislativeName { get; set; }

		public static string GetCityData_SP = "SP_GetCityData";
		public static string GetStateData_SP = "SP_GetStateData";
		public static string GetParliamentData_SP = "SP_GetParliamentData";
		public static string GetLegislativeData_SP = "SP_GetLegislativeData";

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

		public List<CommonModel> GetParliamentData()
		{
			return TransfromParliamentsData(DBManager.GetData(GetParliamentData_SP));
		}

		private List<CommonModel> TransfromParliamentsData(DataTable dataTable)
		{
			List<CommonModel> parliamentList = new List<CommonModel>();

			foreach (var item in dataTable.AsEnumerable())
			{
				CommonModel model = new CommonModel();
				model.ParliamentID = Convert.ToInt64(item["ID"]);
				model.ParliamentName = Convert.ToString(item["Name"]);
				parliamentList.Add(model);
			}

			return parliamentList;
		}

		public List<CommonModel> GetLegislativeData()
		{
			return TransfromLegislativesData(DBManager.GetData(GetLegislativeData_SP));
		}

		private List<CommonModel> TransfromLegislativesData(DataTable dataTable)
		{
			List<CommonModel> legislativeList = new List<CommonModel>();

			foreach (var item in dataTable.AsEnumerable())
			{
				CommonModel model = new CommonModel();
				model.LegislativeID = Convert.ToInt64(item["ID"]);
				model.LegislativeName = Convert.ToString(item["Name"]);
				legislativeList.Add(model);
			}

			return legislativeList;
		}
	}
}
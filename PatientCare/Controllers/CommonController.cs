using DBManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace DBManagement.Controllers
{
	public class CommonController : Controller
	{
		public ActionResult CityDDL()
		{
			return PartialView("CityDDL");
		}
		public JsonResult GetCities()
		{
			try
			{
				CommonModel model = new CommonModel();
				List<CommonModel> cityList = model.GetCityData();
				var jsonData = new
				{
					rows = (from data in cityList
							select new
							{
								id = data.CityID,
								city = data.CityName.ToString()
							}).ToList()
				};
				return Json(jsonData, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				UtilityController.LogException(ex, MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
			}
			return null;
		}

		public ActionResult StateDDL()
		{
			return PartialView("StateDDL");
		}
		public JsonResult GetStates()
		{
			try
			{
				CommonModel model = new CommonModel();
				List<CommonModel> stateList = model.GetStateData();
				var jsonData = new
				{
					rows = (from data in stateList
							select new
							{
								id = data.StateID,
								state = data.StateName.ToString()
							}).ToList()
				};
				return Json(jsonData, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				UtilityController.LogException(ex, MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
			}
			return null;
		}

		public ActionResult ParliamentDDL()
		{
			return PartialView("ParliamentDDL");
		}
		public JsonResult GetParliament()
		{
			try
			{
				CommonModel model = new CommonModel();
				List<CommonModel> parliamentList = model.GetParliamentData();
				var jsonData = new
				{
					rows = (from data in parliamentList
							select new
							{
								id = data.ParliamentID,
								parliament = data.ParliamentName.ToString()
							}).ToList()
				};
				return Json(jsonData, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				UtilityController.LogException(ex, MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
			}
			return null;
		}

		public ActionResult LegislativeDDL()
		{
			return PartialView("LegislativeDDL");
		}
		public JsonResult GetLegislatives()
		{
			try
			{
				CommonModel model = new CommonModel();
				List<CommonModel> legislativeList = model.GetLegislativeData();
				var jsonData = new
				{
					rows = (from data in legislativeList
							select new
							{
								id = data.LegislativeID,
								legislative = data.LegislativeName.ToString()
							}).ToList()
				};
				return Json(jsonData, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				UtilityController.LogException(ex, MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
			}
			return null;
		}
	}
}
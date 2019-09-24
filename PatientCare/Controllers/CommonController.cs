using PatientCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientCare.Controllers
{
	public class CommonController : Controller
	{
		// GET: Common
		public ActionResult CityDDL()
		{
			return PartialView("CityDDL");
		}

		public ActionResult StateDDL()
		{
			return PartialView("StateDDL");
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
				return null;
			}
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
								city = data.StateName.ToString()
							}).ToList()
				};
				return Json(jsonData, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
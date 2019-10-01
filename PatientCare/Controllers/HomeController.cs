using DBManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace DBManagement.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public JsonResult GetAllUserDetails_ForList(int? page, int? limit, string sortBy, string direction, string searchString = null, string state = null, string city = null, string parliament = null, string legislative = null, string pincode = null, string mobile = null)
		{
			try
			{
				UserModel model = new UserModel();
				model.CurrentPage = page.Value;
				model.NumberOfRecords = limit.Value;
				model.OrderBy = string.Format("{0} {1}", sortBy, direction);
				model.Mobile = mobile;
				model.Parliamentary = parliament;
				model.Legislative = legislative;
				model.City = city;
				model.State = state;
				model.Pincode = pincode;
				var records = model.GetUserData_ForList();
				int total = records.Count > 0 ? records.FirstOrDefault().TotalCount : 0;

				return Json(new { records, total }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				UtilityController.LogException(ex, MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
			}

			return Json(null, JsonRequestBehavior.AllowGet);
		}
	}
}
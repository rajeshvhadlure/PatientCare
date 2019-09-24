using PatientCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientCare.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public JsonResult GetAllUserDetails_ForList(int? page, int? limit, string sortBy, string direction, string searchString = null)
		{
			try
			{
				UserModel model = new UserModel();
				model.CurrentPage = page.Value;
				model.NumberOfRecords = limit.Value;
				model.OrderBy = string.Format("{0} {1}", sortBy, direction);
				var records = model.GetUserData_ForList();//new GridModel().GetPlayers(page, limit, sortBy, direction, searchString, out total);
				int total = records.Count > 0 ? records.FirstOrDefault().TotalCount : 0;

				return Json(new { records, total }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				
			}

			return Json(null, JsonRequestBehavior.AllowGet);
		}

		
	}
}
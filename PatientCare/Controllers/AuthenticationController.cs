using DBManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace DBManagement.Controllers
{
    public class AuthenticationController : Controller
    {
		public ActionResult Login()
		{
			return View();
		}

		public string AuthorizeUser(LoginModel model)
		{
			model.Password = UtilityController.Encrypt(model.Password, "dbmanagment");
			model = model.Authorise();
			if (model.UserName != null)
			{
				Session["User"] = model;
				return "1";
			}
			return "0";
		}

		public void signout()
		{
			Session["User"] = null;
		}

		public ActionResult ForgotPassword()
		{
			return View();
		}

		public string GetForgotPasswordDetails(LoginModel model)
		{
			model = model.GetForgotPasswordDetails();

			if (model != null && model.ID > 0)
			{
				UtilityController uController = new UtilityController();

				uController.SendEmail(model.UserName, UtilityController.Decrypt(model.Password, "dbmanagment"), model.EmailID, "Forget Password");
			}
			return null;
		}

		public string ChangeUserPassword(string CurrentPassword, string NewPassword, string ConfirmPassword)
		{
			if (IsValid(NewPassword))
			{
				LoginModel model = (LoginModel)Session["User"];
				LoginModel user = new LoginModel();
				user.Password = UtilityController.Encrypt(CurrentPassword, "dbmanagment");
				user.NewPassword = UtilityController.Encrypt(NewPassword, "dbmanagment");
				user.ID = model.ID;
				Int64 RecordID = user.ChangeUserPassword();
				if (RecordID == -1)
				{
					return "InvalidPassword";
				}
				else
				{
					return "0";
				}
			}
			else
			{
				return "PolicyInvalid";
			}
		}

		public bool IsValid(string Password)
		{
			int Minimum_Length = 5;
			int Maximum_Length = 8;
			int Upper_Case_length = 1;
			int Lower_Case_length = 1;
			int NonAlpha_length = 1;
			int Numeric_length = 1;

			if (Password.Length < Minimum_Length)
				return false;
			if (Password.Length > Maximum_Length)
				return false;
			if (UpperCaseCount(Password) < Upper_Case_length)
				return false;
			if (LowerCaseCount(Password) < Lower_Case_length)
				return false;
			if (NumericCount(Password) < Numeric_length)
				return false;
			if (NonAlphaCount(Password) < NonAlpha_length)
				return false;
			return true;
		}
		private int UpperCaseCount(string Password)
		{
			return Regex.Matches(Password, "[A-Z]").Count;
		}

		private int LowerCaseCount(string Password)
		{
			return Regex.Matches(Password, "[a-z]").Count;
		}
		private int NumericCount(string Password)
		{
			return Regex.Matches(Password, "[0-9]").Count;
		}
		private int NonAlphaCount(string Password)
		{
			return Regex.Matches(Password, @"[^0-9a-zA-Z\._]").Count;
		}
	}
}
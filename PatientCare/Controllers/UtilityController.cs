using DBManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DBManagement.Controllers
{
    public class UtilityController 
    {
		public static string Encrypt(string strToEncrypt, string strKey)
		{
			try
			{
				TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider();
				MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
				byte[] byteHash, byteBuff;
				string strTempKey = strKey;
				byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
				objHashMD5 = null;
				objDESCrypto.Key = byteHash;
				objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
				byteBuff = ASCIIEncoding.ASCII.GetBytes(strToEncrypt);
				return Convert.ToBase64String(objDESCrypto.CreateEncryptor().
					TransformFinalBlock(byteBuff, 0, byteBuff.Length));
			}
			catch (Exception ex)
			{
				UtilityController.LogException(ex, MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
			}

			return "";
		}

		public static string Decrypt(string strEncrypted, string strKey)
		{
			try
			{
				TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider();
				MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
				byte[] byteHash, byteBuff;
				string strTempKey = strKey;
				byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
				objHashMD5 = null;
				objDESCrypto.Key = byteHash;
				objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
				byteBuff = Convert.FromBase64String(strEncrypted);
				string strDecrypted = ASCIIEncoding.ASCII.GetString
				(objDESCrypto.CreateDecryptor().TransformFinalBlock
				(byteBuff, 0, byteBuff.Length));
				objDESCrypto = null;
				return strDecrypted;
			}
			catch (Exception ex)
			{
				UtilityController.LogException(ex, MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
			}
			return "";
		}

		public static void LogException(Exception e, string Controller, string Function)
		{
			ExceptionLogModel model = new ExceptionLogModel();
			model.StackTrace = e.StackTrace;
			model.Exception = e.ToString();
			model.ControllerName = Controller;
			model.FunctionName = Function;
			model.UserID = 0;

			model.LogException();
		}

		public void SendEmail(string Username, string Password, string EmailID, string Subject)
		{
			try
			{
				StringBuilder SBEmail = new StringBuilder();
				SBEmail.AppendLine(System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~\EmailTemplate\ForgetPwd.html")));

				SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["smtpclient"]);
				SmtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
				SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["mailUserName"], ConfigurationManager.AppSettings["mailPwd"]);
				SmtpServer.EnableSsl = false;

				MailMessage mail = new MailMessage();
				mail.IsBodyHtml = true;

				mail.From = new MailAddress(ConfigurationManager.AppSettings["mailFrom"]);
				mail.To.Add(EmailID);

				if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["mailBCC"]))
				{
					mail.Bcc.Add(ConfigurationManager.AppSettings["mailBCC"]);
				}

				mail.Subject = Subject;

				SBEmail = SBEmail.Replace("@Username", Username);
				SBEmail = SBEmail.Replace("@Password", Password);
				mail.Body = SBEmail.ToString();

				SmtpServer.Send(mail);
				mail.Dispose();
				SmtpServer.Dispose();
			}
			catch (Exception ex)
			{
				UtilityController.LogException(ex, MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
			}
		}
	}
}
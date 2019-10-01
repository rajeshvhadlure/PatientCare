using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;

namespace DBManagement.Controllers
{
    public class ImportController : Controller
    {
        // GET: Import
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Index(HttpPostedFileBase postedFile)
		{
			string filePath = string.Empty;
			if (postedFile != null)
			{
				string path = Server.MapPath("~/Uploads/");
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}

				filePath = path + Path.GetFileName(postedFile.FileName);
				string extension = Path.GetExtension(postedFile.FileName);
				postedFile.SaveAs(filePath);

				string conString = string.Empty;
				switch (extension)
				{
					case ".xls": //Excel 97-03.
						conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
						break;
					case ".xlsx": //Excel 07 and above.
						conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
						break;
				}

				DataTable dt = new DataTable();
				conString = string.Format(conString, filePath);

				using (OleDbConnection connExcel = new OleDbConnection(conString))
				{
					using (OleDbCommand cmdExcel = new OleDbCommand())
					{
						using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
						{
							cmdExcel.Connection = connExcel;

							//Get the name of First Sheet.
							connExcel.Open();
							DataTable dtExcelSchema;
							dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
							string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
							connExcel.Close();

							//Read Data from First Sheet.
							connExcel.Open();
							cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
							odaExcel.SelectCommand = cmdExcel;
							odaExcel.Fill(dt);
							connExcel.Close();
						}
					}
				}

				conString = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
				using (SqlConnection con = new SqlConnection(conString))
				{
					using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
					{
						//Set the database table name.
						sqlBulkCopy.DestinationTableName = "dbo.User";

						//[OPTIONAL]: Map the Excel columns with that of the database table
						sqlBulkCopy.ColumnMappings.Add("Id", "Id");
						sqlBulkCopy.ColumnMappings.Add("Name", "Name");
						sqlBulkCopy.ColumnMappings.Add("Mobile", "Mobile");
						sqlBulkCopy.ColumnMappings.Add("Address", "Address");
						sqlBulkCopy.ColumnMappings.Add("Pincode", "Pincode");
						sqlBulkCopy.ColumnMappings.Add("Country", "Country");
						sqlBulkCopy.ColumnMappings.Add("State", "State");
						sqlBulkCopy.ColumnMappings.Add("City", "City");
						sqlBulkCopy.ColumnMappings.Add("Parliamentry", "Parliamentry");
						sqlBulkCopy.ColumnMappings.Add("Legilative", "Legilative");

						con.Open();
						sqlBulkCopy.WriteToServer(dt);
						con.Close();
					}
				}
			}

			return View();
		}
	}
}
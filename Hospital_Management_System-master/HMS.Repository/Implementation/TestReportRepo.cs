using HMS.DAL.Generic_Interface;
using HMS.Models;
using HMS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Implementation
{
	public class TestReportRepo : ItesrReport
	{
		private readonly IGenericRepo<TestReport> db;

		public TestReportRepo(IGenericRepo<TestReport> db)
		{
			this.db = db;
		}
		public IEnumerable<TestReport> GetReport()
		{
			try
			{
				return db.FindAll();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public TestReport GetReportById(int id)
		{
			try
			{
				return db.FindByCondition(x => x.TestReportID == id).FirstOrDefault();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public void SaveReport(TestReport testReport)
		{
			try
			{
				if (testReport.TestReportID > 0)
				{

					db.Update(testReport);
				}
				else
				{
					db.Create(testReport);
				}
				db.Commit();
			}
			catch (Exception)
			{
				throw;
			}
		}
		public void DeleteReport(int id)
		{
			db.Delete(id);
			db.Commit();
		}
	}
}
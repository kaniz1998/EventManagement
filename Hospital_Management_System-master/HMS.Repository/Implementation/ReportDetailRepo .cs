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
	public class ReportDetailRepo : IReportDetails
	{
		private readonly IGenericRepo<ReportDetail> db;

		public ReportDetailRepo(IGenericRepo<ReportDetail> db)
		{
			this.db = db;
		}
		public IEnumerable<ReportDetail> GetReportDetail()
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
		public ReportDetail GetReportDetailById(int id)
		{
			try
			{
				return db.FindByCondition(x => x.ReportDetailID == id).FirstOrDefault();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public void SaveReportDetail(ReportDetail reportDetail)
		{
			try
			{
				if (reportDetail.ReportDetailID > 0)
				{

					db.Update(reportDetail);
				}
				else
				{
					db.Create(reportDetail);
				}
				db.Commit();
			}
			catch (Exception)
			{
				throw;
			}
		}
		public void DeleteReportDetail(int id)
		{
			db.Delete(id);
			db.Commit();
		}
	}
}
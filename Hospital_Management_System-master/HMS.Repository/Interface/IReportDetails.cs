using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Interface
{
	public interface IReportDetails
	{
		IEnumerable<ReportDetail> GetReportDetail();
		ReportDetail GetReportDetailById(int id);
		void SaveReportDetail(ReportDetail reportDetail);
		void DeleteReportDetail(int id);
	}
}
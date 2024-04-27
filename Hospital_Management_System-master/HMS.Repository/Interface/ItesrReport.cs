using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Interface
{
	public interface ItesrReport
	{
		IEnumerable<TestReport> GetReport();
		TestReport GetReportById(int id);
		void SaveReport(TestReport testReport);
		void DeleteReport(int id);
	}
}
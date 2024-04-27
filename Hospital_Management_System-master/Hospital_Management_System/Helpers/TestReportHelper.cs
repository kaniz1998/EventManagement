using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HMS.Models;

namespace Hospital_Management_System.Helpers
{
	public class TestReportHelper
	{
		public TestReportHelper()
		{

		}
		public TestReportHelper(TestReportHelper testReportHelper)
		{
			this.TestReportID = testReportHelper.TestReportID;
			this.ReportDetailID = testReportHelper.ReportDetailID;
			this.PrescriptionID = testReportHelper.PrescriptionID;
			this.Result = testReportHelper.Result;
		}
		public int TestReportID { get; set; }
		public int ReportDetailID { get; set; }
		public int PrescriptionID { get; set; }
		public string Result { get; set; } = default!;
		public TestReport GetTestReport()
		{
			TestReport testReport = new TestReport();
			testReport.TestReportID = this.TestReportID;
			testReport.ReportDetailID = this.ReportDetailID;
			testReport.PrescriptionID = this.PrescriptionID;
			testReport.Result = this.Result;
			return testReport;
		}

	}
}
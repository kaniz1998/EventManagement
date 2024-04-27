using HMS.Models;

namespace Hospital_Management_System.Helpers
{
	public class ReportDetailsHelper
	{
		public ReportDetailsHelper()
		{

		}
		public ReportDetailsHelper(ReportDetail reportDetail)
		{
			this.ReportDetailID = reportDetail.ReportDetailID;
			this.TestID = reportDetail.TestID;
			this.TestName = reportDetail.TestName;
			this.Reference_Value = reportDetail.Reference_Value;
		}

		public int ReportDetailID { get; set; }
		public int TestID { get; set; }
		public string TestName { get; set; } = default!;
		public string Reference_Value { get; set; } = default!;
		//NAV ForeignKey Hobe Na
		//public virtual Test? Test { get; set; }
		//public ICollection<TestReport>? TestReports { get; set; } = new List<TestReport>();
		public ReportDetail GetReportDetails()
		{
			ReportDetail reportDetail = new ReportDetail();
			reportDetail.ReportDetailID = this.ReportDetailID;
			reportDetail.TestID = this.TestID;
			reportDetail.TestName = this.TestName;
			reportDetail.Reference_Value = this.Reference_Value;
			return reportDetail;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
	public class ReportDetail
	{
		public int ReportDetailID { get; set; }
		public int TestID { get; set; }
		public string TestName { get; set; } = default!;
		public string Reference_Value { get; set; } = default!;
		//NAV ForeignKey Hobe Na
		public virtual Test? Test { get; set; }
		public ICollection<TestReport>? TestReports { get; set; } = new List<TestReport>();

	}
}
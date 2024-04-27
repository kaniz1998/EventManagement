using HMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
	public class TestReport
	{
		[Key]
		public int TestReportID { get; set; }

		[ForeignKey("ReportDetail")]
		public int ReportDetailID { get; set; }

		[ForeignKey("Prescriptions")]
		public int PrescriptionID { get; set; }

		[Required(ErrorMessage = "Enter RESULT")]
		[StringLength(250, ErrorMessage = "Please do not enter values over 250 characters")]
		public string Result { get; set; } = default!;

		//nav
		public Prescription Prescriptions { get; set; } = default!;

		public ReportDetail ReportDetail { get; set; } = default!;
	}
}
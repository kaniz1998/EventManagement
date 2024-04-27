using System.ComponentModel.DataAnnotations;

namespace HMS.Models.NumberGeneratorHelper
{
	public class NumberCounterRecord
	{
		[Key]
		public int ID { get; set; }
		public DateTime Date { get; set; }

		public int Counter { get; set; }
	}
}

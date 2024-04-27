using HMS.DAL.Data;
using HMS.Models.NumberGeneratorHelper;

namespace Hospital_Management_System.Helpers
{
	public class NumberGeneratorHelper
	{
		private readonly HospitalDbContext _context;

		public NumberGeneratorHelper(HospitalDbContext context)
		{
			_context = context;
		}

		public string GenerateNumber()
		{
			//today date as "ddMMyy"
			string currentDate = DateTime.Now.ToString("ddMMyy");

			//today date for Counter
			int counter = GetCounterForDate(DateTime.Now.Date);

			int minimumDigits = 1;

			string code = (counter + 1).ToString(new string('0', minimumDigits));

			// Update counter 
			UpdateCounterForDate(DateTime.Now.Date, counter + 1);

			string generatedNumber = currentDate + "-" + code;

			return generatedNumber;
		}

		private int GetCounterForDate(DateTime date)
		{
			// Initialize counter 0 if it doesn't exist
			if (!_context.NumberCounterRecords.Any(r => r.Date == date))
			{
				return 0;
			}

			var record = _context.NumberCounterRecords.First(r => r.Date == date);

			return record.Counter;
		}

		private void UpdateCounterForDate(DateTime date, int newCounter)
		{
			//record doesn't exist, so creat
			if (!_context.NumberCounterRecords.Any(r => r.Date == date))
			{
				_context.NumberCounterRecords.Add(new NumberCounterRecord { Date = date, Counter = newCounter });
			}
			else
			{
				var record = _context.NumberCounterRecords.First(r => r.Date == date);
				record.Counter = newCounter;
			}

			_context.SaveChanges();
		}
	}
}

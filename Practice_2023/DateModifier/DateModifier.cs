using System;
namespace DateModifier
{
	public class DateModifier
	{
		public DateModifier() { }

		public static TimeSpan CalculateDateDifference(int[] date1, int[] date2)
		{
			
			DateTime firstDate = new DateTime(date1[0], date1[1], date1[2]);
            DateTime secondDate = new DateTime(date2[0], date2[1], date2[2]);
			TimeSpan differenceInDays = firstDate - secondDate;
			return differenceInDays;
        }
    }
}


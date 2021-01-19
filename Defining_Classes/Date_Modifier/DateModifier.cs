using System;

namespace Date_Modifier
{
    public static class DateModifier
    {
        public static double GetDaysDifference(string one, string two)
        {
            DateTime dayOne = DateTime.Parse(one);
            DateTime dayTwo = DateTime.Parse(two);
            double result = (dayTwo - dayOne).TotalDays;
            return Math.Abs(result);
        }
    }
}

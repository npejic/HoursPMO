using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeksInMonthAndYear
{
    public class WeeksNumbers
    {
        //method returns list with int that represent week numbers in selected month and year
        public static List<int> WeeksNumberInYearPerMonth(int SelectedMonthNo, int SelectedYearNo)
        {
            int weekCounter = 0;
            //FirstMondayInYear initially get value of first day in year, whatever that day is
            DateTime firstDayInYear = new DateTime(SelectedYearNo, 1, 1);
            DateTime FirstMondayInYear = firstDayInYear;

            //while loop adds one day to FirstMondayInYear until FirstMondayInYear really is Monday
            while (FirstMondayInYear.DayOfWeek != DayOfWeek.Monday)
            {
                FirstMondayInYear = FirstMondayInYear.AddDays(1);
            }

            List<DateTime> dates = new List<DateTime>();
            //endDate represents last day in selected month and year, whatever that day is
            DateTime endDate = new DateTime(SelectedYearNo, SelectedMonthNo, DateTime.DaysInMonth(SelectedYearNo, SelectedMonthNo));
            
            //dates get all Mondays from first Monday in year until last day in selected month and year 
            for (var dt = FirstMondayInYear; dt <= endDate; dt = dt.AddDays(7))
            {
                dates.Add(dt);
            }

            //weekCounter gets number of weeks from FirstMondayInYear to endDate
            weekCounter = dates.Count();
            
            //week counts as 1 if number of working days is 3,4 or 5 days
            if (firstDayInYear.DayOfWeek == DayOfWeek.Tuesday || FirstMondayInYear.DayOfWeek == DayOfWeek.Wednesday)
                weekCounter++;
            if (endDate.DayOfWeek == DayOfWeek.Monday || endDate.DayOfWeek == DayOfWeek.Tuesday)
                weekCounter--;

            //countOfWeeksInSelectedMonth are numbers of weeks in selected months and year
            var countOfWeeksInSelectedMonth = dates.Count(a => a.Month == SelectedMonthNo);

            //numbersOfWeeksInSelectedMonth is return value for this method, sorted reverse of countOfWeeksInSelectedMonth
            
            var numbersOfWeeksInSelectedMonth = new List<int>();
            for (int i = countOfWeeksInSelectedMonth; i >= 0; i--)
            {
                numbersOfWeeksInSelectedMonth.Add(weekCounter - i);
            }
            
            return numbersOfWeeksInSelectedMonth;
        }
    }
}

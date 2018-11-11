using System;

namespace PaymentDateCheck
{
    public class Bill
    {
        //bring in holiday service to check for holidays
        //use dependency injection

        private IHolidayService _holidayService;

        public Bill(IHolidayService newHolidayService)
        {
            _holidayService = newHolidayService;
        }

        public DateTime CheckDate (DateTime dueDate)
        {   
            while (_holidayService.isHoliday(dueDate))
            {
                dueDate = dueDate.AddDays(1);
            }
            if (dueDate.DayOfWeek == DayOfWeek.Saturday)
            {
                dueDate = dueDate.AddDays(2);
                return new DateTime(dueDate.Year, dueDate.Month, dueDate.Day);
            }
            else if (dueDate.DayOfWeek == DayOfWeek.Sunday)
            {
                dueDate = dueDate.AddDays(1);
                return new DateTime(dueDate.Year, dueDate.Month, dueDate.Day);
            }
            return dueDate;
        }
    }

}


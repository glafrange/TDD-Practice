using NUnit.Framework;
using PaymentDateCheck;
using System;
using System.Collections.Generic;

namespace Tests
{    
    [TestFixture]
    public class BillShould
    {
        [TestCase(2018, 11, 9)]
        [TestCase(2018, 4, 4)]
        [TestCase(2019, 2, 28)]
        public void ifBussinessDay_ReturnDueDate(int year, int month, int day)
        {
            var input = new DateTime(year, month, day);
            var mockHolidayService = new HolidayService();
            var _bill = new Bill(mockHolidayService);
            var output = _bill.CheckDate(input);
            var expected = input;
            Assert.AreEqual(expected, output);
        }

        [TestCase(2018, 11, 10, 2018, 11, 12)]
        [TestCase(2018, 9, 29, 2018, 10, 1)]
        [TestCase(2019, 3, 30, 2019, 4, 1)]
        public void ifSaturday_ReturnMonday(int year, int month, int day, int expectedYear, int expectedMonth, int expectedDay)
        {
            var input = new DateTime(year, month, day);
            var mockHolidayService = new HolidayService();
            var _bill = new Bill(mockHolidayService);
            var output = _bill.CheckDate(input);
            var expected = new DateTime(expectedYear, expectedMonth, expectedDay);
            Assert.AreEqual(expected, output);
        }

        [TestCase(2018, 11, 11, 2018, 11, 12)]
        [TestCase(2018, 9, 30, 2018, 10, 1)]
        [TestCase(2017, 12, 31, 2018, 1, 1)]
        public void ifSunday_ReturnMonday(int year, int month, int day, int expectedYear, int expectedMonth, int expectedDay)
        {
            var input = new DateTime(year, month, day);
            var mockHolidayService = new HolidayService();
            var _bill = new Bill(mockHolidayService);
            var output = _bill.CheckDate(input);
            var expected = new DateTime(expectedYear, expectedMonth, expectedDay);
            Assert.AreEqual(expected, output);
        }

        [TestCase(2018, 12, 25)]
        [TestCase(2018, 8, 3)]
        public void ifHoliday_ReturnNonHoliday(int year, int month, int day)
        {
            var input = new DateTime(year, month, day);
            var mockHolidayService = new HolidayService();
            var _bill = new Bill(mockHolidayService);
            var output = _bill.CheckDate(input);
            bool isHoliday = mockHolidayService.isHoliday(output);
            Assert.IsFalse(isHoliday);
        }

        [TestCase(2018, 12, 25, 2018, 12, 26)]
        [TestCase(2018, 8, 3, 2018, 8, 6)]
        public void ifHoliday_ReturnWeekday(int year, int month, int day, int expectedYear, int expectedMonth, int expectedDay)
        {
            var input = new DateTime(year, month, day);
            var mockHolidayService = new HolidayService();
            var _bill = new Bill(mockHolidayService);
            var output = _bill.CheckDate(input);
            var expected = new DateTime(expectedYear, expectedMonth, expectedDay);
            Assert.AreEqual(expected, output);
        }
    }
}
using DateAndTime.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DateAndTime.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var now = DateTime.Now;// shows the particular local representaion of the current time
            var nows = "02/12/1999";
             ViewBag.Allow = DateTime.Parse(nows, CultureInfo.GetCultureInfo("en-GB"));
            
///////////////// ////////converting date time using timezones
////// read up on interop with external systems

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. Australia Standard Time");
            var sydneyTime = TimeZoneInfo.ConvertTime(now, timeZone);// helps us to convert from one time zone to another
            ViewBag.Message = now;  
             ViewBag.Messages = sydneyTime;
            
            
            var rigtNow = DateTimeOffset.UtcNow;// shows the current time without a timezone, the uiversal time
        var converted = rigtNow.ToOffset(TimeSpan.)
            ViewBag.DateTimeNow = DateTimeOffset.Now;// can be problematic when persising into a db expecially in cases of different time zones
          
 //////////////////// DateTime.Offset

            ViewBag.DateTimeOffsetNow = DateTimeOffset.Now;// it provides us wt the same functionalities like DateTime but it also adds the tiemzone information with it. It povides an offset of the utc time, e.i the universal time.
            var DateTimeOffsetNow = DateTimeOffset.Now;// it provides us wt the same functionalities like DateTime but it also adds the tiemzone information with it. It povides an offset of the utc time, e.i the universal time.
           
            foreach(var timezone in TimeZoneInfo.GetSystemTimeZones())
            {
                    ViewBag.timeZones = timezone;
               
            }   
            
            foreach(var timezone in TimeZoneInfo.GetSystemTimeZones())
            {
                if (timezone.GetUtcOffset(DateTimeOffsetNow)== DateTimeOffsetNow.Offset)
                {
                    ViewBag.timeZone = timezone;

                    var name = DateTime.UtcNow;

                } 
            }
   



////////////////////////////////   Parsing Date

            var Date = "9/10/2019 10:00:00 PM";
            var Dates = "9/10/2019 10:00:00 PM +2:00";
            var parsedData = DateTime.ParseExact(Date, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);//takes a specific string format and converts it to the datetime equivalent format with a user specified string format to view
            var parsedDatas = DateTime.Parse(Dates, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);//takes a specific string format and converts it to the datetime equivalent format
            ViewBag.ParsedData = parsedData;          
            ViewBag.parsedDataKind = parsedData.Kind;
            ViewBag.ParsedDatas = parsedDatas;
            ViewBag.ParsedDatasKind = parsedDatas.Kind;


///////////////////////////////////// formatting Date and time

            var parsData = DateTime.ParseExact(Date, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);//takes a specific string format and converts it to the datetime equivalent format with a user specified string format to view
            ViewBag.formattedDate = parsData.ToString("yyyy-MMM-dd");
            ViewBag.formattedDates = parsData.ToString("s");
            var parseData = DateTimeOffset.ParseExact(Date, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);//takes a specific string format and converts it to the datetime equivalent format with a user specified string format to view
            var parseDataOffset = parseData.ToOffset(TimeSpan.FromHours(1));
            ViewBag.formatDateWithOffset = parseDataOffset.ToString("o");

//////////////////////////////// Utc is also known as ZuluTime/Millitary Time
//using utc in all our application to store date makes it easy to convert date and time with offset easily without ambiguity
            var New = DateTimeOffset.UtcNow;
            ViewBag.New = New;
            ViewBag.News = New.ToLocalTime();
            var Old = DateTime.Now;
            ViewBag.Old = Old;
            ViewBag.old = Old.ToUniversalTime();

            return View();
        }

        public ActionResult About()
        {

///////////////////////////////////////// Manipulating  Dates
            ///Timespan is usefull to manipulate dates

            var timespan = new TimeSpan(60, 100, 200);
            ViewBag.timespan = timespan;
            ViewBag.timespann = timespan.Hours;
            ViewBag.timespannd = timespan.TotalHours;
            ViewBag.Message = "Your application description page.";
///////////////////  making use of timespan to calculate 

            var start = DateTime.UtcNow;
            var end = start.AddSeconds(45);
            TimeSpan difference = end - start;
            ViewBag.difference = difference.Seconds;

/////////////////get week number 

             Calendar calender = CultureInfo.InvariantCulture.Calendar;
            var startweek = new DateTimeOffset(2007, 12, 31, 0, 0, 0, TimeSpan.Zero);
            var week = calender.GetWeekOfYear(startweek.DateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            var Isoweek = ISOWeek.GetIso8601WeekOfYear(startweek.DateTime);
            
            ViewBag.week = week;
            ViewBag.Isoweek = Isoweek;

//////////////////////////////////// extending dates

            var extendweek = new DateTimeOffset(2007, 12, 31, 0, 0, 0, TimeSpan.Zero);
            ViewBag.extendweek = extendweek;
            ViewBag.extended  = ExtendDates.ExtendMonths(extendweek, 6);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using pwaSepehr.MyModels;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace pwaSepehr.Business
{
    public class dttm
    {
        public DateTime ToMiLadi(string PersianDate)
        {
            var pc = new PersianCalendar();
            string[] values = PersianDate.Split('/');
            int y = int.Parse(values[0]);
            int m = int.Parse(values[1]);
            int d = int.Parse(values[2]);
            var dt = new DateTime(y, m, d, new PersianCalendar());
            DateTime miladi = pc.ToDateTime(y, m, d, 0, 0, 0, 0);
            return miladi;
        }
        public string ToPersianDateString(DateTime dt)
        {
            var pr = new PersianCalendar();
            return string.Format("{1}{0}{2}{0}{3}",
                CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator,
                pr.GetYear(dt).ToString("0000"), pr.GetMonth(dt).ToString("00"), pr.GetDayOfMonth(dt).ToString("00"));
        }
        public string Get_Tarikh()
        {
            var today = DateTime.Now;
            return ToPersianDateString(today);
        }
        public string Get_Time()
        {
            return DateTime.Now.ToString("HH:mm");
        }
        public string MakeDate(string PersianDate)
        {
            var pc = new PersianCalendar();
            string[] values = PersianDate.Split('/');
            int y = int.Parse(values[0]);
            int m = int.Parse(values[1]);
            int d = int.Parse(values[2]);

            if (y.ToString().Length == 2)
            {
                if (y > 90)
                {
                    var x = "13" + y.ToString();
                    y = int.Parse(x);
                }
            }

            var dt = new DateTime(y, m, d, new PersianCalendar());
            DateTime miladi = pc.ToDateTime(y, m, d, 0, 0, 0, 0);
            return ToPersianDateString(miladi);
        }
        public string ezaf_Kam_Day(string PersianDate, int Count)
        {
            DateTime dt = ToMiLadi(PersianDate);
            dt = dt.AddDays(Count);
            return ToPersianDateString(dt);
        }
        public string Get_Mah_Name(string PersianDate)
        {
            string[] values = PersianDate.Split('/');
            int m = int.Parse(values[1]);
            string mahName = "";
            switch (m)
            {
                case 1:
                    mahName = "??????????????";
                    break;
                case 2:
                    mahName = "????????????????";
                    break;
                case 3:
                    mahName = "??????????";
                    break;
                case 4:
                    mahName = "??????";
                    break;
                case 5:
                    mahName = "??????????";
                    break;
                case 6:
                    mahName = "????????????";
                    break;
                case 7:
                    mahName = "??????";
                    break;
                case 8:
                    mahName = "????????";
                    break;
                case 9:
                    mahName = "??????";
                    break;
                case 10:
                    mahName = "????";
                    break;
                case 11:
                    mahName = "????????";
                    break;
                case 12:
                    mahName = "??????????";
                    break;
            }
            return mahName;
        }
        public string Get_Mah_Name(int Mah)
        {
            string mahName = "";
            switch (Mah)
            {
                case 1:
                    mahName = "??????????????";
                    break;
                case 2:
                    mahName = "????????????????";
                    break;
                case 3:
                    mahName = "??????????";
                    break;
                case 4:
                    mahName = "??????";
                    break;
                case 5:
                    mahName = "??????????";
                    break;
                case 6:
                    mahName = "????????????";
                    break;
                case 7:
                    mahName = "??????";
                    break;
                case 8:
                    mahName = "????????";
                    break;
                case 9:
                    mahName = "??????";
                    break;
                case 10:
                    mahName = "????";
                    break;
                case 11:
                    mahName = "????????";
                    break;
                case 12:
                    mahName = "??????????";
                    break;
            }
            return mahName;
        }
        public string Get_Day_Name_Week(string PersianDate)
        {
            DateTime dt = ToMiLadi(PersianDate);
            int d = (int)dt.DayOfWeek;
            string DayName = "";
            switch (d)
            {
                case 6:
                    DayName = "????????";
                    break;
                case 0:
                    DayName = "???? ????????";
                    break;
                case 1:
                    DayName = "???? ????????";
                    break;
                case 2:
                    DayName = "???? ????????";
                    break;
                case 3:
                    DayName = "???????? ????????";
                    break;
                case 4:
                    DayName = "?????? ????????";
                    break;
                case 5:
                    DayName = "????????";
                    break;
            }
            return DayName;
        }
        public int Tafazol_Tarikh(string PersianDate1, string PersianDate2)
        {
            DateTime dt1 = ToMiLadi(PersianDate1);
            DateTime dt2 = ToMiLadi(PersianDate2);
            TimeSpan ts = dt1 - dt2;
            return ts.Days;
        }
    }
}

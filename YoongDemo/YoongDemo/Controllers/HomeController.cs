using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using YoongDemo.Models;

namespace YoongDemo.Controllers
{
    public class HomeController : Controller
    {
        private Age age { get; set; }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayBirth(string dateOfbirth)
        {
            age = new Age(ConvertDate(dateOfbirth), DateTime.Today);
            StringBuilder sb = new StringBuilder();
            if(ConvertDate(dateOfbirth) > DateTime.Today)
            {
                sb.Append("Xin đừng troll em!!!!!!!!");
            }
            //sb.Append(age.Days+"/"+age.Months+"/"+age.Years+"..."+age.NextBirth(DateParsed, DateTime.Today).Days + "/" + age.NextBirth(DateParsed, DateTime.Today).Months + "/" + age.NextBirth(DateParsed, DateTime.Today).Years);
            sb.Append("Born: " + String.Format("{0:D}", ConvertDate(dateOfbirth)) +
                "</br>Age: " + age.Years +
                "</br>Next Birthday: " + String.Format("{0:D}", ConvertDate(age.NextBirth(ConvertDate(dateOfbirth), DateTime.Today))));
            Response.Write(sb);
            return null;
        }
        public DateTime ConvertDate(string dt)
        {
            DateTime DateParsed;
            DateTime.TryParse(dt, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, out DateParsed);
            return DateParsed;
        }
    }
}
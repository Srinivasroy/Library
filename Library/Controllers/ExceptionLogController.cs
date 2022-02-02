using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using context = System.Web.HttpContext;

namespace Library.Controllers
{
    public class ExceptionLogController : Controller

    {
        private LoginEntities10 exp = new LoginEntities10();
        private static String exepurl;
        // GET: ExceptionLog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExceptionMsg()
        {
            return View();
        }


        public static void ExptoDB(Exception ex)
        {

             
                 
                 ExceptionLogging exception = new ExceptionLogging();
                 exepurl = context.Current.Request.Url.ToString();
                exception.ExceptionMsg_= ex.Message;
                exception.ExceptionType_=ex.GetType().Name.ToString();
                exception.ExceptionURL_ = exepurl;
            exception.ExceptionSource_ = ex.StackTrace.ToString();
           // exp.SaveChanges();

         }
    }
}
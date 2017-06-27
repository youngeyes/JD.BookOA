using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JD.BookOA.WebApp.Models
{
    public class AbnormalCaptureAttribute : HandleErrorAttribute
    {
        public static Queue<Exception> AbnomalQueue = new Queue<Exception>();

        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            AbnomalQueue.Enqueue(filterContext.Exception);//异常入队
            filterContext.HttpContext.Response.Redirect("/error");

        }
    }
}
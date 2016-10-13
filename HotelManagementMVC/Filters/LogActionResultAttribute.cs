using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace HotelManagementMVC.Filters
{

    public class LogActionResultAttribute : ActionFilterAttribute, IExceptionFilter
    {
        //public override void OnActionExecuting(HttpActionContext actionContext)
        //{
        //    if (actionContext.Request.Method == HttpMethod.Post)
        //    {
        //        var postData = actionContext.ActionArguments;
        //        //FileStream f = new FileStream()
        //        //do logging here
        //    }
        //}
        //public override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    //using (StreamWriter writer = new StreamWriter(Server.MapPath("/Log.txt"), true))
        //    //{
        //    //    writer.WriteLine(eMail);
        //    //}
        //    //FileStream file = new FileStream("~/Log.txt",FileMode.Append);
        //    //file.Write(BitConverter.ton(filterContext.ActionDescriptor.ActionName), 0, 0);//  Write(filterContext.ActionDescriptor.ActionName);

        //}
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{ }
        //public override void OnResultExecuted(ResultExecutedContext filterContext)
        //{ }
        //public override void OnResultExecuting(ResultExecutingContext filterContext)
        //{ }
        private void Logging(string s)
        {
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Log.txt"),s);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string s = "\n"+DateTime.Now.ToString() + "  " + filterContext.ActionDescriptor.ActionName + "  " +
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            Logging(s);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string s = "\n" + DateTime.Now.ToString() + "  " + filterContext.ActionDescriptor.ActionName + "  " +
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            Logging(s);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string s = "\n" + DateTime.Now.ToString() + "  " + filterContext.RouteData.Values["controller"].ToString() + "  " +
                filterContext.RouteData.Values["action"].ToString();
            Logging(s);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string s = "\n" + DateTime.Now.ToString() + "  " + filterContext.RouteData.Values["controller"].ToString() + "  " +
                 filterContext.RouteData.Values["action"].ToString();
            Logging(s);
        }
        public void OnException(ExceptionContext filterContext)
        {
            string s = "\n" + DateTime.Now.ToString() + "  " + filterContext.RouteData.Values["controller"].ToString() + "  " +
                  filterContext.RouteData.Values["action"].ToString()+"  "+filterContext.Exception.StackTrace;
            Logging(s);
        }
    }
}
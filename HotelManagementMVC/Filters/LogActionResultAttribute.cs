using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementMVC.Filters
{
    
    public class LogActionResultAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //using (StreamWriter writer = new StreamWriter(Server.MapPath("/Log.txt"), true))
            //{
            //    writer.WriteLine(eMail);
            //}
            //FileStream file = new FileStream("~/Log.txt",FileMode.Append);
            //file.Write(BitConverter.ton(filterContext.ActionDescriptor.ActionName), 0, 0);//  Write(filterContext.ActionDescriptor.ActionName);
            
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        { }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        { }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        { }
    }
}
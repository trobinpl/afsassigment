using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace afsassigment.ActionFilters
{
    public class LogRequestActionFilter : ActionFilterAttribute
    {
        private string LogsPath = string.Empty;

        public LogRequestActionFilter() : base()
        {
            this.LogsPath = WebConfigurationManager.AppSettings["LogsPath"];
        }

        public LogRequestActionFilter(string logsPath) : base()
        {
            this.LogsPath = logsPath;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            WriteRequestLog("OnActionExecuting", filterContext.RequestContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            WriteRequestLog("OnActionExecuted", filterContext.RequestContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            WriteRequestLog("OnResultExecuting", filterContext.RequestContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            WriteRequestLog("OnResultExecuted", filterContext.RequestContext);
        }

        private void WriteRequestLog(string stage, RequestContext requestContext)
        {
            RequestLogEntry logEntry = new RequestLogEntry(requestContext);

            string folder = HttpContext.Current.Request.MapPath(this.LogsPath);
            string fileName = DateTime.Now.ToString("yyyy-MM-dd");
            using (StreamWriter outputFile = new StreamWriter(folder + @"\" + $"{fileName}.txt", true))
            {

                outputFile.WriteLine($"[{stage}]");
                outputFile.WriteLine($"{logEntry}");
            }
        }

        private class RequestLogEntry
        {
            private RequestContext RequestContext;

            public RequestLogEntry(RequestContext requestContext)
            {
                this.RequestContext = requestContext;
            }

            public override string ToString()
            {
                var sentParamsDictionary = this.RequestContext.HttpContext.Request.Form.AllKeys.ToDictionary(k => k, k => this.RequestContext.HttpContext.Request.Form[k]);
                var sentParams = new JavaScriptSerializer().Serialize(sentParamsDictionary);

                StringBuilder logEntryStringBuilder = new StringBuilder();

                logEntryStringBuilder.AppendLine($"REQUEST [{this.RequestContext.HttpContext.Timestamp}] Url: {this.RequestContext.HttpContext.Request.Url}, Method: {this.RequestContext.HttpContext.Request.HttpMethod}, Controller: {this.RequestContext.RouteData.Values["controller"]}, Action: {this.RequestContext.RouteData.Values["action"]}, ContentType: {this.RequestContext.HttpContext.Request.ContentType}, Params: {sentParams}");
                logEntryStringBuilder.AppendLine($"RESPONSE [{this.RequestContext.HttpContext.Timestamp}] Content-Type: {this.RequestContext.HttpContext.Response.ContentType}, Status: {this.RequestContext.HttpContext.Response.Status}");

                return logEntryStringBuilder.ToString();
            }
        }
    }
}
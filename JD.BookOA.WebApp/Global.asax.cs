using JD.BookOA.WebApp.Models;
using log4net;
using Spring.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JD.BookOA.WebApp
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : SpringMvcApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();//读取Log4Net配置信息
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            string fileLongError = Server.MapPath("/log/");//写错误日志
            //开启一个线程来不断监听错误信息
            ThreadPool.QueueUserWorkItem((a) =>
            {
                while (true)//用死循环监听,一直执行这个线程,不会停止
                {
                    if (AbnormalCaptureAttribute.AbnomalQueue.Count > 0)
                    {
                        Exception ab = AbnormalCaptureAttribute.AbnomalQueue.Dequeue();
                        //string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                        //File.AppendAllText(fileLongError+fileName,ab.ToString(),System.Text.Encoding.UTF8);//按照utf8编码储存
                        ILog logger = LogManager.GetLogger("errorMsg");
                        logger.Error(ab.ToString());
                    }
                    else
                    {
                        Thread.Sleep(4000);//没有扫描到错误信息，休息4秒时间，减轻cpu压力
                    }
                }

            }, fileLongError);
        }
    }
}
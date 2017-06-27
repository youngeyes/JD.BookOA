using JD.BookOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JD.BookOA.WebApp.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        public UserInfo LoginUser { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            bool isExt = false;

            if (Request.Cookies["SessionId"] != null)
            {
                string SessionId = Request.Cookies["SessionId"].Value;//接收从Cookie中传递过来的Memcache的key
                object obj = Common.MemcacheHelper.Get(SessionId);//根据key从Memcache中获取用户的信息
                if (obj != null)
                {
                    UserInfo stInfo = Common.SerializerHelper.DeserializeToObject<UserInfo>(obj.ToString());
                    LoginUser = stInfo;
                    isExt = true;
                }


            }
            if (!isExt)
            {
                filterContext.HttpContext.Response.Redirect("/Login");
                return;
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JD.BookOA.Common;
using JD.BookOA.Model;

namespace JD.BookOA.WebApp.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        IBLL.IUserInfoService UserInfoService { get; set; }
        public ActionResult Index()
        {
            Response.Cookies["SessionId"].Value = null;
            //ViewBag.userid = UserInfoService.LoadEutities(c => c.Id > 0).FirstOrDefault();
            return View();
        }
        public ActionResult CheckLogin()
        {
            if (string.IsNullOrEmpty(Request["UserId"]) || string.IsNullOrEmpty(Request["UserPwd"]))
            {
                return Content("null");
            }
            string UserId = Request["UserId"];
            string UserPwd = Request["UserPwd"];
            UserInfo UserInfo = UserInfoService.LoadEutities(u => u.UserId == UserId && u.UserPwd == UserPwd).FirstOrDefault();
            if (UserInfo != null)
            {
                string SessionId = Guid.NewGuid().ToString();//MemcacheHelper，key
                Common.MemcacheHelper.Set(SessionId, Common.SerializerHelper.SerializeToString(UserInfo), DateTime.Now.AddMinutes(240000));
                Response.Cookies["SessionId"].Value = SessionId;//分布式缓存session共享
                UserInfo newsd = UserInfo;
                if (UserInfoService.EditEnity(newsd))
                {
                    return Content("ok");
                }
                else
                {
                    return Content("error");
                }
            }
            else
            {
                return Content("no");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JD.BookOA.WebApp.Controllers
{
    public class CookieController : Controller
    {
        //
        // GET: /Cookie/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 保存cookie
        /// </summary>
        /// <returns></returns>
        public ActionResult SaveCookie()
        {
            string member = Request["member"];
            int memberid = int.Parse(Request["memberid"]);
            HttpCookie cookies = new HttpCookie("userinfo");
            cookies["member"] = Server.UrlEncode(member);
            cookies["memberid"] = Server.UrlEncode(memberid.ToString());
            cookies.Expires = DateTime.Now.AddDays(5);
            Response.Cookies.Add(cookies);
            return Content("ok");
        }
        /// <summary>
        /// 获取cookie
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCookie()
        {
            string member = "";
            int memberid = 0;
            if (Request.Cookies["userinfo"] != null)
            {
                HttpCookie cookies = Request.Cookies["userinfo"];
                member = Server.UrlDecode(cookies["member"]);
                memberid = int.Parse(Server.UrlDecode(cookies["memberid"]));
            }
            return Json(new { member = member, memberid = memberid }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 清除cookie
        /// </summary>
        /// <returns></returns>
        public ActionResult ClearCookie()
        {
            foreach (var cookiename in Request.Cookies.AllKeys)
            {
                HttpCookie cookies = new HttpCookie(cookiename);
                if (cookies != null)
                {
                    cookies.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(cookies);
                    Request.Cookies.Remove(cookiename);
                }
            }
            return Content("ok");
        }
    }
}

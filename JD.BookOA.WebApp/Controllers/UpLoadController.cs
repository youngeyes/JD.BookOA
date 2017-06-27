using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JD.BookOA.WebApp.Controllers
{
    public class UpLoadController : Controller
    {
        //
        // GET: /UpLoad/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UploadEasyImages(HttpPostedFileBase Filedata)
        {
            // 没有文件上传，直接返回
            if (Filedata == null || string.IsNullOrEmpty(Filedata.FileName) || Filedata.ContentLength == 0)
            {
                return HttpNotFound();
            }
            string fileMD5 = Common.ComString.GetStreamMD5(Filedata.InputStream);
            string FileEextension = Path.GetExtension(Filedata.FileName);
            string uploadDate = DateTime.Now.ToString("yyyyMMdd");
            string virtualPath = "/";
            virtualPath = string.Format("/UploadSpace/Images/{0}/{1}{2}", uploadDate, fileMD5, FileEextension);
            string fullFileName = this.Server.MapPath(virtualPath);
            string path = Path.GetDirectoryName(fullFileName);
            Directory.CreateDirectory(path);
            if (!System.IO.File.Exists(fullFileName))
            {
                Filedata.SaveAs(fullFileName);
            }

            var data = new { fullFileName = fullFileName, imgpath = virtualPath.Remove(0, 1) };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UploadEasyVideo(HttpPostedFileBase Filedata)
        {
            // 没有文件上传，直接返回
            if (Filedata == null || string.IsNullOrEmpty(Filedata.FileName) || Filedata.ContentLength == 0)
            {
                return HttpNotFound();
            }
            string fileMD5 = Common.ComString.GetStreamMD5(Filedata.InputStream);
            string FileEextension = Path.GetExtension(Filedata.FileName);
            string uploadDate = DateTime.Now.ToString("yyyyMMdd");
            string virtualPath = "/";
            virtualPath = string.Format("/UploadSpace/Video/{0}/{1}{2}", uploadDate, fileMD5, FileEextension);
            string fullFileName = this.Server.MapPath(virtualPath);
            string path = Path.GetDirectoryName(fullFileName);
            Directory.CreateDirectory(path);
            if (!System.IO.File.Exists(fullFileName))
            {
                Filedata.SaveAs(fullFileName);
            }

            var data = new { fullFileName = fullFileName, imgpath = virtualPath.Remove(0, 1) };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}

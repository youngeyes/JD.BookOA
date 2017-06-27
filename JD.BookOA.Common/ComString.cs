using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace JD.BookOA.Common
{
    public class ComString
    {
        public static string GetMD5(string sDataIn)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(sDataIn);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";

            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }//获取字符串的md5值
        public static string GetIP()
        {
            string tempip = "";
            try
            {
                WebRequest wr = WebRequest.Create("http://www.ip138.com/ips138.asp");
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string all = sr.ReadToEnd(); //读取网站的数据

                int start = all.IndexOf("您的IP地址是：[") + 9;
                int end = all.IndexOf("]", start);
                tempip = all.Substring(start, end - start);
                sr.Close();
                s.Close();
            }
            catch
            {
            }
            return tempip;
        }//获取公网ip地址
        public static string GetStringLfit(string str)//取身份证后6位
        {
            string idc = str;
            char[] chars = idc.ToArray();
            string k = "";
            if (chars.Length > 6)
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    if (chars.Length - i <= 6)
                    {
                        k = k + chars[i];
                    }
                }
            }
            else
            {
                k = "-1";
            }
            return k;

        }

        public static string GetIP_Ad(string IP)
        {
            string tempip = "";
            try
            {
                WebRequest wr = WebRequest.Create("http://www.ip138.com/ips1388.asp?ip=" + IP + "&action=2");
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string all = sr.ReadToEnd(); //读取网站的数据

                tempip = BetweenStr(all, "li>本站主数据：", "</li>");
            }
            catch
            {
            }
            return tempip;
        }

        /// <summary>  
        /// 取文本中间内容  
        /// </summary>  
        /// <param name="oldstr">原文本</param>  
        /// <param name="leftstr">左边文本</param>  
        /// <param name="rightstr">右边文本</param>  
        /// <returns>返回中间文本内容</returns>  
        public static string BetweenStr(string oldstr, string leftstr, string rightstr)
        {
            int i = oldstr.IndexOf(leftstr) + leftstr.Length;
            string temp = oldstr.Substring(i, oldstr.IndexOf(rightstr, i) - i);
            return temp;
        }//取文本中间
        public static bool boolNum(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                try
                {
                    byte strbyte = Convert.ToByte(str[i]);
                    if ((strbyte < 48) || (strbyte > 57))
                    {
                        return false;
                    }

                }
                catch
                {
                    return false;
                }

            }
            return true;
        }
        private static bool boolCh(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                try
                {
                    byte strbyte = Convert.ToByte(str[i]);
                    if ((strbyte < 48) || (strbyte > 57))
                    {
                        return false;
                    }

                }
                catch
                {
                    return true;
                }

            }
            return false;
        }
        public static string ButtonCode(string IDC, string NAME, string PHONE, string UID, string EMAIL)
        {
            if (IDC == "" || NAME == "" || PHONE == "" || UID == "" || EMAIL == "")
            {
                return "检查是否有空项";
            }
            if (boolNum(UID) == false || boolNum(PHONE) == false)
            {
                return "账号，电话号码只能输入数字";
            }
            if (boolCh(NAME) != true)
            {
                return "对不起名字只能是汉字";
            }
            if (IDC.Length < 6 || PHONE.Length != 11)
            {
                return "请查证身份证和电话号码无误";
            }

            return "ok";

        }
        #region ISBN查询
        public static List<string> GetISBN(string ISBN)
        {

            WebRequest wr = WebRequest.Create("https://api.douban.com/v2/book/isbn/" + ISBN);
            Stream s = wr.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(s, Encoding.UTF8);
            string all = sr.ReadToEnd(); //读取网站的数据
            List<string> list = new List<string>();
            string ISBN13 = Deyh(BetweenStr(all, "\"isbn13\":", ","));

            list.Add(Deyh(BetweenStr(all, "\"author\":[", "],")));
            //获取作者信息0
            list.Add(Deyh(BetweenStr(all, "\"pubdate\":", ",")));
            //获取出版日期1
            list.Add(Deyh(BetweenStr(all, "\"large\":", ",")));
            //获取图书图片2
            list.Add(Deyh(BetweenStr(all, ISBN13 + "\"," + "\"title\":", ",")));
            //获取标题3
            list.Add(Deyh(BetweenStr(all, "\"publisher\":", ",")));
            //获取出版社4
            list.Add(Deyh(BetweenStr(all, "\"summary\":", ",")));
            //获取介绍信息5
            list.Add(Deyh(BetweenStr(all, "\"price\":\"", "元")));
            //获取定价6
            return list;

        }
        #endregion

        public static string Deyh(string str)
        {
            try
            {
                return BetweenStr(str, "\"", "\"");
            }
            catch
            {
                return str;
            }
        }
        /// <summary>
        /// 操作excel表格xls
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static DataSet importExcelToDataSet(string FilePath)
        {
            string strConn;
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + FilePath + ";Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            OleDbDataAdapter myCommand = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", strConn);
            DataSet myDataSet = new DataSet();
            try
            {
                myCommand.Fill(myDataSet);
            }
            catch
            {
                // Console.WriteLine(ex.Message );
                // throw new InvalidFormatException("该Excel文件的工作表的名字不正确," + ex.Message);

            }
            return myDataSet;
        }
        /// <summary>
        /// 读取dataset文件
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static List<string> DataToListString(DataSet ds)
        {
            List<string> list = new List<string>();
            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        //System.Console.Write(dr[dc]+"\n");
                        list.Add(dr[dc].ToString());

                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 计算文件流的MD5值
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static String GetStreamMD5(Stream stream)
        {
            MD5 md5Hasher = new MD5CryptoServiceProvider();
            /*计算指定Stream对象的哈希值*/
            byte[] arrbytHashValue = md5Hasher.ComputeHash(stream);
            /*由以连字符分隔的十六进制对构成的String，其中每一对表示value中对应的元素；例如“F-2C-4A”*/
            string strHashData = System.BitConverter.ToString(arrbytHashValue).Replace("-", "");
            return strHashData;
        }
        public static string GetAdress(string classid)
        {
            //F03RA3-1BOOKQ301 
            string f = BetweenStr(classid, "F", "R");
            string r = BetweenStr(classid, "R", "BOOK");
            string k = classid;
            k = k.Replace("BOOK", "|");
            string[] Q = k.Split('|');
            return "图书馆" + f + "楼" + r + "室" + Q[1];
        }

        /// <summary>
        /// 客户端ip(访问用户)
        /// </summary>
        public static string GetUserIp()
        {
            string ip = string.Empty;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"]))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            if (string.IsNullOrEmpty(ip))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            return ip;
        }
        /// <summary>
        /// 收尾法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int CloseoutInt(int a, int b)
        {
            int c = a / b;
            double d = a * 1.0 / b * 1.0;
            if (d > c)
            {
                return c + 1;
            }
            else
            {
                return c;
            }
        }
        //截取字符串
        public static string SplitString(string str, int length)
        {
            string strs = "";
            if (str.Length > length)
            {
                strs = str.Substring(0, length);
            }
            else
            {
                strs = str;
            }
            return strs;
        }
        /// <summary>
        /// 去除Html标记
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns>已经去除后的文字</returns>
        public static string StripHTML(string strHtml)
        {
            string[] aryReg ={ 
          @"<script[^>]*?>.*?</script>", 

          @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>", 
          @"([\r\n])[\s]+", 
          @"&(quot|#34);", 
          @"&(amp|#38);", 
          @"&(lt|#60);", 
          @"&(gt|#62);",  
          @"&(nbsp|#160);",  
          @"&(iexcl|#161);", 
          @"&(cent|#162);", 
          @"&(pound|#163);", 
          @"&(copy|#169);", 
          @"&#(\d+);", 
          @"-->", 
          @"<!--.*\n" 

         };

            string[] aryRep = { 
           "", 
           "", 
           "", 
           "\"", 
           "&", 
           "<", 
           ">", 
           " ", 
           "\xa1",//chr(161), 
           "\xa2",//chr(162), 
           "\xa3",//chr(163), 
           "\xa9",//chr(169), 
           "", 
           "\r\n", 
           "" 
          };

            string newReg = aryReg[0];
            string strOutput = strHtml;
            for (int i = 0; i < aryReg.Length; i++)
            {
                Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, aryRep[i]);
            }

            strOutput.Replace("<", "");
            strOutput.Replace(">", "");
            strOutput.Replace("\r\n", "");


            return strOutput;
        }
    }
}

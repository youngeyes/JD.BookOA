using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JD.BookOA.Model;
using System.Text.RegularExpressions;
using System.Text;
using JD.BookOA.Model.SearchParam;

namespace JD.BookOA.WebApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        IBLL.IParentClassService ParentClassService { get; set; }
        IBLL.IChildClassService ChildClassService { get; set; }
        IBLL.IschildclassService schildclassService { get; set; }
        IBLL.IBookService BookService { get; set; }
        IBLL.IMemberService MemberService { get; set; }
        IBLL.IFriendshipService FriendshipService { get; set; }
        IBLL.IShopping_CartService Shopping_CartService { get; set; }
        IBLL.IOrdersService OrdersService { get; set; }
        IBLL.IMessageService MessageService { get; set; }
        IBLL.ICarouselImgService CarouselImgService { get; set; }
        //首页
        public ActionResult Index()
        {
            ViewBag.pmenu = ParentClassService.LoadEutities(c => c.Id > 0);
            ViewBag.cmenu = ChildClassService.LoadEutities(c => c.Id > 0);
            ViewBag.scmenu = schildclassService.LoadEutities(c => c.Id > 0);
            ViewBag.friend = FriendshipService.LoadEutities(c => c.Id > 0);
            ViewBag.CarouselImg = CarouselImgService.LoadEutities(c => c.Id > 0);
            return View();
        }
        //首页加载新书上架
        public ActionResult Loadnewbook()
        {
            int pageIndex = Request["pageIndex"] != null ? int.Parse(Request["pageIndex"]) : 1;
            int totalCount = 0;
            DateTime now = DateTime.Now;
            DateTime startime = now.AddDays(-5);
            var temp = BookService.LoadPageEntities<DateTime?>(pageIndex, 8, out totalCount, c => c.Reserve1 >= startime && c.Reserve1 <= now, c => c.Reserve1, false);
            int pages = Common.ComString.CloseoutInt(totalCount, 8);
            return Json(new { totalCount = pages, rows = temp }, JsonRequestBehavior.AllowGet);
        }
        //会员注册
        public ActionResult Register()
        {
            ViewBag.pmenu = ParentClassService.LoadEutities(c => c.Id > 0);
            ViewBag.cmenu = ChildClassService.LoadEutities(c => c.Id > 0);
            ViewBag.scmenu = schildclassService.LoadEutities(c => c.Id > 0);
            ViewBag.friend = FriendshipService.LoadEutities(c => c.Id > 0);
            return View();
        }
        public ActionResult RegisterSave()
        {
            string MemberId = Request["MemberId"];
            long Tell = long.Parse(Request["Tell"]);
            string EMail = Request["EMail"];
            bool Sex = bool.Parse(Request["Sex"]);
            string MemberPwd = Request["MemberPwd"];
            var temp = MemberService.LoadEutities(c => c.MemberId == MemberId || c.Tell == Tell || c.EMail == EMail).FirstOrDefault();
            if (temp == null)
            {
                Member Member = new Member();
                Member.MemberId = MemberId;
                Member.Tell = Tell;
                Member.EMail = EMail;
                Member.Sex = Sex;
                Member.MemberPwd = Common.ComString.GetMD5(MemberPwd);
                Member.Registertime = DateTime.Now;
                var b = MemberService.AddEntity(Member);
                if (b != null)
                {
                    return Content("ok");
                }
                else
                {
                    return Content("no");
                }
            }
            else
            {
                return Content("exit");
            }

        }
        //会员完善个人信息
        public ActionResult MemberCommit()
        {
            ViewBag.pmenu = ParentClassService.LoadEutities(c => c.Id > 0);
            ViewBag.cmenu = ChildClassService.LoadEutities(c => c.Id > 0);
            ViewBag.scmenu = schildclassService.LoadEutities(c => c.Id > 0);
            ViewBag.friend = FriendshipService.LoadEutities(c => c.Id > 0);
            int MemberId = int.Parse(Request["MemberId"]);
            var item = MemberService.LoadEutities(c => c.Id == MemberId).FirstOrDefault();
            ViewBag.MemberId = item.MemberId;
            ViewBag.EMail = item.EMail;
            ViewBag.Tell = item.Tell;
            string addr = item.Address;
            string sendaddr = item.Sendaddress;
            if (string.IsNullOrEmpty(addr))
            {
                ViewBag.quiz1 = "";
                ViewBag.quiz2 = "";
                ViewBag.quiz3 = "";
            }
            else
            {
                string[] address = addr.Split(',');
                ViewBag.quiz1 = address[0];
                ViewBag.quiz2 = address[1];
                ViewBag.quiz3 = address[2];
            }
            if (string.IsNullOrEmpty(sendaddr))
            {
                ViewBag.sender = "";
                ViewBag.quiz1_ = "";
                ViewBag.quiz2_ = "";
                ViewBag.quiz3_ = "";
                ViewBag.Street = "";
                ViewBag.code = "";
                ViewBag.cellphone = "";
            }
            else
            {
                string[] sendaddress = sendaddr.Split(',');
                ViewBag.sender = sendaddress[0];
                ViewBag.quiz1_ = sendaddress[1];
                ViewBag.quiz2_ = sendaddress[2];
                ViewBag.quiz3_ = sendaddress[3];
                ViewBag.Street = sendaddress[4];
                ViewBag.code = sendaddress[5];
                ViewBag.cellphone = sendaddress[6];
            }
            return View();
        }
        public ActionResult MemberCommitSave()
        {
            string img = Request["img"];
            string MemberId = Request["MemberId"];
            long Tell = long.Parse(Request["Tell"]);
            string EMail = Request["EMail"];
            string quiz1 = Request["quiz1"];
            string quiz2 = Request["quiz2"];
            string quiz3 = Request["quiz3"];
            string sender = Request["sender"];
            string quiz1_ = Request["quiz1_"];
            string quiz2_ = Request["quiz2_"];
            string quiz3_ = Request["quiz3_"];
            string Street = Request["Street"];
            string code = Request["code"];
            string cellphone = Request["cellphone"];
            var item = MemberService.LoadEutities(c => c.MemberId == MemberId).FirstOrDefault();
            if (item.Tell != Tell || item.EMail != EMail)
            {
                var temp = MemberService.LoadEutities(c => c.EMail == EMail || c.Tell == Tell).FirstOrDefault();
                if (temp == null)
                {
                    item.HeadIco = img;
                    item.EMail = EMail;
                    item.Tell = Tell;
                    item.Address = quiz1 + "," + quiz2 + "," + quiz3;
                    item.Sendaddress = sender + "," + quiz1_ + "," + quiz2_ + "," + quiz3_ + "," + Street + "," + code + "," + cellphone;
                    MemberService.EditEnity(item);
                }
            }
            else
            {
                item.HeadIco = img;
                item.Address = quiz1 + "," + quiz2 + "," + quiz3;
                item.Sendaddress = sender + "," + quiz1_ + "," + quiz2_ + "," + quiz3_ + "," + Street + "," + code + "," + cellphone;
                MemberService.EditEnity(item);
            }
            return Content("ok");

        }
        //会员登录
        public ActionResult MemberLogin()
        {
            string member = Request["member"];
            string MemberPwd = Common.ComString.GetMD5(Request["MemberPwd"]);
            Regex regex = new Regex(@"^(-)?\d+(\.\d+)?$");
            long member_ = 0;
            if (regex.IsMatch(member))
            {
                member_ = long.Parse(member);
            }
            var member2 = MemberService.LoadEutities(c => c.Tell == member_ && c.MemberPwd == MemberPwd).FirstOrDefault();
            var member1 = MemberService.LoadEutities(c => c.MemberId == member && c.MemberPwd == MemberPwd).FirstOrDefault();
            var member3 = MemberService.LoadEutities(c => c.EMail == member && c.MemberPwd == MemberPwd).FirstOrDefault();
            string msg = "";
            int MemberId = 0;
            if (member1 != null)
            {
                msg = "ok";
                MemberId = member1.Id;
            }
            if (member2 != null)
            {
                msg = "ok";
                MemberId = member2.Id;
            }
            if (member3 != null)
            {
                msg = "ok";
                MemberId = member3.Id;
            }
            if (member1 == null && member2 == null && member3 == null)
            {
                msg = "no";
            }
            return Json(new { msg = msg, MemberId = MemberId }, JsonRequestBehavior.AllowGet);
        }
        //忘记密码页面
        public ActionResult ForgetPwdView()
        {
            ViewBag.pmenu = ParentClassService.LoadEutities(c => c.Id > 0);
            ViewBag.cmenu = ChildClassService.LoadEutities(c => c.Id > 0);
            ViewBag.scmenu = schildclassService.LoadEutities(c => c.Id > 0);
            ViewBag.friend = FriendshipService.LoadEutities(c => c.Id > 0);
            return View();
        }
        //忘记密码修改
        public ActionResult ForgetPwdSave()
        {
            string member = Request["member"];
            string MemberPwd = Common.ComString.GetMD5(Request["MemberPwd"]);
            Regex regex = new Regex(@"^(-)?\d+(\.\d+)?$");
            long member_ = 0;
            if (regex.IsMatch(member))
            {
                member_ = long.Parse(member);
            }
            var member2 = MemberService.LoadEutities(c => c.Tell == member_ && c.MemberPwd == MemberPwd).FirstOrDefault();
            var member1 = MemberService.LoadEutities(c => c.MemberId == member && c.MemberPwd == MemberPwd).FirstOrDefault();
            var member3 = MemberService.LoadEutities(c => c.EMail == member && c.MemberPwd == MemberPwd).FirstOrDefault();
            string msg = "";
            if (member1 != null)
            {
                msg = "ok";
                member1.MemberPwd = MemberPwd;
                MemberService.EditEnity(member1);
            }
            if (member2 != null)
            {
                msg = "ok";
                member2.MemberPwd = MemberPwd;
                MemberService.EditEnity(member2);
            }
            if (member3 != null)
            {
                msg = "ok";
                member3.MemberPwd = MemberPwd;
                MemberService.EditEnity(member3);
            }
            if (member1 == null && member2 == null && member3 == null)
            {
                msg = "no";
            }
            return Json(new { msg = msg }, JsonRequestBehavior.AllowGet);
        }
        //分类详情页
        public ActionResult SortView()
        {
            ViewBag.pmenu = ParentClassService.LoadEutities(c => c.Id > 0);
            ViewBag.cmenu = ChildClassService.LoadEutities(c => c.Id > 0);
            ViewBag.scmenu = schildclassService.LoadEutities(c => c.Id > 0);
            ViewBag.friend = FriendshipService.LoadEutities(c => c.Id > 0);
            int ParentId = int.Parse(Request["ParentId"]);
            int ChildId = int.Parse(Request["ChildId"]);
            ChildClass child = ChildClassService.LoadEutities(c => c.Id == ParentId).FirstOrDefault();
            schildclass schild = schildclassService.LoadEutities(c => c.Id == ChildId).FirstOrDefault();
            ParentClass parent = ParentClassService.LoadEutities(c => c.Id == child.ParentId).FirstOrDefault();
            var booklist= BookService.LoadEutities(c => c.ParentId == ParentId && c.ChildId == ChildId);
            ViewBag.ParentId = ParentId;
            ViewBag.ChildId = ChildId;
            ViewBag.Class = parent.PName + "/" + child.CName + "/" + schild.SCName;
            ViewBag.count = booklist.Count();
            return View();
        }
        //获取加入购物车的书名和价格
        public ActionResult GetBook()
        {
            int Id = int.Parse(Request["Id"]);
            Book book = BookService.LoadEutities(c => c.Id == Id).FirstOrDefault();
            return Json(new { BookName = book.BookName, Price = book.NewPrice }, JsonRequestBehavior.AllowGet);
        }
        //分类详情页加载
        public ActionResult SortLoad()
        {
            int pageIndex = Request["pageIndex"] != null ? int.Parse(Request["pageIndex"]) : 1;
            int totalCount = 0;
            int ParentId = int.Parse(Request["ParentId"]);
            int ChildId = int.Parse(Request["ChildId"]);
            var temp = BookService.LoadPageEntities<DateTime?>(pageIndex, 8, out totalCount, c => c.ParentId == ParentId && c.ChildId == ChildId, c => c.Reserve1, false);
            int pages = Common.ComString.CloseoutInt(totalCount, 8);
            return Json(new { totalCount = pages, rows = temp }, JsonRequestBehavior.AllowGet);
        }
        //图书详情介绍
        public ActionResult DetailView()
        {
            ViewBag.pmenu = ParentClassService.LoadEutities(c => c.Id > 0);
            ViewBag.cmenu = ChildClassService.LoadEutities(c => c.Id > 0);
            ViewBag.scmenu = schildclassService.LoadEutities(c => c.Id > 0);
            ViewBag.friend = FriendshipService.LoadEutities(c => c.Id > 0);
            int Id = int.Parse(Request["Id"]);
            ViewBag.book = BookService.LoadEutities(c => c.Id == Id).FirstOrDefault();
            decimal newprice = ViewBag.book.NewPrice;
            decimal oldprice = ViewBag.book.OldPrice;
            decimal count = decimal.Round((newprice / oldprice) * 10, 1);
            ViewBag.count = count;
            return View();
        }
        //底部友情链接跳转页面
        public ActionResult FrindShip()
        {
            ViewBag.pmenu = ParentClassService.LoadEutities(c => c.Id > 0);
            ViewBag.cmenu = ChildClassService.LoadEutities(c => c.Id > 0);
            ViewBag.scmenu = schildclassService.LoadEutities(c => c.Id > 0);
            ViewBag.friend_ = FriendshipService.LoadEutities(c => c.Id > 0);
            int Id = int.Parse(Request["Id"]);
            ViewBag.Friend = FriendshipService.LoadEutities(c => c.Id == Id).FirstOrDefault();
            return View();
        }
        //加入购物车
        public ActionResult AddCart(Shopping_Cart Shopping_Cart)
        {
            int MemberId = Request["MemberId"] != null ? int.Parse(Request["MemberId"]) : 0;
            if (MemberId!=0)
            {
                Shopping_Cart.MemberId = MemberId;
                string BookName = Request["BookName"];
                decimal Price = decimal.Parse(Request["Price"]);
                int Ammount = int.Parse(Request["Ammount"]);
                Shopping_Cart.BookName = BookName;
                Shopping_Cart.Price = Price;
                Shopping_Cart.Ammount = Ammount;
                Shopping_CartService.AddEntity(Shopping_Cart);
                return Content("ok");
            }
            else
            {
                return Content("no");
            }

        }
        //购物车页面
        public ActionResult CartView()
        {
            int MemberId = Request["MemberId"] != null ? int.Parse(Request["MemberId"]) : 0;
            ViewBag.pmenu = ParentClassService.LoadEutities(c => c.Id > 0);
            ViewBag.cmenu = ChildClassService.LoadEutities(c => c.Id > 0);
            ViewBag.scmenu = schildclassService.LoadEutities(c => c.Id > 0);
            ViewBag.friend = FriendshipService.LoadEutities(c => c.Id > 0);
            ViewBag.MemberId = MemberId;
            if (MemberId!=0)
            {
                ViewBag.carts= Shopping_CartService.LoadEutities(c => c.MemberId == MemberId);
                decimal totalprice = 0;
                int totalcount = 0;
                foreach (var item in ViewBag.carts)
                {
                    totalprice += item.Price * item.Ammount;
                    totalcount++;
                }
                ViewBag.totalprice = totalprice;
                ViewBag.totalcount = totalcount;
            }
            else
            {
                ViewBag.totalprice = "---";
                ViewBag.totalcount = "---";
            }

            return View();
        }
        //购物车变更
        public ActionResult EditCart()
        {
            int Id = int.Parse(Request["Id"]);
            Shopping_Cart cart= Shopping_CartService.LoadEutities(c => c.Id == Id).FirstOrDefault();
            int Ammount = int.Parse(Request["Ammount"]);
            cart.Ammount = Ammount;
            Shopping_CartService.EditEnity(cart);
            return Content("ok");
        }
        //购物车删除商品
        public ActionResult DeleteCart()
        {
            int Id = int.Parse(Request["Id"]);
            Shopping_Cart cart = Shopping_CartService.LoadEutities(c => c.Id == Id).FirstOrDefault();
            Shopping_CartService.DeleteEntity(cart);
            return Content("ok");
        }
        //订单支付页面
        public ActionResult Orderview()
        {
            ViewBag.pmenu = ParentClassService.LoadEutities(c => c.Id > 0);
            ViewBag.cmenu = ChildClassService.LoadEutities(c => c.Id > 0);
            ViewBag.scmenu = schildclassService.LoadEutities(c => c.Id > 0);
            ViewBag.friend = FriendshipService.LoadEutities(c => c.Id > 0);
            int MemberId = Request["MemberId"] != null ? int.Parse(Request["MemberId"]) : 0;
            ViewBag.cartlist= Shopping_CartService.LoadEutities(c => c.MemberId == MemberId);
            Member member= MemberService.LoadEutities(c => c.Id == MemberId).FirstOrDefault();
            if (string.IsNullOrEmpty(member.Sendaddress))
            {
                ViewBag.sendaddress = "";
            }
            else
            {
                ViewBag.sendaddress = member.Sendaddress;
            }
            ViewBag.ordertime = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.ordercode = DateTime.Now.ToString("yyyyMMddHHmmss") + MemberId;
            decimal totalprice = 0;
            int totalcount = 0;
            foreach (var item in ViewBag.cartlist)
            {
                totalprice += item.Price * item.Ammount;
                totalcount++;
            }
            ViewBag.totalprice = totalprice;
            ViewBag.totalcount = totalcount;
            return View();
        }
        //判断购物车是否有商品
        public ActionResult CheckCart()
        {
            int MemberId = Request["MemberId"] != null ? int.Parse(Request["MemberId"]) : 0;
            var cartlist = Shopping_CartService.LoadEutities(c => c.MemberId == MemberId);
            if (cartlist.Count()>0)
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        //保存订单测试
        public ActionResult SaveOrder(Orders Orders)
        {
            int MemberId = Request["MemberId"] != null ? int.Parse(Request["MemberId"]) : 0;
            string OrderNum = Request["OrderNum"];
            string SendAdress = Request["SendAdress"];
            DateTime Createtime =DateTime.Parse( Request["Createtime"]);
            var cartlist = Shopping_CartService.LoadEutities(c => c.MemberId == MemberId);
            if (cartlist.Count() > 0)
            {
                decimal totalprice = 0;
                string goods = "";
                List<Shopping_Cart> cart = new List<Shopping_Cart>();
                foreach (var item in cartlist)
                {
                    totalprice += (decimal)item.Price * (decimal)item.Ammount;
                    goods += item.BookName + "*" + item.Ammount+"|";
                    cart.Add(item);
                }
                Orders isexit = OrdersService.LoadEutities(c => c.MemberId == MemberId && c.OrderNum == OrderNum).FirstOrDefault();
                if (isexit == null)
                {
                    Orders.OrderNum = OrderNum;
                    Orders.SendAdress = SendAdress;
                    Orders.Createtime = Createtime;
                    Orders.Goods = goods;
                    Orders.Totalprice = totalprice;
                    Orders.IsDilivery = false;
                    Orders.MemberId = MemberId;
                    Orders.Stat = 1;
                    Orders a = OrdersService.AddEntity(Orders);
                }
                //清空购物车
                Shopping_CartService.DeleteEntites(cart);
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
           
        }
        //获取支付订单参数
        public ActionResult GetOrderParam()
        {
            int MemberId = Request["MemberId"] != null ? int.Parse(Request["MemberId"]) : 0;
            string OrderNum = Request["OrderNum"];
            Orders order = OrdersService.LoadEutities(c => c.MemberId == MemberId && c.Stat == 1 && c.OrderNum == OrderNum).FirstOrDefault();
            string partner = "yang";
            string return_url = "http://localhost:4592/Home/OrderInfo?memberid=" + MemberId;
            string subject = order.Goods;
            string body = "图书";
            string out_trade_no = order.OrderNum;
            string total_fee = order.Totalprice.ToString();
            string seller_email = "youngeyes@yeah.net";
            string sign = Common.ComString.GetMD5(total_fee + partner + out_trade_no + subject + "123");
            StringBuilder sb = new StringBuilder();
            sb.Append("partner=" + partner);
            sb.Append("&return_url=" + return_url);
            sb.Append("&subject=" + subject);
            sb.Append("&body=" + body);
            sb.Append("&out_trade_no=" + out_trade_no);
            sb.Append("&total_fee=" + total_fee);
            sb.Append("&seller_email=" + seller_email);
            sb.Append("&sign=" + sign);
            return Json(new { msg = "ok", param = sb.ToString() }, JsonRequestBehavior.AllowGet);
        }

        //支付回掉订单信息页面
        public ActionResult OrderInfo()
        {
            ViewBag.pmenu = ParentClassService.LoadEutities(c => c.Id > 0);
            ViewBag.cmenu = ChildClassService.LoadEutities(c => c.Id > 0);
            ViewBag.scmenu = schildclassService.LoadEutities(c => c.Id > 0);
            ViewBag.friend = FriendshipService.LoadEutities(c => c.Id > 0);
            int MemberId = Request["MemberId"] != null ? int.Parse(Request["MemberId"]) : 0;
            string returncode = Request["returncode"];//支付成功后回调参数
            if (MemberId!=0)
            {
                if (returncode == "ok")
                {
                    string out_trade_no = Request["out_trade_no"];//支付成功后回调订单号
                    Orders order = OrdersService.LoadEutities(c => c.MemberId == MemberId && c.OrderNum == out_trade_no).FirstOrDefault();
                    order.Stat = 2;
                    OrdersService.EditEnity(order);
                    ViewBag.orderlist = OrdersService.LoadEutities(c => c.MemberId == MemberId && c.OrderNum == out_trade_no);
                }
                else
                {
                    ViewBag.orderlist = OrdersService.LoadEutities(c => c.MemberId == MemberId);
                }
            }
            return View();
        }
        //订单留言页面
        public ActionResult Messageview()
        {
            ViewBag.pmenu = ParentClassService.LoadEutities(c => c.Id > 0);
            ViewBag.cmenu = ChildClassService.LoadEutities(c => c.Id > 0);
            ViewBag.scmenu = schildclassService.LoadEutities(c => c.Id > 0);
            ViewBag.friend = FriendshipService.LoadEutities(c => c.Id > 0);
            int MemberId = Request["MemberId"] != null ? int.Parse(Request["MemberId"]) : 0;
            string OrderNum = Request["OrderNum"];
            Orders order= OrdersService.LoadEutities(c => c.MemberId == MemberId && c.OrderNum == OrderNum).FirstOrDefault();
            ViewBag.orderlist=order;
            ViewBag.member = order.Member.MemberId;
            return View();
        }
        //保存留言
        public ActionResult MessageSave(Message Message)
        {
            string MemberId = Request["MemberId"];
            string OrderNum = Request["OrderNum"];
            string BuyerMsg = Request["BuyerMsg"];
            Message.OrderNum = OrderNum;
            Message.BuyerMsg = BuyerMsg;
            Message.MemberId = MemberId;
            Message.Reply = false;
            MessageService.AddEntity(Message);
            Orders order= OrdersService.LoadEutities(c => c.OrderNum == OrderNum).FirstOrDefault();
            order.Stat = 3;
            OrdersService.EditEnity(order);
            return Content("ok");
        }

        public ActionResult SearchView()
        {
            ViewBag.pmenu = ParentClassService.LoadEutities(c => c.Id > 0);
            ViewBag.cmenu = ChildClassService.LoadEutities(c => c.Id > 0);
            ViewBag.scmenu = schildclassService.LoadEutities(c => c.Id > 0);
            ViewBag.friend = FriendshipService.LoadEutities(c => c.Id > 0);
            string SearchParam = Request["SearchParam"];
            ViewBag.SearchParam = SearchParam;
            return View();
        }
        public ActionResult LoadSearch()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 100;
            int totalCount = 0;
            string SearchParam = Request["SearchParam"];
            BookParam BookParam = new BookParam()
            {
                pageIndex=pageIndex,
                pageSize=pageSize,
                totalCount=totalCount,
                SearchParam=SearchParam,
            };
            int pages = Common.ComString.CloseoutInt(BookParam.totalCount, 8);
            var searchlist = BookService.LoadSearch(BookParam);
            return Json(new { msg = "ok", totalCount = pages, rows = searchlist }, JsonRequestBehavior.AllowGet);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JD.BookOA.Model;
using JD.BookOA.Model.SearchParam;

namespace JD.BookOA.WebApp.Controllers
{
    public class AdminController : BaseController
    {
        //
        // GET: /Admin/
        IBLL.IUserInfoService UserInfoService { get; set; }
        IBLL.IMemberService MemberService { get; set; }
        IBLL.IBookService BookService { get; set; }
        IBLL.IChildClassService ChildClassService { get; set; }
        IBLL.IschildclassService schildclassService { get; set; }
        IBLL.IParentClassService ParentClassService { get; set; }
        IBLL.IFriendshipService FriendshipService { get; set; }
        IBLL.IOrdersService OrdersService { get; set; }
        IBLL.IMessageService MessageService { get; set; }
        IBLL.ICarouselImgService CarouselImgService { get; set; }
        #region 后台布局
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult left()
        {
            return View();
        }
        public ActionResult Top()
        {
            var temp = OrdersService.LoadEutities(c => c.Id > 0);
            ViewBag.ssid = temp.Count();
            ViewBag.inform = temp.Count();
            return View();
        }//Top
        public ActionResult Countdown()
        {
            int ssid = int.Parse(Request["ssid"]);
            var temp = OrdersService.LoadEutities(c => c.Id > 0);
            return Json(new { ssid = ssid, inform = temp.Count() }, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region 管理员管理
        public ActionResult Administrators()
        {
            return View();
        }
        //加载，搜索管理员信息
        public ActionResult LoadUserInfo()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 100;
            string UserId = Request["UserId"];
            string Createtime1 = Request["Createtime1"];
            string Createtime2 = Request["Createtime2"];
            int totalCount = 0;
            UserInfoParam UserInfoParam = new UserInfoParam()
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                UserId = UserId,
                Createtime1 = Createtime1,
                Createtime2 = Createtime2,
                totalCount = totalCount,
            };
            var UserInfolist = UserInfoService.LoadSearchEntities(UserInfoParam);
            var temp = from u in UserInfolist
                       select new
                       {
                           Id = u.Id,
                           UserId = u.UserId,
                           Createtime = u.Createtime,
                       };
            return Json(new { rows = temp, total = UserInfoParam.totalCount, msg = "ok" }, JsonRequestBehavior.AllowGet);
        }
        //批量删除管理员
        public ActionResult DeleteUserInfo()
        {
            string strid = Request["strid"];
            string[] strids = strid.Split(',');
            List<UserInfo> list = new List<UserInfo>();
            foreach (string id in strids)
            {
                int Id = int.Parse(id);
                UserInfo UserInfo = UserInfoService.LoadEutities(c => c.Id == Id).FirstOrDefault();
                list.Add(UserInfo);
            }
            if (UserInfoService.DeleteEntites(list))
            {
                return Content("yes");
            }
            else
            {
                return Content("no");
            }
        }
        //添加管理员
        public ActionResult AddUserInfo(UserInfo UserInfo)
        {
            string UserId = Request["UserId"];
            string UserPwd = Request["UserPwd"];
            var list = UserInfoService.LoadEutities(c => c.UserId == UserId);
            if (list.Count() != 0)
            {
                return Content("该账号已存在");
            }
            UserInfo.UserId = UserId;
            UserInfo.UserPwd = Common.ComString.GetMD5(UserPwd);
            UserInfo.Createtime = DateTime.Now;
            UserInfoService.AddEntity(UserInfo);
            return Content("ok");
        }
        public ActionResult EditUserInfoLoad()
        {
            int id = int.Parse(Request["id"]);
            UserInfo UserInfo = UserInfoService.LoadEutities(c => c.Id == id).FirstOrDefault();
            return Json(new { msg = "ok", sdata = UserInfo }, JsonRequestBehavior.AllowGet);
        }
        //编辑管理员
        public ActionResult EditUserInfo()
        {
            string UserId = Request["UserId"];
            string UserPwd = Request["UserPwd"];
            UserInfo LoadUserInfo = UserInfoService.LoadEutities(c => c.UserId == UserId).FirstOrDefault();
            if (!(string.IsNullOrEmpty(UserPwd)))
            {
                LoadUserInfo.UserPwd = Common.ComString.GetMD5(UserPwd);
            }
            UserInfoService.EditEnity(LoadUserInfo);
            return Content("ok");
        }
        #endregion

        #region 会员信息
        public ActionResult Member()
        {
            return View();
        }
        public ActionResult LoadMember()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 100;
            string MemberId = Request["MemberId"];
            string EMail = Request["EMail"];
            string Tell = Request["Tell"];
            string Sex = Request["Sex"];
            string Registertime1 = Request["Registertime1"];
            string Registertime2 = Request["Registertime2"];
            int totalCount = 0;
            MemberParam MemberParam = new MemberParam()
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                totalCount = totalCount,
                MemberId = MemberId,
                EMail = EMail,
                Tell = Tell,
                Sex = Sex,
                Registertime1 = Registertime1,
                Registertime2 = Registertime2,
            };
            var Memberlist = MemberService.LoadSearchEntities(MemberParam);
            var temp = from u in Memberlist
                       select new
                       {
                           Id = u.Id,
                           MemberId = u.MemberId,
                           EMail = u.EMail,
                           Tell = u.Tell,
                           Sex = u.Sex,
                           Registertime = u.Registertime,
                       };
            return Json(new { rows = temp, total = MemberParam.totalCount, msg = "ok" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 订单信息管理
        public ActionResult OrdersView()
        {
            return View();
        }
        public ActionResult LoadOrders()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 100;
            int totalCount = 0;
            string OrderNum = Request["OrderNum"];
            string Stat = Request["Stat"];
            string Createtime1 = Request["Createtime1"];
            string Createtime2 = Request["Createtime2"];
            string IsDilivery = Request["IsDilivery"];
            OrdersParam OrdersParam = new OrdersParam()
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                totalCount = totalCount,
                OrderNum = OrderNum,
                Stat = Stat,
                Createtime1 = Createtime1,
                Createtime2 = Createtime2,
                IsDilivery = IsDilivery,
            };
            var Orderslist = OrdersService.LoadSearchEntities(OrdersParam);
            var temp = from u in Orderslist
                       select new
                       {
                           Id = u.Id,
                           OrderNum = u.OrderNum,
                           SendAdress = u.SendAdress,
                           Totalprice = u.Totalprice,
                           Goods = u.Goods,
                           Stat = u.Stat,
                           Createtime = u.Createtime,
                           IsDilivery = u.IsDilivery,
                           MemberId = u.Member.MemberId,
                       };
            return Json(new { rows = temp, total = OrdersParam.totalCount, msg = "ok" }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult DeleteOrders()
        {
            string strid = Request["strid"];
            string[] strids = strid.Split(',');
            List<Orders> list = new List<Orders>();
            foreach (string id in strids)
            {
                int Id = int.Parse(id);
                Orders Orders = OrdersService.LoadEutities(c => c.Id == Id).FirstOrDefault();
                list.Add(Orders);
            }
            if (OrdersService.DeleteEntites(list))
            {
                return Content("yes");
            }
            else
            {
                return Content("no");
            }
        }
        //订单派送
        public ActionResult SendOrdersLoad()
        {
            int Id = int.Parse(Request["Id"]);
            Orders orders = OrdersService.LoadEutities(c => c.Id == Id).FirstOrDefault();
            string Goods = orders.Goods;
            string msg = "";
            if (orders.IsDilivery == false)
            {
                orders.IsDilivery = true;
                OrdersService.EditEnity(orders);
                //派送时图书库存改变
                string[] Goodsarray = Goods.Split('|');
                for (int i = 0; i < Goodsarray.Length - 1; i++)
                {
                    string[] strlist = Goodsarray[i].Split('*');
                    string bookname = strlist[0];
                    Book book = BookService.LoadEutities(c => c.BookName == bookname).FirstOrDefault();
                    book.Stock = book.Stock - int.Parse(strlist[1]);
                    BookService.EditEnity(book);

                }
                msg = "ok";
            }
            else
            {
                msg = "no";
            }

            return Json(new { msg = msg }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 图书信息
        public ActionResult BookView()
        {
            ViewBag.menu = ChildClassService.LoadEutities(c => c.Id > 0);
            return View();
        }
        public ActionResult LoadBook()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 100;
            string BookName = Request["BookName"];
            string Author = Request["Author"];
            string Press = Request["Press"];
            string Presstime1 = Request["Presstime1"];
            string Presstime2 = Request["Presstime2"];
            string ISBN = Request["ISBN"];
            string NewPrice = Request["NewPrice"];
            string ParentId = Request["ParentId"];
            string ChildId = Request["ChildId"];
            string Stock = Request["Stock"];
            string Reserve11 = Request["Reserve11"];
            string Reserve12 = Request["Reserve12"];
            int totalCount = 0;
            BookParam BookParam = new BookParam()
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                totalCount = totalCount,
                BookName = BookName,
                Author = Author,
                Press = Press,
                Presstime1 = Presstime1,
                Presstime2 = Presstime2,
                ISBN = ISBN,
                NewPrice = NewPrice,
                ParentId = ParentId,
                ChildId = ChildId,
                Stock = Stock,
                Reserve11 = Reserve11,
                Reserve12 = Reserve12,
            };
            var booklist = BookService.LoadSearchEntities(BookParam);
            var temp = from u in booklist
                       select new
                       {
                           Id = u.Id,
                           BookName = u.BookName,
                           Author = u.Author,
                           Press = u.Press,
                           Presstime = u.Presstime,
                           ISBN = u.ISBN,
                           NewPrice = u.NewPrice,
                           ParentId = u.ParentId,
                           ChildId = u.ChildId,
                           Stock = u.Stock,
                           Reserve1 = u.Reserve1,
                       };
            return Json(new { rows = temp, total = BookParam.totalCount, msg = "ok" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditBookView()
        {
            string action = Request["action"];
            int Id = Request["Id"] != null ? int.Parse(Request["Id"]) : 0;
            ViewBag.action = action;
            ViewBag.Id = Id;
            ViewBag.menu = ChildClassService.LoadEutities(c => c.Id > 0);
            if (action == "edit")
            {
                Book Book = BookService.LoadEutities(c => c.Id == Id).FirstOrDefault();
                ViewBag.BookName = Book.BookName;
                ViewBag.Author = Book.Author;
                ViewBag.Press = Book.Press;
                ViewBag.Presstime = Book.Presstime;
                ViewBag.ISBN = Book.ISBN;
                ViewBag.Smallpic = Book.Smallpic;
                ViewBag.Bigpic = Book.Bigpic;
                ViewBag.OldPrice = Book.OldPrice;
                ViewBag.NewPrice = Book.NewPrice;
                ViewBag.Introduce = Book.Introduce;
                ViewBag.Detail = Book.Detail;
                ViewBag.Stock = Book.Stock;
                ViewBag.ParentId = Book.ParentId;
                ViewBag.ChildId = Book.ChildId;
            }
            else
            {
                ViewBag.BookName = "";
                ViewBag.Author = "";
                ViewBag.Press = "";
                ViewBag.Presstime = "";
                ViewBag.ISBN = "";
                ViewBag.Smallpic = "";
                ViewBag.Bigpic = "";
                ViewBag.OldPrice = "";
                ViewBag.NewPrice = "";
                ViewBag.Introduce = "";
                ViewBag.Detail = "";
                ViewBag.Stock = "";
                ViewBag.ParentId = 0;
                ViewBag.ChildId = 0;
            }
            return View();
        }
        public ActionResult EditBookSave(Book book)
        {
            string BookName = Request["BookName"];
            string Author = Request["Author"];
            string Press = Request["Press"];
            string Presstime = Request["Presstime"];
            DateTime Presstime_ = DateTime.Parse(Presstime);
            string ISBN = Request["ISBN"];
            string Smallpic = Request["Smallpic"];
            string Bigpic = Request["Bigpic"];
            decimal OldPrice = decimal.Parse(Request["OldPrice"]);
            decimal NewPrice = decimal.Parse(Request["NewPrice"]);
            string Introduce = Request["Introduce"];
            string Detail = Request["Detail"];
            int Stock = int.Parse(Request["Stock"]);
            int ParentId = int.Parse(Request["ParentId"]);
            int ChildId = int.Parse(Request["ChildId"]);
            string action = Request["action"];
            book.BookName = BookName;
            book.Author = Author;
            book.Press = Press;
            book.Presstime = Presstime_;
            book.ISBN = ISBN;
            book.Smallpic = Smallpic;
            book.Bigpic = Bigpic;
            book.OldPrice = OldPrice;
            book.NewPrice = NewPrice;
            book.Introduce = Introduce;
            book.Detail = Detail;
            book.Stock = Stock;
            book.ParentId = ParentId;
            book.ChildId = ChildId;
            if (action == "edit")
            {
                int Id = int.Parse(Request["Id"]);
                Book b = BookService.LoadEutities(c => c.Id == Id).FirstOrDefault();
                b.BookName = BookName;
                b.Author = Author;
                b.Press = Press;
                b.Presstime = Presstime_;
                b.ISBN = ISBN;
                b.Smallpic = Smallpic;
                b.Bigpic = Bigpic;
                b.OldPrice = OldPrice;
                b.NewPrice = NewPrice;
                b.Introduce = Introduce;
                b.Detail = Detail;
                b.Stock = Stock;
                b.ParentId = ParentId;
                b.ChildId = ChildId;
                bool a = BookService.EditEnity(b);
                if (a)
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
                book.Reserve1 = DateTime.Now;
                book.Discuss = 0;
                Book a = BookService.AddEntity(book);
                if (a != null)
                {
                    return Content("ok");
                }
                else
                {
                    return Content("no");
                }
            }

        }
        public ActionResult ChangeMenu()
        {
            string ParentId = Request["ParentId"];
            int ParentId_ = int.Parse(ParentId);
            var temp = schildclassService.LoadEutities(c => c.Id > 0 && c.ChildId == ParentId_);
            return Json(new { msg = "ok", rows = temp }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteBook()
        {
            string strid = Request["strid"];
            string[] strids = strid.Split(',');
            List<Book> list = new List<Book>();
            foreach (string id in strids)
            {
                int Id = int.Parse(id);
                Book Book = BookService.LoadEutities(c => c.Id == Id).FirstOrDefault();
                list.Add(Book);
            }
            if (BookService.DeleteEntites(list))
            {
                return Content("yes");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion

        #region 导航菜单管理
        public ActionResult Menunav()
        {
            return View();
        }
        public ActionResult LoadMenunav()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 100;
            string PName = Request["PName"];
            int totalCount = 0;
            ParentClassParam ParentClassParam = new ParentClassParam()
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                PName = PName,
                totalCount = totalCount,
            };
            var Parentlist = ParentClassService.LoadSearchEntities(ParentClassParam);
            var temp = from u in Parentlist
                       select new
                       {
                           Id = u.Id,
                           PName = u.PName,

                       };
            return Json(new { rows = temp, total = ParentClassParam.totalCount, msg = "ok" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditMenunavLoad()
        {
            int id = int.Parse(Request["id"]);
            ParentClass ParentClass = ParentClassService.LoadEutities(c => c.Id == id).FirstOrDefault();
            return Json(new { msg = "ok", sdata = ParentClass }, JsonRequestBehavior.AllowGet);
        }
        //编辑管理员
        public ActionResult EditMenunav()
        {
            int Id = int.Parse(Request["Id"]);
            string PName = Request["PName"];
            ParentClass ParentClass = ParentClassService.LoadEutities(c => c.Id == Id).FirstOrDefault();
            ParentClass.PName = PName;
            ParentClassService.EditEnity(ParentClass);
            return Content("ok");
        }
        #endregion

        #region 图书父菜单管理
        public ActionResult ChildClass()
        {
            ViewBag.Parent = ParentClassService.LoadEutities(c => c.Id > 0);
            return View();
        }
        public ActionResult LoadChildClass()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 100;
            string CName = Request["CName"];
            string ParentId = Request["ParentId"];
            int totalCount = 0;
            ChildClassParam ChildClassParam = new ChildClassParam()
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                CName = CName,
                ParentId = ParentId,
                totalCount = totalCount,
            };
            var Childlist = ChildClassService.LoadSearchEntities(ChildClassParam);
            var temp = from u in Childlist
                       select new
                       {
                           Id = u.Id,
                           CName = u.CName,
                       };
            return Json(new { rows = temp, total = ChildClassParam.totalCount, msg = "ok" }, JsonRequestBehavior.AllowGet);
        }
        //批量删除
        public ActionResult DeleteChildClass()
        {
            string strid = Request["strid"];
            string[] strids = strid.Split(',');
            List<ChildClass> list = new List<ChildClass>();
            foreach (string id in strids)
            {
                int Id = int.Parse(id);
                ChildClass ChildClass = ChildClassService.LoadEutities(c => c.Id == Id).FirstOrDefault();
                list.Add(ChildClass);
            }
            if (ChildClassService.DeleteEntites(list))
            {
                return Content("yes");
            }
            else
            {
                return Content("no");
            }
        }
        public ActionResult AddChildClass(ChildClass ChildClass)
        {
            string CName = Request["CName"];
            int ParentId = int.Parse(Request["ParentId"]);
            var list = ChildClassService.LoadEutities(c => c.CName == CName);
            if (list.Count() != 0)
            {
                return Content("该菜单已存在");
            }
            ChildClass.CName = CName;
            ChildClass.ParentId = ParentId;
            ChildClassService.AddEntity(ChildClass);
            return Content("ok");
        }
        public ActionResult EditChildClassLoad()
        {
            int Id = int.Parse(Request["Id"]);
            ChildClass ChildClass = ChildClassService.LoadEutities(c => c.Id == Id).FirstOrDefault();
            var temp = ParentClassService.LoadEutities(c => c.Id > 0);
            return Json(new { msg = "ok", sdata = ChildClass, rows = temp }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditChildClass()
        {
            int Id = int.Parse(Request["Id"]);
            string CName = Request["CName"];
            int ParentId = int.Parse(Request["ParentId"]);
            ChildClass ChildClass = ChildClassService.LoadEutities(c => c.Id == Id).FirstOrDefault();
            ChildClass.CName = CName;
            ChildClass.ParentId = ParentId;
            ChildClassService.EditEnity(ChildClass);
            return Content("ok");
        }
        #endregion

        #region 图书子菜单管理
        public ActionResult schildclass()
        {
            ViewBag.schildclass = ChildClassService.LoadEutities(c => c.Id > 0);
            return View();
        }
        public ActionResult Loadschildclass()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 100;
            string SCName = Request["SCName"];
            string ChildId = Request["ChildId"];
            int totalCount = 0;
            schildclassParam schildclassParam = new schildclassParam()
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                SCName = SCName,
                ChildId = ChildId,
                totalCount = totalCount,
            };
            var schildclasslist = schildclassService.LoadSearchEntities(schildclassParam);
            var temp = from u in schildclasslist
                       select new
                       {
                           Id = u.Id,
                           SCName = u.SCName,
                       };
            return Json(new { rows = temp, total = schildclassParam.totalCount, msg = "ok" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Deleteschildclass()
        {
            string strid = Request["strid"];
            string[] strids = strid.Split(',');
            List<schildclass> list = new List<schildclass>();
            foreach (string id in strids)
            {
                int Id = int.Parse(id);
                schildclass schildclass = schildclassService.LoadEutities(c => c.Id == Id).FirstOrDefault();
                list.Add(schildclass);
            }
            if (schildclassService.DeleteEntites(list))
            {
                return Content("yes");
            }
            else
            {
                return Content("no");
            }
        }
        public ActionResult Addschildclass(schildclass schildclass)
        {
            string SCName = Request["SCName"];
            int ChildId = int.Parse(Request["ChildId"]);
            var list = schildclassService.LoadEutities(c => c.SCName == SCName);
            if (list.Count() != 0)
            {
                return Content("该菜单已存在");
            }
            schildclass.SCName = SCName;
            schildclass.ChildId = ChildId;
            schildclassService.AddEntity(schildclass);
            return Content("ok");
        }
        public ActionResult EditschildclassLoad()
        {
            int Id = int.Parse(Request["Id"]);
            schildclass schildclass = schildclassService.LoadEutities(c => c.Id == Id).FirstOrDefault();
            var temp = ChildClassService.LoadEutities(c => c.Id > 0);
            return Json(new { msg = "ok", sdata = schildclass, rows = temp }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Editschildclass()
        {
            int Id = int.Parse(Request["Id"]);
            string SCName = Request["SCName"];
            int ChildId = int.Parse(Request["ChildId"]);
            schildclass schildclass = schildclassService.LoadEutities(c => c.Id == Id).FirstOrDefault();
            schildclass.SCName = SCName;
            schildclass.ChildId = ChildId;
            schildclassService.EditEnity(schildclass);
            return Content("ok");
        }
        #endregion

        #region 友情链接
        public ActionResult Friendship()
        {
            return View();
        }
        public ActionResult LoadFriendship()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 100;
            string FriendshipMsg = Request["FriendshipMsg"];
            string FriendshipClass = Request["FriendshipClass"];
            int totalCount = 0;
            FriendshipParam FriendshipParam = new FriendshipParam()
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                FriendshipMsg = FriendshipMsg,
                FriendshipClass = FriendshipClass,
                totalCount = totalCount,
            };
            var Friendshiplist = FriendshipService.LoadSearchEntities(FriendshipParam);
            var temp = from u in Friendshiplist
                       select new
                       {
                           Id = u.Id,
                           FriendshipMsg = u.FriendshipMsg,
                           FriendshipClass = u.FriendshipClass,
                           FriendshipUrl = u.FriendshipUrl,
                       };
            return Json(new { rows = temp, total = FriendshipParam.totalCount, msg = "ok" }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult DeleteFriendship()
        {
            string strid = Request["strid"];
            string[] strids = strid.Split(',');
            List<Friendship> list = new List<Friendship>();
            foreach (string id in strids)
            {
                int Id = int.Parse(id);
                Friendship Friendship = FriendshipService.LoadEutities(c => c.Id == Id).FirstOrDefault();
                list.Add(Friendship);
            }
            if (FriendshipService.DeleteEntites(list))
            {
                return Content("yes");
            }
            else
            {
                return Content("no");
            }
        }
        public ActionResult EditFriendshipLoad()
        {
            int Id = Request["Id"] != null ? int.Parse(Request["Id"]) : 0;
            string action = Request["action"];
            if (action == "edit")
            {
                Friendship Friendship = FriendshipService.LoadEutities(c => c.Id == Id).FirstOrDefault();
                ViewBag.Id = Id;
                ViewBag.action = action;
                ViewBag.FriendshipMsg = Friendship.FriendshipMsg;
                ViewBag.FriendshipClass = Friendship.FriendshipClass;
                ViewBag.FriendshipUrl = Friendship.FriendshipUrl;
                string detail = "";
                if (string.IsNullOrEmpty(Friendship.FriendshipDetail))
                {
                    detail = "";
                }
                else
                {
                    detail = Friendship.FriendshipDetail;
                }
                ViewBag.FriendshipDetail = detail;
                ViewBag.IsDIY = Friendship.IsDIY;
            }
            else
            {
                ViewBag.Id = 0;
                ViewBag.action = action;
                ViewBag.FriendshipMsg = "";
                ViewBag.FriendshipUrl = "";
                ViewBag.FriendshipDetail = "";
                ViewBag.IsDIY = 0;
            }
            return View();
        }
        public ActionResult EditFriendship(Friendship Friendship)
        {
            string action = Request["action"];
            string FriendshipMsg = Request["FriendshipMsg"];
            string FriendshipUrl = Request["FriendshipUrl"];
            string FriendshipDetail = Request["FriendshipDetail"];
            int FriendshipClass = int.Parse(Request["FriendshipClass"]);
            Friendship.FriendshipMsg = FriendshipMsg;
            Friendship.FriendshipUrl = FriendshipUrl;
            Friendship.FriendshipDetail = FriendshipDetail;
            if (action == "edit")
            {
                int Id = int.Parse(Request["Id"]);
                Friendship f = FriendshipService.LoadEutities(c => c.Id == Id).FirstOrDefault();
                f.FriendshipMsg = FriendshipMsg;
                f.FriendshipDetail = FriendshipDetail;
                f.FriendshipClass = FriendshipClass;
                f.FriendshipUrl = FriendshipUrl;
                if (string.IsNullOrEmpty(FriendshipDetail))
                {
                    f.IsDIY = 0;
                }
                else
                {
                    f.IsDIY = 1;
                }
                bool b = FriendshipService.EditEnity(f);
                if (b)
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
                if (string.IsNullOrEmpty(FriendshipDetail))
                {
                    Friendship.IsDIY = 0;
                }
                else
                {
                    Friendship.IsDIY = 1;
                }
                Friendship b = FriendshipService.AddEntity(Friendship);
                if (b != null)
                {
                    return Content("ok");
                }
                else
                {
                    return Content("no");
                }
            }
        }
        #endregion

        #region 留言管理
        public ActionResult MessageView()
        {
            return View();
        }
        public ActionResult LoadMessage()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 100;
            int totalCount = 0;
            string OrderNum = Request["OrderNum"];
            string MemberId = Request["MemberId"];
            string Reply = Request["Reply"];
            MessageParam MessageParam = new MessageParam()
            {
                pageIndex=pageIndex,
                pageSize=pageSize,
                totalCount=totalCount,
                OrderNum=OrderNum,
                MemberId=MemberId,
                Reply=Reply,
            };
            var messagelist = MessageService.LoadSearchEntities(MessageParam);
            var temp = from u in messagelist
                       select new
                       {
                           Id=u.Id,
                           OrderNum=u.OrderNum,
                           BuyerMsg=u.BuyerMsg,
                           SellerMsg=u.SellerMsg,
                           MemberId=u.MemberId,
                           Reply=u.Reply,
                       };
            return Json(new { rows = temp, total = MessageParam.totalCount, msg = "ok" }, JsonRequestBehavior.AllowGet);
        }
        //留言回复页面
        public ActionResult RepalyView()
        {
            int Id = int.Parse(Request["Id"]);
            Message message= MessageService.LoadEutities(c => c.Id == Id).FirstOrDefault();
            ViewBag.Id = Id;
            ViewBag.BuyerMsg = message.BuyerMsg;
            ViewBag.OrderNum = message.OrderNum;
            ViewBag.MemberId = message.MemberId;
            return View();
        }
        public ActionResult RepalySave()
        {
            int Id = int.Parse(Request["Id"]);
            string SellerMsg = Request["SellerMsg"];
            Message message= MessageService.LoadEutities(c => c.Id == Id).FirstOrDefault();
            message.SellerMsg = SellerMsg;
            message.Reply = true;
            MessageService.EditEnity(message);
            return Content("ok");
        }
        #endregion

        #region 轮播图管理
        public ActionResult CarouselImg()
        {
            return View();
        }
        public ActionResult LoadCarouselImg()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 100;
            int totalCount = 0;
            CarouselImgParam CarouselImgParam = new CarouselImgParam()
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                totalCount = totalCount,
            };
            var CarouselImglist = CarouselImgService.LoadSearchEntities(CarouselImgParam);
            var temp = from u in CarouselImglist
                       select new
                       {
                           Id = u.Id,
                           ShowImg=u.ShowImg,
                           Url=u.Url,
                       };
            return Json(new { rows = temp, total = CarouselImgParam.totalCount, msg = "ok" }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult DeleteCarouselImg()
        {
            string strid = Request["strid"];
            string[] strids = strid.Split(',');
            List<CarouselImg> list = new List<CarouselImg>();
            foreach (string id in strids)
            {
                int Id = int.Parse(id);
                CarouselImg CarouselImg = CarouselImgService.LoadEutities(c => c.Id == Id).FirstOrDefault();
                list.Add(CarouselImg);
            }
            if (CarouselImgService.DeleteEntites(list))
            {
                return Content("yes");
            }
            else
            {
                return Content("no");
            }
        }
        public ActionResult EditCarouselImgLoad()
        {
            int Id = Request["Id"] != null ? int.Parse(Request["Id"]) : 0;
            string action = Request["action"];
            if (action == "edit")
            {
                CarouselImg CarouselImg = CarouselImgService.LoadEutities(c => c.Id == Id).FirstOrDefault();
                ViewBag.Id = Id;
                ViewBag.action = action;
                ViewBag.ShowImg = CarouselImg.ShowImg;
                ViewBag.Url = CarouselImg.Url;
            }
            else
            {
                ViewBag.Id = 0;
                ViewBag.action = action;
                ViewBag.ShowImg = "";
                ViewBag.Url = "";
            }
            return View();
        }
        public ActionResult EditCarouselImg(CarouselImg CarouselImg)
        {
            string action = Request["action"];
            string ShowImg = Request["ShowImg"];
            string Url = Request["Url"];
            if (action == "edit")
            {
                int Id = int.Parse(Request["Id"]);
                CarouselImg f = CarouselImgService.LoadEutities(c => c.Id == Id).FirstOrDefault();
                f.ShowImg = ShowImg;
                f.Url = Url;
                bool b = CarouselImgService.EditEnity(f);
                if (b)
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
                CarouselImg b = CarouselImgService.AddEntity(CarouselImg);
                if (b != null)
                {
                    return Content("ok");
                }
                else
                {
                    return Content("no");
                }
            }
        }
        #endregion
    }
}

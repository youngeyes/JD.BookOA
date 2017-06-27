 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JD.BookOA.IBLL;
using JD.BookOA.Model;
using JD.BookOA.Model.Enum;

namespace JD.BookOA.BLL
{

	
	public partial class BookService :BaseService<Book>,IBookService
    {
        public override void SetCurretenDal()
        {
            CurrentDal = this.GetCurrentDbSession.BookDal;
        }
    }   
	
	public partial class CarouselImgService :BaseService<CarouselImg>,ICarouselImgService
    {
        public override void SetCurretenDal()
        {
            CurrentDal = this.GetCurrentDbSession.CarouselImgDal;
        }
    }   
	
	public partial class ChildClassService :BaseService<ChildClass>,IChildClassService
    {
        public override void SetCurretenDal()
        {
            CurrentDal = this.GetCurrentDbSession.ChildClassDal;
        }
    }   
	
	public partial class FriendshipService :BaseService<Friendship>,IFriendshipService
    {
        public override void SetCurretenDal()
        {
            CurrentDal = this.GetCurrentDbSession.FriendshipDal;
        }
    }   
	
	public partial class MemberService :BaseService<Member>,IMemberService
    {
        public override void SetCurretenDal()
        {
            CurrentDal = this.GetCurrentDbSession.MemberDal;
        }
    }   
	
	public partial class MessageService :BaseService<Message>,IMessageService
    {
        public override void SetCurretenDal()
        {
            CurrentDal = this.GetCurrentDbSession.MessageDal;
        }
    }   
	
	public partial class OrdersService :BaseService<Orders>,IOrdersService
    {
        public override void SetCurretenDal()
        {
            CurrentDal = this.GetCurrentDbSession.OrdersDal;
        }
    }   
	
	public partial class ParentClassService :BaseService<ParentClass>,IParentClassService
    {
        public override void SetCurretenDal()
        {
            CurrentDal = this.GetCurrentDbSession.ParentClassDal;
        }
    }   
	
	public partial class schildclassService :BaseService<schildclass>,IschildclassService
    {
        public override void SetCurretenDal()
        {
            CurrentDal = this.GetCurrentDbSession.schildclassDal;
        }
    }   
	
	public partial class Shopping_CartService :BaseService<Shopping_Cart>,IShopping_CartService
    {
        public override void SetCurretenDal()
        {
            CurrentDal = this.GetCurrentDbSession.Shopping_CartDal;
        }
    }   
	
	public partial class UserInfoService :BaseService<UserInfo>,IUserInfoService
    {
        public override void SetCurretenDal()
        {
            CurrentDal = this.GetCurrentDbSession.UserInfoDal;
        }
    }   
	
}
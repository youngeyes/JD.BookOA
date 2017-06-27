 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JD.BookOA.IDAL;
using JD.BookOA.Model;

namespace JD.BookOA.DAL
{
		
	public partial class BookDal :BaseDal<Book>,IBookDal
    {

    }
		
	public partial class CarouselImgDal :BaseDal<CarouselImg>,ICarouselImgDal
    {

    }
		
	public partial class ChildClassDal :BaseDal<ChildClass>,IChildClassDal
    {

    }
		
	public partial class FriendshipDal :BaseDal<Friendship>,IFriendshipDal
    {

    }
		
	public partial class MemberDal :BaseDal<Member>,IMemberDal
    {

    }
		
	public partial class MessageDal :BaseDal<Message>,IMessageDal
    {

    }
		
	public partial class OrdersDal :BaseDal<Orders>,IOrdersDal
    {

    }
		
	public partial class ParentClassDal :BaseDal<ParentClass>,IParentClassDal
    {

    }
		
	public partial class schildclassDal :BaseDal<schildclass>,IschildclassDal
    {

    }
		
	public partial class Shopping_CartDal :BaseDal<Shopping_Cart>,IShopping_CartDal
    {

    }
		
	public partial class UserInfoDal :BaseDal<UserInfo>,IUserInfoDal
    {

    }
	
}
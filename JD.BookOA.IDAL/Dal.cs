 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JD.BookOA.Model;

namespace JD.BookOA.IDAL
{
   
	
	public partial interface IBookDal :IBaseDal<Book>
    {
      
    }
	
	public partial interface ICarouselImgDal :IBaseDal<CarouselImg>
    {
      
    }
	
	public partial interface IChildClassDal :IBaseDal<ChildClass>
    {
      
    }
	
	public partial interface IFriendshipDal :IBaseDal<Friendship>
    {
      
    }
	
	public partial interface IMemberDal :IBaseDal<Member>
    {
      
    }
	
	public partial interface IMessageDal :IBaseDal<Message>
    {
      
    }
	
	public partial interface IOrdersDal :IBaseDal<Orders>
    {
      
    }
	
	public partial interface IParentClassDal :IBaseDal<ParentClass>
    {
      
    }
	
	public partial interface IschildclassDal :IBaseDal<schildclass>
    {
      
    }
	
	public partial interface IShopping_CartDal :IBaseDal<Shopping_Cart>
    {
      
    }
	
	public partial interface IUserInfoDal :IBaseDal<UserInfo>
    {
      
    }
	
}
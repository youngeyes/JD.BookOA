 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JD.BookOA.Model;
using JD.BookOA.Model.SearchParam;

namespace JD.BookOA.IBLL
{
	
	public partial interface IBookService : IBaseService<Book>
    {
       
    }   
	
	public partial interface ICarouselImgService : IBaseService<CarouselImg>
    {
       
    }   
	
	public partial interface IChildClassService : IBaseService<ChildClass>
    {
       
    }   
	
	public partial interface IFriendshipService : IBaseService<Friendship>
    {
       
    }   
	
	public partial interface IMemberService : IBaseService<Member>
    {
       
    }   
	
	public partial interface IMessageService : IBaseService<Message>
    {
       
    }   
	
	public partial interface IOrdersService : IBaseService<Orders>
    {
       
    }   
	
	public partial interface IParentClassService : IBaseService<ParentClass>
    {
       
    }   
	
	public partial interface IschildclassService : IBaseService<schildclass>
    {
       
    }   
	
	public partial interface IShopping_CartService : IBaseService<Shopping_Cart>
    {
       
    }   
	
	public partial interface IUserInfoService : IBaseService<UserInfo>
    {
       
    }   
	
}
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD.BookOA.IDAL
{
	public partial interface IDBSession
    {

	
		IBookDal BookDal{get;set;}
	
		ICarouselImgDal CarouselImgDal{get;set;}
	
		IChildClassDal ChildClassDal{get;set;}
	
		IFriendshipDal FriendshipDal{get;set;}
	
		IMemberDal MemberDal{get;set;}
	
		IMessageDal MessageDal{get;set;}
	
		IOrdersDal OrdersDal{get;set;}
	
		IParentClassDal ParentClassDal{get;set;}
	
		IschildclassDal schildclassDal{get;set;}
	
		IShopping_CartDal Shopping_CartDal{get;set;}
	
		IUserInfoDal UserInfoDal{get;set;}
	}	
}
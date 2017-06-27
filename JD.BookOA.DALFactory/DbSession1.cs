 

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JD.BookOA.DAL;
using JD.BookOA.IDAL;
using JD.BookOA.Model;

namespace JD.BookOA.DALFactory
{
	public partial class DBSession : IDBSession
    {
	
		private IBookDal _BookDal;
        public IBookDal BookDal
        {
            get
            {
                if(_BookDal == null)
                {
                   // _BookDal = new BookDal();
				    _BookDal =AbstractFactory.CreateBookDal();

                }
                return _BookDal;
            }
            set { _BookDal = value; }
        }
	
		private ICarouselImgDal _CarouselImgDal;
        public ICarouselImgDal CarouselImgDal
        {
            get
            {
                if(_CarouselImgDal == null)
                {
                   // _CarouselImgDal = new CarouselImgDal();
				    _CarouselImgDal =AbstractFactory.CreateCarouselImgDal();

                }
                return _CarouselImgDal;
            }
            set { _CarouselImgDal = value; }
        }
	
		private IChildClassDal _ChildClassDal;
        public IChildClassDal ChildClassDal
        {
            get
            {
                if(_ChildClassDal == null)
                {
                   // _ChildClassDal = new ChildClassDal();
				    _ChildClassDal =AbstractFactory.CreateChildClassDal();

                }
                return _ChildClassDal;
            }
            set { _ChildClassDal = value; }
        }
	
		private IFriendshipDal _FriendshipDal;
        public IFriendshipDal FriendshipDal
        {
            get
            {
                if(_FriendshipDal == null)
                {
                   // _FriendshipDal = new FriendshipDal();
				    _FriendshipDal =AbstractFactory.CreateFriendshipDal();

                }
                return _FriendshipDal;
            }
            set { _FriendshipDal = value; }
        }
	
		private IMemberDal _MemberDal;
        public IMemberDal MemberDal
        {
            get
            {
                if(_MemberDal == null)
                {
                   // _MemberDal = new MemberDal();
				    _MemberDal =AbstractFactory.CreateMemberDal();

                }
                return _MemberDal;
            }
            set { _MemberDal = value; }
        }
	
		private IMessageDal _MessageDal;
        public IMessageDal MessageDal
        {
            get
            {
                if(_MessageDal == null)
                {
                   // _MessageDal = new MessageDal();
				    _MessageDal =AbstractFactory.CreateMessageDal();

                }
                return _MessageDal;
            }
            set { _MessageDal = value; }
        }
	
		private IOrdersDal _OrdersDal;
        public IOrdersDal OrdersDal
        {
            get
            {
                if(_OrdersDal == null)
                {
                   // _OrdersDal = new OrdersDal();
				    _OrdersDal =AbstractFactory.CreateOrdersDal();

                }
                return _OrdersDal;
            }
            set { _OrdersDal = value; }
        }
	
		private IParentClassDal _ParentClassDal;
        public IParentClassDal ParentClassDal
        {
            get
            {
                if(_ParentClassDal == null)
                {
                   // _ParentClassDal = new ParentClassDal();
				    _ParentClassDal =AbstractFactory.CreateParentClassDal();

                }
                return _ParentClassDal;
            }
            set { _ParentClassDal = value; }
        }
	
		private IschildclassDal _schildclassDal;
        public IschildclassDal schildclassDal
        {
            get
            {
                if(_schildclassDal == null)
                {
                   // _schildclassDal = new schildclassDal();
				    _schildclassDal =AbstractFactory.CreateschildclassDal();

                }
                return _schildclassDal;
            }
            set { _schildclassDal = value; }
        }
	
		private IShopping_CartDal _Shopping_CartDal;
        public IShopping_CartDal Shopping_CartDal
        {
            get
            {
                if(_Shopping_CartDal == null)
                {
                   // _Shopping_CartDal = new Shopping_CartDal();
				    _Shopping_CartDal =AbstractFactory.CreateShopping_CartDal();

                }
                return _Shopping_CartDal;
            }
            set { _Shopping_CartDal = value; }
        }
	
		private IUserInfoDal _UserInfoDal;
        public IUserInfoDal UserInfoDal
        {
            get
            {
                if(_UserInfoDal == null)
                {
                   // _UserInfoDal = new UserInfoDal();
				    _UserInfoDal =AbstractFactory.CreateUserInfoDal();

                }
                return _UserInfoDal;
            }
            set { _UserInfoDal = value; }
        }
	}	
}
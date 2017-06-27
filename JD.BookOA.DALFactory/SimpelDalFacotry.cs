 

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JD.BookOA.IDAL;

namespace JD.BookOA.DALFactory
{
    public partial class AbstractFactory
    {
      
   
		
	    public static IBookDal CreateBookDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".BookDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IBookDal;
        }
		
	    public static ICarouselImgDal CreateCarouselImgDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".CarouselImgDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as ICarouselImgDal;
        }
		
	    public static IChildClassDal CreateChildClassDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".ChildClassDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IChildClassDal;
        }
		
	    public static IFriendshipDal CreateFriendshipDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".FriendshipDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IFriendshipDal;
        }
		
	    public static IMemberDal CreateMemberDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".MemberDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IMemberDal;
        }
		
	    public static IMessageDal CreateMessageDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".MessageDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IMessageDal;
        }
		
	    public static IOrdersDal CreateOrdersDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".OrdersDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IOrdersDal;
        }
		
	    public static IParentClassDal CreateParentClassDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".ParentClassDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IParentClassDal;
        }
		
	    public static IschildclassDal CreateschildclassDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".schildclassDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IschildclassDal;
        }
		
	    public static IShopping_CartDal CreateShopping_CartDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Shopping_CartDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IShopping_CartDal;
        }
		
	    public static IUserInfoDal CreateUserInfoDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".UserInfoDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IUserInfoDal;
        }
	}
	
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JD.BookOA.Model;
using JD.BookOA.Model.SearchParam;
using JD.BookOA.IBLL;

namespace JD.BookOA.BLL
{
    public partial class BookService:BaseService<Book>,IBookService
    {
        public IQueryable<Book> LoadSearchEntities(BookParam BookParam)
        {
            var temp = this.GetCurrentDbSession.BookDal.LoadEutities(c => c.Id > 0);
            if (!string.IsNullOrEmpty(BookParam.BookName))
            {
                temp = temp.Where<Book>(c => c.BookName.Contains(BookParam.BookName));
            }
            if (!string.IsNullOrEmpty(BookParam.Author))
            {
                temp = temp.Where<Book>(c => c.Author.Contains(BookParam.Author));
            }
            if (!string.IsNullOrEmpty(BookParam.Press))
            {
                temp = temp.Where<Book>(c => c.Press.Contains(BookParam.Press));
            }
            if (!string.IsNullOrEmpty(BookParam.Presstime1))
            {
                DateTime time1 = DateTime.Parse(BookParam.Presstime1);
                temp = temp.Where<Book>(c => c.Presstime >= time1);
            }
            if (!string.IsNullOrEmpty(BookParam.Presstime2))
            {
                DateTime time2 = DateTime.Parse(BookParam.Presstime2);
                temp = temp.Where<Book>(c => c.Presstime <= time2);
            }
            if (!string.IsNullOrEmpty(BookParam.ISBN))
            {
                temp = temp.Where<Book>(c => c.ISBN.Contains(BookParam.ISBN));
            }
            if (!string.IsNullOrEmpty(BookParam.NewPrice))
            {
                decimal newprice = decimal.Parse(BookParam.NewPrice);
                temp = temp.Where<Book>(c => c.NewPrice == newprice);
            }
            if (!string.IsNullOrEmpty(BookParam.ParentId))
            {
                int a = int.Parse(BookParam.ParentId);
                temp = temp.Where<Book>(c => c.ParentId == a);
            }
            if (!string.IsNullOrEmpty(BookParam.ChildId))
            {
                int a = int.Parse(BookParam.ChildId);
                temp = temp.Where<Book>(c => c.ChildId == a);
            }
            if (!string.IsNullOrEmpty(BookParam.Stock))
            {
                int a = int.Parse(BookParam.Stock);
                temp = temp.Where<Book>(c => c.Stock == a);
            }
            if (!string.IsNullOrEmpty(BookParam.Reserve11))
            {
                DateTime time1 = DateTime.Parse(BookParam.Reserve11);
                temp = temp.Where<Book>(c => c.Reserve1 >= time1);
            }
            if (!string.IsNullOrEmpty(BookParam.Reserve12))
            {
                DateTime time2 = DateTime.Parse(BookParam.Reserve12);
                temp = temp.Where<Book>(c => c.Reserve1 <= time2);
            }
            BookParam.totalCount = temp.Count();
            return temp.OrderBy<Book, int>(u => u.Id).Skip<Book>((BookParam.pageIndex - 1) * BookParam.pageSize).Take<Book>(BookParam.pageSize);//排序分页
        }


        public IQueryable<Book> LoadSearch(BookParam BookParam)
        {
            var temp = this.GetCurrentDbSession.BookDal.LoadEutities(c => c.Id > 0);
            if (!string.IsNullOrEmpty(BookParam.SearchParam))
            {
                temp = temp.Where<Book>(c => c.BookName.Contains(BookParam.SearchParam) || c.Author.Contains(BookParam.SearchParam) || c.Press.Contains(BookParam.SearchParam));
            }
            BookParam.totalCount = temp.Count();
            return temp.OrderBy<Book, int>(u => u.Id).Skip<Book>((BookParam.pageIndex - 1) * BookParam.pageSize).Take<Book>(BookParam.pageSize);//排序分页
        }
    }
}

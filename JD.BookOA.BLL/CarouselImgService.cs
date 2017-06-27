using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JD.BookOA.Model;
using JD.BookOA.Model.SearchParam;
using JD.BookOA.IBLL;

namespace JD.BookOA.BLL
{
    public partial class CarouselImgService:BaseService<CarouselImg>,ICarouselImgService
    {
        public IQueryable<CarouselImg> LoadSearchEntities(CarouselImgParam CarouselImgParam)
        {
            var temp = this.GetCurrentDbSession.CarouselImgDal.LoadEutities(c => c.Id > 0);
            CarouselImgParam.totalCount = temp.Count();
            return temp.OrderBy<CarouselImg, int>(u => u.Id).Skip<CarouselImg>((CarouselImgParam.pageIndex - 1) * CarouselImgParam.pageSize).Take<CarouselImg>(CarouselImgParam.pageSize);//排序分页
        }
    }
}

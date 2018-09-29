using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.AdminWeb.App_Start;
using ZSZ.IService;

namespace ZSZ.AdminWeb.Controllers
{
    public class LongHouseController : Controller
    {
        public IAdminUserService userSerivce { get; set; }

        public IHouseService houseService { get; set; }
        public ICityService cityService { get; set; }
        public IRegionService regionService { get; set; }
        public ICommunityService communityService { get; set; }
        public IIdNameService idNameService { get; set; }
        public IAttachmentService attService { get; set; }

        [CheckPermission("AdminUser.List")]
        public ActionResult List(long typeId, int pageIndex = 1)
        {
            //因为AuthorizFilter做了是否登录的检查，因此这里不会取不到id
            long userId = (long)AdminHelper.GetUserId(HttpContext);
            long? cityId = userSerivce.GetById(userId).CityId;
            if (cityId == null)
            {
                //如果“总部不能***”的操作很多，也可以定义成一个AuthorizeFilter
                //最好用FilterAttribute的方式标注，这样对其他的不涉及这个问题的地方效率高
                //立即实现
                return View("Error", (object)"总部不能进行房源管理");
            }
            var houses = houseService.GetPagedData(cityId.Value, typeId, 10, (pageIndex - 1) * 10);
            //long totalCount = houseService.GetTotalCount(cityId.Value, typeId);
            //ViewBag.pageIndex = pageIndex;
            //ViewBag.totalCount = totalCount;
            //ViewBag.typeId = typeId;
            return View(houses);
        }
    }
}
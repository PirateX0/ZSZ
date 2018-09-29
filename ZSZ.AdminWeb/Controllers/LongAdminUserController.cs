using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.IService;
using ZSZ.DTO;
using ZSZ.AdminWeb.Models;
using ZSZ.CommonMVC;
using ZSZ.AdminWeb.App_Start;

namespace ZSZ.AdminWeb.Controllers
{
    public class LongAdminUserController : Controller
    {
        public IAdminUserService adminUserService { get; set; }
        public ICityService cityService { get; set; }
        public IRoleService roleService { get; set; }

        [CheckPermission("AdminUser.List")]
        public ActionResult List()
        {
            AdminUserDTO[] adminUserDTOs = adminUserService.GetAll();
            return View(adminUserDTOs);
        }

        public ActionResult CheckPhoneNum(string phoneNum)
        {
            bool isOK = !adminUserService.isPhoneNumeExistent(phoneNum);
            return Json(new AjaxResult { Status = isOK ? "ok" : "exists" });
        }

        public ActionResult CheckPhoneNum(string phoneNum, long userId)
        {
            bool isOK = !adminUserService.isPhoneNumeExistent(phoneNum,userId);
            return Json(new AjaxResult { Status = isOK ? "ok" : "exists" });
        }

        [HttpGet]
        public ActionResult Add()
        {
            CityDTO[] cityDTOs = cityService.GetAll();
            RoleDTO[] roleDTOs = roleService.GetAll();
            LongAdminUserAddViewModel longAdminUserAddViewModel = new LongAdminUserAddViewModel
            {
                Cities=cityDTOs, Roles=roleDTOs
            };
            return View(longAdminUserAddViewModel);
        }

        //注意手机号应唯一
        [HttpPost]
        public ActionResult Add(LongAdminUserAddModel longAdminUserAddModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new AjaxResult { Status="error" ,ErrorMsg=MVCHelper.GetValidMsg(ModelState) } );

            }

            long id= adminUserService.AddAdminUser(longAdminUserAddModel.Name, longAdminUserAddModel.PhoneNum, 
                longAdminUserAddModel.Password, longAdminUserAddModel.Email, longAdminUserAddModel.CityId);
            roleService.AddRoleIds(id, longAdminUserAddModel.RoleIds);
            return Json(new AjaxResult { Status="ok"});
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            CityDTO[] cityDTOs = cityService.GetAll();
            RoleDTO[] roleDTOs = roleService.GetAll();
            AdminUserDTO adminUserDTO = adminUserService.GetById(id);
            long[] UserRoleIds = roleService.GetByAdminUserId(id).Select(x=>x.Id).ToArray();
            LongAdminUserEditViewModel longAdminUserEditViewModel = new LongAdminUserEditViewModel
            {
                AdminUser = adminUserDTO,
                Cities = cityDTOs,
                Roles = roleDTOs,
                UserRoleIds = UserRoleIds
            };
          
            return View(longAdminUserEditViewModel);
        }

        //注意手机号应唯一
        [HttpPost]
        public ActionResult Edit(LongAdminUserEditModel longAdminUserEditModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new AjaxResult { Status="error",ErrorMsg=MVCHelper.GetValidMsg(ModelState)});
            }

            adminUserService.UpdateAdminUser(
                longAdminUserEditModel.Id,longAdminUserEditModel.Name,longAdminUserEditModel.PhoneNum,
                longAdminUserEditModel.Password,longAdminUserEditModel.Email,longAdminUserEditModel.CityId);

            roleService.AddRoleIds(longAdminUserEditModel.Id, longAdminUserEditModel.RoleIds);

            return Json(new AjaxResult { Status="ok"});
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {

            adminUserService.MarkDeleted(id);

            return Json(new AjaxResult { Status = "ok" });
        }

        [HttpPost]
        public ActionResult BatchDelete(long[] selectedIds)
        {

            foreach (var id in selectedIds)
            {
                adminUserService.MarkDeleted(id);
            }

            return Json(new AjaxResult { Status = "ok" });
        }

    }
}
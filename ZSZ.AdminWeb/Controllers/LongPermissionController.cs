using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.CommonMVC;
using ZSZ.DTO;
using ZSZ.IService;

namespace ZSZ.AdminWeb.Controllers
{
    public class LongPermissionController : Controller
    {
        public IPermissionService PermSvc { get; set; }
        // GET: LongPermission
        public ActionResult LongList()
        {
            var permissionList = PermSvc.GetAll();
            return View(permissionList);
        }

        public ActionResult Delete(long id)
        {
            PermSvc.MarkDeleted(id);
            return Json(new AjaxResult { Status = "ok" });
        }

        [HttpGet]
        public ActionResult LongAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LongAdd(string name, string description)
        {
            PermSvc.AddPermission(name,description);
            return Json(new AjaxResult() {Status="ok" });
        }

        [HttpGet]
        public ActionResult LongEdit(long id)
        {
            PermissionDTO permissionDTO= PermSvc.GetById(id);
            return View(permissionDTO);
        }

        [HttpPost]
        public ActionResult LongEdit(long id, string name, string description)
        {
            PermSvc.UpdatePermission(id ,name, description);
            return Json(new AjaxResult() { Status = "ok" });
        }
    }
}
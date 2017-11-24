using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Manage.Framework;
using Manage.Core;
using Business.Controller.Facades;
using Business.Model.Models;
using System;
using Manage.Open;
using Business.Controller.Common;
using Manage.Core.Facades;
using Manage.Core.Common;
using Manage.Core.Models;

namespace Business.Controller.Controllers
{
    public class ColumnController : BaseController
    {
        #region 定义
        //延迟加载业务处理器
        Lazy<IMenuFacade> _MenuFacade = new Lazy<IMenuFacade>(() => { return new MenuFacade(); }, true);
        //视图地址
        string _path = "/Views/Menu/";
        #endregion

        #region 视图
        /// <summary>
        /// 【视图】菜单列表
        /// </summary>
        /// <returns></returns>
        public ViewResult Selecter(int MenuType)
        {
            var model = new Menu_S();
            model.MenuType = MenuType;
            return View(model);
        }


        public ViewResult List()
        {
            return View();
        }


        public ViewResult Edit(string id)
        {
            var model = _MenuFacade.Value.GetByID<Menu_S>(id);
            if (model != null)
            {
                var perMenu = _MenuFacade.Value.GetByID<Menu_S>(model.PerMenuID);
                if (perMenu != null)
                    model.PerMenuName = perMenu.MenuName;
            }

            ViewBag.ActionUrl = "_Edit";
            ViewBag.OperType = "Edit";
           
            return View("Add", model);
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取菜单Json
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetColumnTree(string menutype)
        {
            var list = _MenuFacade.Value.GetAllMenus();
            if (!string.IsNullOrWhiteSpace(menutype))
                list = list.FindAll(c => c.MenuType == menutype.Convert<int>(0)).ToList();

            var tree = list.Select(s => new
             {
                 id = s.ID,
                 pId = s.PerMenuID,//增加一个ID为root的顶层虚拟菜单
                 name = s.MenuName,
                 title = s.MenuDesc,
                 menucode = s.MenuCode,
                 menupath = s.MenuPath,
                 order = s.MenuOrder,
                 level = s.MenuLevel,
                 open = s.MenuLevel <= 1,
                 menuType = s.MenuType
             }).ToList();
            
            return Json(AjaxResult.Success(tree));
        }

        /// <summary>
        /// 获取菜单Json
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetMenuTree()
        {
            var tree = _MenuFacade.Value.GetAllMenus("34b3b356-8880-4049-b8b6-199003ca9bce").Select(s => new
            {
                id = s.ID,
                pId = s.PerMenuID,//增加一个ID为root的顶层虚拟菜单
                name = s.MenuName,
                title = s.MenuDesc,
                menucode = s.MenuCode,
                menupath = s.MenuPath,
                order = s.MenuOrder,
                level = s.MenuLevel,
                open = s.MenuLevel <= 1,
                menuType = s.MenuType
            }).ToList();
            tree.Add(new
            {
                id = "34b3b356-8880-4049-b8b6-199003ca9bce",
                pId = "0",
                name = "顶层虚拟栏目",
                title = "虚拟栏目",
                menucode = "",
                menupath = "",
                order = 0,
                level = -1,
                open = true,
                menuType = (int)MenuType.Menu
            });
            return Json(AjaxResult.Success(tree));
        }
        #endregion

        #region 扩展

        

        #endregion
    }
}

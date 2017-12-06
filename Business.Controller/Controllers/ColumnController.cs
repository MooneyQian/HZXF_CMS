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

        private string PID = "34b3b356-8880-4049-b8b6-199003ca9bce";

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

        public ViewResult Add(string pid)
        {
            Menu_S model = new Menu_S();
            if (pid == PID)
            {
                model = new Menu_S() { PerMenuID = PID, PerMenuName = "", MenuLevel = 2 };
            }
            else
            {
                var perMenu = _MenuFacade.Value.GetByID<Menu_S>(pid);
                model = new Menu_S() { PerMenuID = pid, PerMenuName = perMenu.MenuName, MenuLevel = perMenu.MenuLevel + 1 };
            }
            ViewBag.ActionUrl = "_Add";
            ViewBag.OperType = "Add";
            //model.Extend3 = "SView";
            ViewBag.PrivilegeType = DictionaryshipFactory.Instance.GetDictSelectList(DictParam.SysPrivilegeType, true);
            ViewBag.FunType = DictionaryshipFactory.Instance.GetDictSelectList(DictParam.FunType, true);

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
            ViewBag.PrivilegeType = DictionaryshipFactory.Instance.GetDictSelectList(DictParam.SysPrivilegeType, true);
            ViewBag.FunType = DictionaryshipFactory.Instance.GetDictSelectList(DictParam.FunType, true);
           
            return View("Add", model);
        }

        #endregion

        #region 方法

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public JsonResult _Add(Menu_I menu)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(menu.MenuIcon))
                {
                    byte[] outputb = Convert.FromBase64String(menu.MenuIcon);
                    menu.MenuIcon = Encoding.Default.GetString(outputb);
                }
                _MenuFacade.Value.Add(menu);

                if (menu.Extend5.Equals("1") && menu.MenuType == 1)
                {
                    string menupath = menu.MenuPath;
                    if (!string.IsNullOrEmpty(menupath))
                    {
                        if (menupath.IndexOf("?") >= 0)
                        {
                            menupath += "&columnid=" + menu.ID + "&navcolumnid=" + menu.PerMenuID;
                        }
                        else
                        {
                            menupath += "?columnid=" + menu.ID + "&navcolumnid=" + menu.PerMenuID;
                        }
                        menu.MenuPath = menupath;
                        _MenuFacade.Value.Edit(menu);
                    }
                }

                var model = (new
                {
                    id = menu.ID,
                    pId = menu.PerMenuID,
                    name = menu.MenuName,
                    title = menu.MenuDesc,
                    menucode = menu.MenuCode,
                    menupath = menu.MenuPath,
                    order = menu.MenuOrder,
                    level = menu.MenuLevel,
                    menuType = menu.MenuType
                });
                return Json(AjaxResult.Success(model, "菜单新增成功!"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error("菜单新增失败!错误原因：" + ex.Message));
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public JsonResult _Edit(Menu_U menu)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(menu.MenuIcon))
                {
                    byte[] outputb = Convert.FromBase64String(menu.MenuIcon);
                    menu.MenuIcon = Encoding.Default.GetString(outputb);
                }

                _MenuFacade.Value.Edit(menu);
                var model = (new
                {
                    id = menu.ID,
                    name = menu.MenuName,
                    title = menu.MenuDesc,
                    menucode = menu.MenuCode,
                    menupath = menu.MenuPath,
                    order = menu.MenuOrder
                });
                return Json(AjaxResult.Success(model, "菜单更新成功!"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error("菜单更新失败!错误原因：" + ex.Message));
            }
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult _Delete(string ids)
        {
            try
            {
                _MenuFacade.Value.Del(ids);
                return Json(AjaxResult.Success("用户删除成功！"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error(ex.Message));
            }
        }

        /// <summary>
        /// 获取菜单Json
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetLeftMenuTree()
        {
            var tree = _MenuFacade.Value.GetAllMenus(true).Select(s => new
            {
                id = s.ID,
                pId = s.PerMenuID,
                name = s.MenuName,
                title = s.MenuDesc,
                menucode = s.MenuCode,
                menupath = s.MenuPath,
                order = s.MenuOrder,
                level = s.MenuLevel,
                menuicon = s.MenuIcon
            });
            return Json(AjaxResult.Success(tree));
        }


        /// <summary>
        /// 获取菜单Json
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetMenuTree()
        {
            var tree = _MenuFacade.Value.GetAllMenus(false).Select(s => new
            {
                id = s.ID,
                pId = s.PerMenuID == "0" ? "root" : s.PerMenuID,//增加一个ID为root的顶层虚拟菜单
                name = s.MenuName,
                title = s.MenuDesc,
                menucode = s.MenuCode,
                menupath = s.MenuPath,
                order = s.MenuOrder,
                level = s.MenuLevel,
                open = s.MenuLevel <= 1,
                menuType = s.MenuType,
                isparent = false
            }).ToList();
            tree.Add(new
            {
                id = PID,
                pId = "0",
                name = "顶层虚拟栏目",
                title = "虚拟栏目",
                menucode = "",
                menupath = "",
                order = 0,
                level = -1,
                open = true,
                menuType = (int)MenuType.Menu,
                isparent = true
            });
            return Json(AjaxResult.Success(tree));
        }
        #endregion

        #region 扩展

        

        #endregion
    }
}

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
using System.IO;
using System.Web;
namespace Business.Controller.Controllers
{
    public class NavigationController : BaseController
    {
        #region 定义
        //延迟加载业务处理器
        Lazy<INavigationFacade> _NavigationFacade = new Lazy<INavigationFacade>(() => { return new NavigationFacade(); }, true);
        #endregion

        #region 视图
        /// <summary>
        /// 【视图】栏目列表
        /// </summary>
        /// <returns></returns>
        public ViewResult List(string columnid)
        {
            Navigation_S model = new Navigation_S();
            model.N_COLUMN_ID = columnid;
            return View(model);
        }

        /// <summary>
        /// 【视图】新增栏目
        /// </summary>
        /// <returns></returns>
        public ViewResult Add(string pid, string columnid)
        {
            ViewBag.FunType = DictionaryshipFactory.Instance.GetDictSelectList(DictParam.FunType);
            Navigation_S model = new Navigation_S();
            var columnname = _NavigationFacade.Value.GetColumnNameByColumnId(columnid);
            if (pid == "root")
            {
                model = new Navigation_S() { N_SUPER_NAVIGATION_ID = "0", VC_SUPER_NAVIGATION_NAME = "", N_COLUMN_ID = columnid, VC_COLUMN_NAME = columnname };
            }
            else
            {
                var perNav = _NavigationFacade.Value.GetByID<Navigation_S>(pid);
                model = new Navigation_S() { N_SUPER_NAVIGATION_ID = pid, VC_SUPER_NAVIGATION_NAME = perNav.VC_NAVIGATION_NAME, N_COLUMN_ID = columnid, VC_COLUMN_NAME = columnname };
            }
            return View(model);
        }

        /// <summary>
        /// 【视图】编辑导航
        /// </summary>
        /// <returns></returns>
        public ViewResult Edit(string id)
        {
            Navigation_S model = _NavigationFacade.Value.GetByID<Navigation_S>(id);
            //model.VC_COLUMN_NAME = _NavigationFacade.Value.GetColumnNameByColumnId(model.N_COLUMN_ID);
            return View("Add", model);
        }

        /// <summary>
        /// 【视图】查看文章
        /// </summary>
        /// <returns></returns>
        public ViewResult Show(string NavID)
        {
            Navigation_S model = _NavigationFacade.Value.GetByID<Navigation_S>(NavID);
            model.VC_COLUMN_NAME = _NavigationFacade.Value.GetColumnNameByColumnId(model.N_COLUMN_ID);
            return View(model);
        }
        #endregion

        #region 方法
        /// <summary>
        /// 获取菜单Json
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetNavTree(string ColumnId)
        {
            var tree = _NavigationFacade.Value.GetAllNavigations(ColumnId).Select(s => new
            {
                id = s.ID,
                pId = s.N_SUPER_NAVIGATION_ID == "0" ? "root" : s.N_SUPER_NAVIGATION_ID,//增加一个ID为root的顶层虚拟菜单
                name = s.VC_NAVIGATION_NAME,
                orderno = s.N_ORDER_NO,
                columnid = s.N_COLUMN_ID,
                title = s.VC_NAVIGATION_NAME,
                open = false
            }).ToList();
            tree.Add(new
            {
                id = "root",
                pId = "0",
                name = "导航树",
                orderno = 0,
                columnid = ColumnId,
                title = "顶层虚拟导航",
                open = true
            });
            return Json(AjaxResult.Success(tree));
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public JsonResult _Add(Navigation_S nav)
        {
            try
            {
                _NavigationFacade.Value.Add(nav);
                var model = (new
                {
                    id = nav.ID,
                    pId = nav.N_SUPER_NAVIGATION_ID == "0" ? "root" : nav.N_SUPER_NAVIGATION_ID,
                    name = nav.VC_NAVIGATION_NAME,
                    orderno = nav.N_ORDER_NO,
                    columnid = nav.N_COLUMN_ID,
                    title = nav.VC_NAVIGATION_NAME,
                });
                return Json(AjaxResult.Success(model, "导航新增成功!"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error("导航新增失败!错误原因：" + ex.Message));
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="article">文章实体</param>
        /// <returns></returns>
        [ValidateInput(false)]
        public JsonResult _Edit(Navigation_S nav)
        {
            try
            {
                _NavigationFacade.Value.Edit<Navigation_S>(nav);
                return Json(AjaxResult.Success(nav, "导航修改成功!"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error("导航修改失败!错误原因：" + ex.Message));
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult _Delete(string NavID)
        {
            try
            {
                _NavigationFacade.Value.Delete(NavID);
                return Json(AjaxResult.Success("导航删除成功！"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error(ex.Message));
            }
        }
        #endregion

        #region 扩展
        public JsonResult _DelFile(string filePath)
        {
            string strFilePath = System.Web.HttpContext.Current.Server.MapPath(filePath);
            if (System.IO.File.Exists(strFilePath))
            {
                try
                {
                    System.IO.File.Delete(strFilePath);
                    return Json(AjaxResult.Success("删除成功!"));
                }
                catch (Exception e)
                {
                    return Json(AjaxResult.Error("删除失败!" + e.ToString()));
                }
            }
            else
                return Json(AjaxResult.Error("删除失败!"));
        }
        #endregion
    }
}

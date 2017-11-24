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

namespace Business.Controller.Controllers
{
    public class FloatWindowController : BaseController
    {
        Lazy<IEventFacade> _EventFacade = new Lazy<IEventFacade>(() => { return new EventFacade(); }, true);
        Lazy<IFloatWindowFacade> _FloatWindowFacade = new Lazy<IFloatWindowFacade>(() => { return new FloatWindowFacade(); }, true);
        Lazy<IUserFacade> _UserFacade = new Lazy<IUserFacade>(() => { return new UserFacade(); }, true);


        #region 视图
        /// <summary>
        /// 【视图】专题明细列表
        /// </summary>
        /// <returns></returns>
        public ViewResult List(string EventID)
        {
            FloatWindow_S model = new FloatWindow_S();
            return View(model);
        }

        /// <summary>
        /// 【视图】新增文章
        /// </summary>
        /// <returns></returns>
        public ViewResult Add(string EventID, string EventName)
        {
            var model = new FloatWindow_S();
            return View(model);
        }

        /// <summary>
        /// 【视图】编辑文章
        /// </summary>
        /// <returns></returns>
        public ViewResult Edit(string FloatWindowID)
        {
            var model = _FloatWindowFacade.Value.GetByID<FloatWindow_S>(FloatWindowID);
            return View(model);
        }

        /// <summary>
        /// 【视图】查看文章
        /// </summary>
        /// <returns></returns>
        public ViewResult Show(string FloatWindowID)
        {
            var model = _FloatWindowFacade.Value.GetByID<FloatWindow_S>(FloatWindowID);
            return View(model);
        }
        #endregion

        #region 方法
        /// <summary>
        /// 分页获取专题
        /// </summary>
        /// <param name="article">搜索条件</param>
        /// <param name="pi">分页信息</param>
        /// <returns></returns>
        public JsonResult _FloatWindowList(FloatWindow_S model, PageInfo pi)
        {
            var data = _FloatWindowFacade.Value.GetFloatWindowListPaged(model, pi);
            foreach (var item in data)
            {
                item.VC_START_POSITION = Enum.GetName(typeof(EMSTARTPOSITION), item.C_START_POSITION.Convert<int>(1));
            }
            var result = new
            {
                Rows = data,
                Total = pi.Total
            };
            return Json(result);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="article">文章实体</param>
        /// <returns></returns>
        [ValidateInput(false)]
        public JsonResult _Add(FloatWindow_S model)
        {
            try
            {
                model.VC_OP_NAME = CurrentUserContext.UserInfo.UserDisplayName;
                model.DT_OP_TIME = DateTime.Now;
                model.C_STATUS = ((int)RecordStatus.Enable).ToString();

                if (_FloatWindowFacade.Value.AddFloatWindow(model))
                    return Json(AjaxResult.Success(model, "浮动窗口新增成功!"));
                else
                    return Json(AjaxResult.Success(model, "浮动窗口新增失败!"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error("浮动窗口新增失败!错误原因：" + ex.Message));
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="article">文章实体</param>
        /// <returns></returns>
        [ValidateInput(false)]
        public JsonResult _Edit(FloatWindow_S model)
        {
            try
            {
                if (_FloatWindowFacade.Value.EditFloatWindow(model))
                    return Json(AjaxResult.Success(model, "专题明细修改成功!"));
                else
                    return Json(AjaxResult.Success(model, "专题明细修改失败!"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error("专题明细修改失败!错误原因：" + ex.Message));
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult _Delete(string ids)
        {
            try
            {
                _FloatWindowFacade.Value.Delete(ids);
                return Json(AjaxResult.Success("专题明细删除成功！"));
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

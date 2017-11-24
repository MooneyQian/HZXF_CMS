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
    public class EventDetailController : BaseController
    {
        Lazy<IEventFacade> _EventFacade = new Lazy<IEventFacade>(() => { return new EventFacade(); }, true);
        Lazy<IEventDetailFacade> _EventDetailFacade = new Lazy<IEventDetailFacade>(() => { return new EventDetailFacade(); }, true);
        Lazy<IUserFacade> _UserFacade = new Lazy<IUserFacade>(() => { return new UserFacade(); }, true);


        #region 视图
        /// <summary>
        /// 【视图】专题明细列表
        /// </summary>
        /// <returns></returns>
        public ViewResult List(string EventID)
        {
            EventDetail_S model = new EventDetail_S();
            model.N_EVENT_ID = EventID;
            model.VC_EVENT_NAME = _EventFacade.Value.GetByID<Event_S>(model.N_EVENT_ID).VC_TITLE;
            return View(model);
        }

        /// <summary>
        /// 【视图】新增文章
        /// </summary>
        /// <returns></returns>
        public ViewResult Add(string EventID, string EventName)
        {
            var model = new EventDetail_S();
            model.N_EVENT_ID = EventID;
            model.VC_EVENT_NAME = EventName;
            return View(model);
        }

        /// <summary>
        /// 【视图】编辑文章
        /// </summary>
        /// <returns></returns>
        public ViewResult Edit(string EventDetailID)
        {
            var model = _EventDetailFacade.Value.GetByID<EventDetail_S>(EventDetailID);
            model.VC_EVENT_NAME = _EventFacade.Value.GetByID<Event_S>(model.N_EVENT_ID).VC_TITLE;
            return View(model);
        }

        /// <summary>
        /// 【视图】查看文章
        /// </summary>
        /// <returns></returns>
        public ViewResult Show(string EventDetailID)
        {
            var model = _EventDetailFacade.Value.GetByID<EventDetail_S>(EventDetailID);
            model.VC_EVENT_NAME = _EventFacade.Value.GetByID<Event_S>(model.N_EVENT_ID).VC_TITLE;
            model.VC_OP_NAME = _UserFacade.Value.GetUserDisplayNameByID(model.N_OP_ID);
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
        public JsonResult _EventDetailList(EventDetail_S model, PageInfo pi)
        {
            var data = _EventDetailFacade.Value.GetEventDetailListPaged(model, pi);
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
        public JsonResult _Add(EventDetail_S model)
        {
            try
            {
                model.N_OP_ID = CurrentUserContext.UserID;
                model.DT_OP_TIME = DateTime.Now;

                if (_EventDetailFacade.Value.AddEventDetail(model))
                    return Json(AjaxResult.Success(model, "专题明细新增成功!"));
                else
                    return Json(AjaxResult.Success(model, "专题明细新增失败!"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error("专题明细新增失败!错误原因：" + ex.Message));
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="article">文章实体</param>
        /// <returns></returns>
        [ValidateInput(false)]
        public JsonResult _Edit(EventDetail_S model)
        {
            try
            {
                if (_EventDetailFacade.Value.EditEventDetail(model))
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
                _EventDetailFacade.Value.Delete(ids);
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

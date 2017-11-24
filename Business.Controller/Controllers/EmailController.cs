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

namespace Business.Controller.Controllers
{
    public class EmailController : BaseController
    {
        #region 定义
        //延迟加载业务处理器
        Lazy<IEmailRecordFacade> _EmailRecordFacade = new Lazy<IEmailRecordFacade>(() => { return new EmailRecordFacade(); }, true);
        #endregion

        #region 视图
        /// <summary>
        /// 【视图】列表
        /// </summary>
        /// <returns></returns>
        public ViewResult List(string columnid)
        {
            ViewBag.N_START_DATE = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            ViewBag.N_END_DATE = DateTime.Now.ToString("yyyy-MM-dd");
            EmailRecord_S model = new EmailRecord_S();
            return View(model);
        }

        /// <summary>
        /// 【视图】查看
        /// </summary>
        /// <returns></returns>
        public ViewResult Show(string EmailID)
        {
            EmailRecord_S model = _EmailRecordFacade.Value.GetByID<EmailRecord_S>(EmailID);
            model.C_EMAIL_TYPE = Enum.GetName(typeof(EMEMAILTYPE), (model.C_EMAIL_TYPE).Convert<int>(1));
            return View(model);
        }
        /// <summary>
        /// 【视图】回复
        /// </summary>
        /// <returns></returns>
        public ViewResult Reply(string EmailID)
        {
            EmailRecord_S model = _EmailRecordFacade.Value.GetByID<EmailRecord_S>(EmailID);
            model.C_EMAIL_TYPE = Enum.GetName(typeof(EMEMAILTYPE), (model.C_EMAIL_TYPE).Convert<int>(1));
            return View(model);
        }
        #endregion

        #region 方法
        /// <summary>
        /// 分页获取文章
        /// </summary>
        /// <param name="article">搜索条件</param>
        /// <param name="pi">分页信息</param>
        /// <returns></returns>
        public JsonResult _EmailList(EmailRecord_S email, PageInfo pi)
        {
            var data = _EmailRecordFacade.Value.GetEmailListPaged(email, pi);
            foreach (var item in data)
            {
                item.C_EMAIL_TYPE = Enum.GetName(typeof(EMEMAILTYPE), (item.C_EMAIL_TYPE).Convert<int>(1));
            }
            var result = new
            {
                Rows = data,
                Total = pi.Total
            };
            return Json(result);
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult _Verify(string EmailID)
        {
            try
            {
                var model = _EmailRecordFacade.Value.GetByID<EmailRecord_S>(EmailID);
                model.C_STATUS = ((int)EMEMAILSTATUS.已审核).ToString();
                model.DT_VERIFY_TIME = DateTime.Now;
                _EmailRecordFacade.Value.Edit<EmailRecord_S>(model);
                return Json(AjaxResult.Success("审核成功！"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error(ex.Message));
            }
        }
        /// <summary>
        /// 回复
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult _Reply(EmailRecord_S model)
        {
            try
            {
                var record = _EmailRecordFacade.Value.GetByID<EmailRecord_S>(model.ID);
                record.DT_REPLY_TIME = DateTime.Now;
                if (record.C_STATUS != ((int)EMEMAILSTATUS.已审核).ToString())
                    record.C_STATUS = ((int)EMEMAILSTATUS.已回复).ToString();
                record.VC_REPLYER = model.VC_REPLYER;
                record.VC_REPLY_CONTENT = model.VC_REPLY_CONTENT;
                _EmailRecordFacade.Value.Edit<EmailRecord_S>(record);
                return Json(AjaxResult.Success("回复成功！"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error(ex.Message));
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
                _EmailRecordFacade.Value.Delete(ids);
                return Json(AjaxResult.Success("删除成功！"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error(ex.Message));
            }
        }
        #endregion

        #region 扩展
        #endregion
    }
}

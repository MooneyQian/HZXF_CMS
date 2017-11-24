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
    public class ArticleApplyController : BaseController
    {
        #region 定义
        //延迟加载业务处理器
        Lazy<IArticleApplyFacade> _ArticleApplyFacade = new Lazy<IArticleApplyFacade>(() => { return new ArticleApplyFacade(); }, true);
        Lazy<IArticleFacade> _ArticleFacade = new Lazy<IArticleFacade>(() => { return new ArticleFacade(); }, true);

        #endregion

        #region 视图
        /// <summary>
        /// 【视图】文章列表
        /// </summary>
        /// <returns></returns>
        public ViewResult List(string columnid)
        {
            ViewBag.N_START_DATE = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            ViewBag.N_END_DATE = DateTime.Now.ToString("yyyy-MM-dd");
            ArticleApply_S model = new ArticleApply_S();
            return View(model);
        }

        /// <summary>
        /// 【视图】查看文章
        /// </summary>
        /// <returns></returns>
        public ViewResult Show(string ArticleApplyID)
        {
            ArticleApply_S model = _ArticleApplyFacade.Value.GetByID<ArticleApply_S>(ArticleApplyID);
            model.VC_ARTICLE_NAME = _ArticleFacade.Value.GetByID<Article_S>(model.N_ARTICLE_ID).VC_TITLE;
            model.VC_CHECKER_NAME = CurrentUserContext.UserInfo.UserDisplayName;
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
        public JsonResult _ArticleApplyList(ArticleApply_S ArticleApply, PageInfo pi)
        {
            var data = _ArticleApplyFacade.Value.GetArticleApplyListPaged(ArticleApply, pi);
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
        /// <param name="ArticleApplyID"></param>
        /// <returns></returns>
        public JsonResult _Check(string ArticleApplyID, string CheckMemo)
        {
            try
            {
                var model = _ArticleApplyFacade.Value.GetByID<ArticleApply_S>(ArticleApplyID);
                model.C_CHECK_STATUS = ((int)EMCHECKSTATUS.审核通过).ToString();
                model.DT_CHECK_TIME = DateTime.Now;
                model.VC_CHECKER_ID = CurrentUserContext.UserID;
                model.VC_CHECK_MEMO = CheckMemo;
                if (_ArticleApplyFacade.Value.EditArticleApply(model))
                    return Json(AjaxResult.Success(model, "审核成功!"));
                else
                    return Json(AjaxResult.Success(model, "审核失败!"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error("审核失败!错误原因：" + ex.Message));
            }
        }
        /// 审核
        /// </summary>
        /// <param name="ArticleApplyID"></param>
        /// <returns></returns>
        public JsonResult _RefuseCheck(string ArticleApplyID, string CheckMemo)
        {
            try
            {
                var model = _ArticleApplyFacade.Value.GetByID<ArticleApply_S>(ArticleApplyID);
                model.C_CHECK_STATUS = ((int)EMCHECKSTATUS.审核不通过).ToString();
                model.DT_CHECK_TIME = DateTime.Now;
                model.VC_CHECKER_ID = CurrentUserContext.UserID;
                model.VC_CHECK_MEMO = CheckMemo;
                if (_ArticleApplyFacade.Value.EditArticleApply(model))
                    return Json(AjaxResult.Success(model, "审核不通过!"));
                else
                    return Json(AjaxResult.Success(model, "审核失败!"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error("审核失败!错误原因：" + ex.Message));
            }
        }
        #endregion

        #region 扩展
        #endregion
    }
}

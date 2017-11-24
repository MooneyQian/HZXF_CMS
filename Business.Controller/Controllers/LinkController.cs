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
    public class LinkController : BaseController
    {
        Lazy<ILinkFacade> _LinkFacade = new Lazy<ILinkFacade>(() => { return new LinkFacade(); }, true);

       
        #region 视图
        /// <summary>
        /// 【视图】文章列表
        /// </summary>
        /// <returns></returns>
        public ViewResult List(string columnid)
        {
            Article_S model = new Article_S();
            model.N_COLUMN_ID = columnid;
            return View(model);
        }

        /// <summary>
        /// 【视图】新增文章
        /// </summary>
        /// <returns></returns>
        public ViewResult Add(string columnid)
        {
            Article_S model = new Article_S();
            model.N_COLUMN_ID = columnid;
            //model.VC_COLUMN_NAME = _ArticleFacade.Value.GetColumnNameByColumnId(columnid);
            return View(model);
        }

        /// <summary>
        /// 【视图】编辑文章
        /// </summary>
        /// <returns></returns>
        public ViewResult Edit(string ArticleID)
        {
            //Article_S model = _ArticleFacade.Value.GetByID<Article_S>(ArticleID);
            //model.VC_COLUMN_NAME = _ArticleFacade.Value.GetColumnNameByColumnId(model.N_COLUMN_ID);
            //return View(model);
            return View();
        }

        /// <summary>
        /// 【视图】查看文章
        /// </summary>
        /// <returns></returns>
        public ViewResult Show(string ArticleID)
        {
            //Article_S model = _ArticleFacade.Value.GetByID<Article_S>(ArticleID);
            //model.VC_RECOMMEND_NAME = Enum.GetName(typeof(EMRECOMMENDLEVEL), (model.C_RECOMMEND_LEVEL).Convert<int>(1));
            //model.VC_COLUMN_NAME = _ArticleFacade.Value.GetColumnNameByColumnId(model.N_COLUMN_ID);
            //model.VC_ADD_OP_NAME = _CustomerHomeFacade.Value.GetByID<SysUser_S>(model.N_ADD_OP_ID).UserDisplayName;
            //model.VC_UPDATE_OP_NAME = _CustomerHomeFacade.Value.GetByID<SysUser_S>(model.N_UPDATE_OP_ID).UserDisplayName;
            //return View(model);
            return View();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 分页获取文章
        /// </summary>
        /// <param name="article">搜索条件</param>
        /// <param name="pi">分页信息</param>
        /// <returns></returns>
        public JsonResult _ArticleList(Article_S article, PageInfo pi)
        {
            //var data = _ArticleFacade.Value.GetArticlesPaged(article, pi);
            var result = new
            {
                //Rows = data,
                Total = pi.Total
            };
            return Json(result);
        }
        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="article">文章实体</param>
        /// <returns></returns>
        [ValidateInput(false)]
        public JsonResult _Add(Article_S article)
        {
            try
            {
                article.VC_CONTENT = article.editorValue;
                article.N_ADD_OP_ID = CurrentUserContext.UserID;
                article.N_UPDATE_OP_ID = CurrentUserContext.UserID;
                article.DT_ADD_TIME = DateTime.Now;
                article.DT_UPDATE_TIME = DateTime.Now;

                //if (_ArticleFacade.Value.AddArticle(article))
                //    return Json(AjaxResult.Success(article, "文章新增成功!"));
                //else
                    return Json(AjaxResult.Success(article, "文章新增失败!"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error("文章新增失败!错误原因：" + ex.Message));
            }
        }
        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="article">文章实体</param>
        /// <returns></returns>
        [ValidateInput(false)]
        public JsonResult _Edit(Article_S article)
        {
            try
            {
                article.VC_CONTENT = article.editorValue;
                article.N_UPDATE_OP_ID = CurrentUserContext.UserID;
                article.DT_UPDATE_TIME = DateTime.Now;
                //if (_ArticleFacade.Value.EditArticle(article))
                //    return Json(AjaxResult.Success(article, "文章修改成功!"));
                //else
                    return Json(AjaxResult.Success(article, "文章修改失败!"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error("文章修改失败!错误原因：" + ex.Message));
            }
        }
        #endregion

        
    }
}

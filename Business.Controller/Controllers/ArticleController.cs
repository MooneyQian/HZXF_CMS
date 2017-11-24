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
    public class ArticleController : BaseController
    {
        #region 定义
        //延迟加载业务处理器
        Lazy<ICustomerHomeFacade> _CustomerHomeFacade = new Lazy<ICustomerHomeFacade>(() => { return new CustomerHomeFacade(); }, true);
        Lazy<IArticleFacade> _ArticleFacade = new Lazy<IArticleFacade>(() => { return new ArticleFacade(); }, true);
        #endregion

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
        /// 【视图】文章列表
        /// </summary>
        /// <returns></returns>
        public ViewResult SearchList(string columnid)
        {
            Article_S model = new Article_S();
            //model.N_COLUMN_ID = columnid;
            return View(model);
        }
        /// <summary>
        /// 【视图】文章列表
        /// </summary>
        /// <returns></returns>
        public ViewResult VerifyList(string columnid)
        {
            var roles = CurrentUserContext.UserRoles;
            if (roles.Find(c => c.RoleName == "管理员") != null)
                ViewBag.B_Manager = "true";
            if (roles.Find(c => c.RoleName == "科长") != null)
                ViewBag.B_Primary = "true";
            if (roles.Find(c => c.RoleName == "副局长") != null)
                ViewBag.B_Ultimate = "true";
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
            model.VC_COLUMN_NAME = _ArticleFacade.Value.GetColumnNameByColumnId(columnid);
            return View(model);
        }

        /// <summary>
        /// 【视图】编辑文章
        /// </summary>
        /// <returns></returns>
        public ViewResult Edit(string ArticleID)
        {
            Article_S model = _ArticleFacade.Value.GetByID<Article_S>(ArticleID);
            model.VC_COLUMN_NAME = _ArticleFacade.Value.GetColumnNameByColumnId(model.N_COLUMN_ID);
            return View(model);
        }

        /// <summary>
        /// 【视图】查看文章
        /// </summary>
        /// <returns></returns>
        public ViewResult Show(string ArticleID)
        {
            Article_S model = _ArticleFacade.Value.GetByID<Article_S>(ArticleID);
            model.VC_RECOMMEND_NAME = Enum.GetName(typeof(EMRECOMMENDLEVEL), (model.C_RECOMMEND_LEVEL).Convert<int>(1));
            model.VC_COLUMN_NAME = _ArticleFacade.Value.GetColumnNameByColumnId(model.N_COLUMN_ID);
            model.VC_ADD_OP_NAME = _CustomerHomeFacade.Value.GetByID<SysUser_S>(model.N_ADD_OP_ID).UserDisplayName;
            model.VC_UPDATE_OP_NAME = _CustomerHomeFacade.Value.GetByID<SysUser_S>(model.N_UPDATE_OP_ID).UserDisplayName;
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
        public JsonResult _ArticleList(Article_S article, PageInfo pi)
        {
            var data = _ArticleFacade.Value.GetArticlesPaged(article, pi);
            foreach (var item in data)
            { item.VC_CONTENT = ""; }
            var result = new
            {
                Rows = data,
                Total = pi.Total
            };
            return Json(result);
        }
        /// <summary>
        /// 分页获取开放鉴定文章
        /// </summary>
        /// <param name="article">搜索条件</param>
        /// <param name="pi">分页信息</param>
        /// <returns></returns>
        public JsonResult _ArticleVerifyList(Article_S article, PageInfo pi)
        {
            var data = _ArticleFacade.Value.GetArticlesVerifyPaged(article, pi);
            foreach (var item in data)
            { item.VC_CONTENT = ""; }
            var result = new
            {
                Rows = data,
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
                if (article.N_COLUMN_ID == "802")
                {
                    if (_ArticleFacade.Value.IsTitleExisted(article))
                    {
                        return Json(AjaxResult.Error(article, "该文章已存在，请核对!"));
                    }
                }
                if (article.N_COLUMN_ID != "6020005")
                    article.C_VERIFY_STATUS = ((int)EMARTICLESTATUS.二级审核).ToString();
                article.VC_CONTENT = article.editorValue;
                article.N_ADD_OP_ID = CurrentUserContext.UserID;
                article.N_UPDATE_OP_ID = CurrentUserContext.UserID;
                article.DT_ADD_TIME = DateTime.Now;
                article.DT_UPDATE_TIME = DateTime.Now;

                if (_ArticleFacade.Value.AddArticle(article))
                    return Json(AjaxResult.Success(article, "文章新增成功!"));
                else
                    return Json(AjaxResult.Success(article, "文章新增失败!"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error("文章新增失败!错误原因：" + ex.Message));
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
                _ArticleFacade.Value.Delete(ids);
                return Json(AjaxResult.Success("文章删除成功！"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error(ex.Message));
            }
        }


        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult _Verify(string id)
        {
            try
            {
                var model = _ArticleFacade.Value.GetByID<Article_S>(id);
                var roles = CurrentUserContext.UserRoles;
                if (roles.Find(c => c.RoleName == "科长") != null)
                    model.C_VERIFY_STATUS = ((int)EMARTICLESTATUS.一级审核).ToString();
                if (roles.Find(c => c.RoleName == "副局长") != null)
                    model.C_VERIFY_STATUS = ((int)EMARTICLESTATUS.二级审核).ToString();
                _ArticleFacade.Value.EditArticle(model);
                return Json(AjaxResult.Success("文章审核成功！"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error(ex.Message));
            }
        }
        /// <summary>
        /// 取消审核
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult _RemoveVerify(string id)
        {
            try
            {
                var model = _ArticleFacade.Value.GetByID<Article_S>(id);
                var roles = CurrentUserContext.UserRoles;
                if (roles.Find(c => c.RoleName == "科长") != null)
                    model.C_VERIFY_STATUS = ((int)EMARTICLESTATUS.初审不通过).ToString();
                if (roles.Find(c => c.RoleName == "副局长") != null)
                    model.C_VERIFY_STATUS = ((int)EMARTICLESTATUS.复审不通过).ToString();
                _ArticleFacade.Value.EditArticle(model);
                return Json(AjaxResult.Success("文章取消审核成功！"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error(ex.Message));
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
                if (_ArticleFacade.Value.EditArticle(article))
                    return Json(AjaxResult.Success(article, "文章修改成功!"));
                else
                    return Json(AjaxResult.Success(article, "文章修改失败!"));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error("文章修改失败!错误原因：" + ex.Message));
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

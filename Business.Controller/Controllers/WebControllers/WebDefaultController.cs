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
namespace Business.Controller.Controllers.WebControllers
{
    public class WebDefaultController : WebBaseController
    {
        #region 定义
        //延迟加载业务处理器
        Lazy<INavigationFacade> _NavigationFacade = new Lazy<INavigationFacade>(() => { return new NavigationFacade(); }, true);

        Lazy<IArticleFacade> _ArticleFacade = new Lazy<IArticleFacade>(() => { return new ArticleFacade(); }, true);
        #endregion



        #region 视图
        /// <summary>
        /// 【视图】网站首页
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            return View();
        }

        #endregion



        #region 方法
        /// <summary>
        /// 获取顶部导航
        /// </summary>
        /// <returns></returns>
        public JsonResult _GetTopNavs()
        {
            string topnavkey = "11695838-751a-442f-9baa-e943e7d0451b";
            try
            {
                List<Navigation_S> list = _NavigationFacade.Value.GetAllNavigations(topnavkey);
                return Json(AjaxResult.Success(list));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error(ex.Message));
            }
        }


        /// <summary>
        /// 根据key获得导航信息
        /// </summary>
        /// <returns></returns>
        public JsonResult _GetSingleNav(string key = "", int limits = 5)
        {
            if (string.IsNullOrEmpty(key))
            {
                return Json(AjaxResult.Error("参数错误"));
            }
            try
            {
                Navigation_S ns = _NavigationFacade.Value.GetNavByKey(key);

                List<Article_S> list = _ArticleFacade.Value.GetTopArticleByColumnID("70010004", 5);

                var result = new
                {
                    obj = ns,
                    data = list
                };


                return Json(AjaxResult.Success(result));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error(ex.Message));
            }
        }

        /// <summary>
        /// 获取顶部导航
        /// </summary>
        /// <returns></returns>
        public JsonResult _GetArticles()
        {
            string topnavkey = "11695838-751a-442f-9baa-e943e7d0451b";
            try
            {
                List<Article_S> list = _ArticleFacade.Value.GetTopArticleByColumnID("70010004", 5);
                return Json(AjaxResult.Success(list));
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Error(ex.Message));
            }
        }

        #endregion

    }
}
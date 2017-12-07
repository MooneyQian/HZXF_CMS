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

        #endregion

    }
}
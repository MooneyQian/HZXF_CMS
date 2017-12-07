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
    /// <summary>
    /// 前台网站基础控制器
    /// </summary>
    /// <returns></returns>
    public class WebBaseController : BaseController
    {
        //允许不登录
        protected override bool LockLogin(ActionExecutingContext filterContext)
        {
            return true;
        }

    }
}

using Business.Model.Models;
using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Controller.Facades
{

    public interface ILinkFacade : IBaseFacade
    {
        #region 链接方法
        /// <summary>
        /// 得到链接类型地址
        /// 3国内档案网站 4省内档案网站 5热门网站
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        List<Link_S> GetAllLinks(string typeId);
        #endregion 
    }
}
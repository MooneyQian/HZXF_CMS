
using Business.Model.Models;
using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Controller.Facades
{

    public interface ICustomerHomeFacade : IBaseFacade
    {


        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        /// <param name="nStartDate"></param>
        /// <param name="nEndDate"></param>
        /// <param name="pi"></param>
        /// <returns></returns>
        SysUser_S GetUserInfoByLoginName(string LoginName);
    }
}

using Business.Model.Models;
using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Controller.Facades
{

    public interface INavigationFacade : IBaseFacade
    {


        /// <summary>
        /// 获取所有菜单（除管理员菜单）
        /// </summary>
        /// <returns></returns>
        List<Navigation_S> GetAllNavigations(string ColumnId);

        /// <summary>
        /// 根据栏目编号获取栏目名称
        /// </summary>
        /// <returns></returns>
        string GetColumnNameByColumnId(string ColumnId);
    }
}
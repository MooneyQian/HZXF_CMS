
using Business.Model.Entitys.Entity;
using Business.Model.Models;
using Manage.Framework;
using Manage.SSO.Entity;
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

        /// <summary>
        /// 根据标识获得栏目
        /// </summary>
        /// <returns></returns>
        MenuEntity GetColumnByKey(string key);

         /// <summary>
        /// 根据标识获得导航
        /// </summary>
        /// <returns></returns>
        Navigation_S GetNavByKey(string key);
    }
}
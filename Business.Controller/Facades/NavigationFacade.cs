
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Manage.Framework;
using Business.Model.Entitys.Entity;
using Business.Model.Models;
using Manage.Open;
using System.Data;
using Manage.Core.Models;
using Manage.SSO.Entity;
using Manage.Core.Entitys;
using Business.Controller.Common;
using Manage.Core;

namespace Business.Controller.Facades
{

    public class NavigationFacade : BaseFacade<NavigationEntity>, INavigationFacade
    {


        /// <summary>
        /// 获取所有菜单（除管理员菜单）
        /// </summary>
        /// <returns></returns>
        public List<Navigation_S> GetAllNavigations(string ColumnId = "")
        {
            using (var factory = new BaseAccess())
            {
                List<Orderby<NavigationEntity>> orders = new List<Orderby<NavigationEntity>>()
                {
                    new Orderby<NavigationEntity>(c => c.N_ORDER_NO, SortOrder.Ascending)
                };
                //var Column = factory.GetSingle<MenuEntity>(Specification<MenuEntity>.Create(c => c.MenuCode == ColumnId));
                var spec = Specification<NavigationEntity>.Create(c => true);
                if (!string.IsNullOrEmpty(ColumnId))
                {
                    spec = Specification<NavigationEntity>.Create(c => c.N_COLUMN_ID.Equals(ColumnId));
                }
                var list = factory.GetAll<NavigationEntity>(spec, orders)
                    .Adapter<NavigationEntity, Navigation_S>(new List<Navigation_S>());
                return list;
            }
        }

        /// <summary>
        /// 根据栏目编号获取栏目名称
        /// </summary>
        /// <returns></returns>
        public string GetColumnNameByColumnId(string ColumnId)
        {
            using (var factory = new BaseAccess())
            {
                var Column = factory.GetSingle<MenuEntity>(Specification<MenuEntity>.Create(c => c.MenuCode == ColumnId));
                return Column.MenuName;
            }
        }


        /// <summary>
        /// 根据标识获得栏目
        /// </summary>
        /// <returns></returns>
        public MenuEntity GetColumnByKey(string key)
        {
            using (var factory = new BaseAccess())
            {
                var Column = factory.GetSingle<MenuEntity>(Specification<MenuEntity>.Create(c => c.ID == key));
                return Column;
            }
        }

        /// <summary>
        /// 根据标识获得导航
        /// </summary>
        /// <returns></returns>
        public Navigation_S GetNavByKey(string key)
        {
            using (var factory = new BaseAccess())
            {
                NavigationEntity Column = factory.GetSingle<NavigationEntity>(Specification<NavigationEntity>.Create(c => c.N_NAV_CODE == key));

                if (Column != null)
                {

                    Navigation_S ss = new Navigation_S();

                    Column.Adapter<Navigation_S>(ss);

                    return Column.Adapter<Navigation_S>(new Navigation_S());
                }

                return new Navigation_S();
            }
        }
    }
}
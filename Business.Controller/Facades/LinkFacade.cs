
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

namespace Business.Controller.Facades
{

    public class LinkFacade : BaseFacade<LinkEntity>, ILinkFacade
    {
        #region 链接方法
        /// <summary>
        /// 得到链接类型地址
        /// 3国内档案网站 4省内档案网站 5热门网站
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public List<Link_S> GetAllLinks(string typeId)
        {
            using (var factory = new BaseAccess())
            {
                List<Orderby<LinkEntity>> orders = new List<Orderby<LinkEntity>>()
                {
                    new Orderby<LinkEntity>(c => c.DT_OP_TIME, SortOrder.Descending)
                };

                var spec = Specification<LinkEntity>.Create(c => c.C_LINK_TYPE == typeId);
                var list = factory.GetAll<LinkEntity>(spec, orders)
                    .Adapter<LinkEntity, Link_S>(new List<Link_S>());
                return list;
            }
        }
        #endregion

        
    }
}
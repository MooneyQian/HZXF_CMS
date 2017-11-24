
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

    public class EventDetailFacade : BaseFacade<EventDetailEntity>, IEventDetailFacade
    {
        /// <summary>
        /// 分页获取专题明细列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pi"></param>
        /// <returns></returns>
        public List<EventDetail_S> GetEventDetailListPaged(EventDetail_S model, PageInfo pi)
        {
            using (var factory = new BaseAccess())
            {
                List<Orderby<EventDetailEntity>> orders = new List<Orderby<EventDetailEntity>>()
                {
                    new Orderby<EventDetailEntity>(c => c.DT_OP_TIME, SortOrder.Ascending)
                };

                var spec = Specification<EventDetailEntity>.Create(c => true);
                if (!string.IsNullOrWhiteSpace(model.VC_TITLE))
                {
                    spec &= Specification<EventDetailEntity>.Create(c => c.VC_TITLE.Contains(model.VC_TITLE));
                }
                if (!string.IsNullOrWhiteSpace(model.N_EVENT_ID))
                {
                    spec &= Specification<EventDetailEntity>.Create(c => c.N_EVENT_ID == model.N_EVENT_ID);
                }
                var list = factory.GetPage<EventDetailEntity>(pi, spec, orders)
                    .Adapter<EventDetailEntity, EventDetail_S>(new List<EventDetail_S>());
                return list;
            }
        }

        /// <summary>
        /// 新增专题明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddEventDetail(EventDetail_S model)
        {
            using (var factory = new BaseAccess())
            {
                try
                {
                    var entity = model.Adapter<EventDetailEntity>(new EventDetailEntity());
                    factory.Insert(entity);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 修改专题明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditEventDetail(EventDetail_S model)
        {
            using (var factory = new BaseAccess())
            {
                try
                {
                    var entity = model.Adapter<EventDetailEntity>(new EventDetailEntity());
                    factory.Update<EventDetailEntity>(entity);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
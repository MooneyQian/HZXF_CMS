
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

    public class EventFacade : BaseFacade<EventEntity>, IEventFacade
    {
        /// <summary>
        /// 分页获取专题列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pi"></param>
        /// <returns></returns>
        public List<Event_S> GetEventListPaged(Event_S model, PageInfo pi)
        {
            using (var factory = new BaseAccess())
            {
                List<Orderby<EventEntity>> orders = new List<Orderby<EventEntity>>()
                {
                    new Orderby<EventEntity>(c => c.DT_OP_TIME, SortOrder.Descending)
                };

                var spec = Specification<EventEntity>.Create(c => true);
                if (!string.IsNullOrWhiteSpace(model.VC_TITLE))
                {
                    spec &= Specification<EventEntity>.Create(c => c.VC_TITLE.Contains(model.VC_TITLE));
                }
                var list = factory.GetPage<EventEntity>(pi, spec, orders)
                    .Adapter<EventEntity, Event_S>(new List<Event_S>());
                return list;
            }
        }

        /// <summary>
        /// 获取带明细的专题信息
        /// </summary>
        /// <param name="EventID"></param>
        /// <returns></returns>
        public Event_S GetEventWithDetail(string EventID)
        {
            using (var factory = new BaseAccess())
            {
                var entity = factory.GetSingle<EventEntity>(EventID);
                var model = entity.Adapter<Event_S>(new Event_S());

                var spec = Specification<EventDetailEntity>.Create(c => c.N_EVENT_ID == EventID);
                var entitydetaillist = factory.GetAll<EventDetailEntity>(spec);
                model.listEventDetail = entitydetaillist.Adapter<EventDetailEntity, EventDetail_S>(new List<EventDetail_S>());

                return model;
            }
        }

        /// <summary>
        /// 分页获取专题列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pi"></param>
        /// <returns></returns>
        public Event_S GetLatestEvent()
        {
            using (var factory = new BaseAccess())
            {
                List<Orderby<EventEntity>> orders = new List<Orderby<EventEntity>>()
                {
                    new Orderby<EventEntity>(c => c.DT_OP_TIME, SortOrder.Descending)
                };

                var spec = Specification<EventEntity>.Create(c => true);
                var pi = new PageInfo();
                pi.PageIndex = 1;
                pi.PageSize = 1;
                var list = factory.GetPage<EventEntity>(pi, spec, orders)
                    .Adapter<EventEntity, Event_S>(new List<Event_S>());
                return list[0];
            }
        }

        /// <summary>
        /// 分页获取专题列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pi"></param>
        /// <returns></returns>
        public Event_S GetEventStatusOn()
        {
            using (var factory = new BaseAccess())
            {
                List<Orderby<EventEntity>> orders = new List<Orderby<EventEntity>>()
                {
                    new Orderby<EventEntity>(c => c.DT_OP_TIME, SortOrder.Descending)
                };

                var spec = Specification<EventEntity>.Create(c => c.C_STATUS == ((int)EMSTATUS.在用).ToString());
                var pi = new PageInfo();
                pi.PageIndex = 1;
                pi.PageSize = 1;
                var list = factory.GetPage<EventEntity>(pi, spec, orders)
                    .Adapter<EventEntity, Event_S>(new List<Event_S>());
                if (list.Count > 0)
                    return list[0];
                else
                    return new Event_S();
            }
        }

        /// <summary>
        /// 新增专题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddEvent(Event_S model)
        {
            using (var factory = new BaseAccess())
            {
                try
                {
                    var entity = model.Adapter<EventEntity>(new EventEntity());
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
        /// 修改专题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditEvent(Event_S model)
        {
            using (var factory = new BaseAccess())
            {
                try
                {
                    var entity = model.Adapter<EventEntity>(new EventEntity());
                    factory.Update<EventEntity>(entity);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取专题及其前后
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pi"></param>
        /// <returns></returns>
        public Event_S GetEventWithSide(string EventID)
        {
            using (var factory = new BaseAccess())
            {
                List<Orderby<EventEntity>> orders = new List<Orderby<EventEntity>>()
                {
                    new Orderby<EventEntity>(c => c.DT_OP_TIME, SortOrder.Descending)
                };

                var spec = Specification<EventEntity>.Create(c => true);
                var list = factory.GetAll<EventEntity>(spec, orders)
                    .Adapter<EventEntity, Event_S>(new List<Event_S>());
                var premodel = new Event_S();
                var nowmodel = list.Find(c => c.ID == EventID);
                if (nowmodel == null)
                    return new Event_S();
                var nextmodel = new Event_S();
                var index = list.FindIndex(c => c.ID == EventID);
                if (index != 0)
                    nowmodel.prevEvent = list[index - 1];
                if (index != list.Count - 1)
                    nowmodel.nextEvent = list[index + 1];
                return nowmodel;
            }
        }
    }
}

using Business.Model.Models;
using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Controller.Facades
{

    public interface IEventFacade : IBaseFacade
    {
        /// <summary>
        /// 分页获取专题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<Event_S> GetEventListPaged(Event_S model, PageInfo pi);

        /// <summary>
        /// 获取带明细的专题信息
        /// </summary>
        /// <param name="EventID"></param>
        /// <returns></returns>
        Event_S GetEventWithDetail(string EventID);

        /// <summary>
        /// 获取最近的专题
        /// </summary>
        /// <returns></returns>
        Event_S GetLatestEvent();

        /// <summary>
        /// 获取在用的专题
        /// </summary>
        /// <returns></returns>
        Event_S GetEventStatusOn();

        /// <summary>
        /// 获取专题及其前后专题
        /// </summary>
        /// <param name="EventID"></param>
        /// <returns></returns>
        Event_S GetEventWithSide(string EventID);

        /// <summary>
        /// 新增专题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddEvent(Event_S model);

        /// <summary>
        /// 修改专题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool EditEvent(Event_S model);
    }
}

using Business.Model.Models;
using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Controller.Facades
{

    public interface IEventDetailFacade : IBaseFacade
    {
        /// <summary>
        /// 分页获取专题明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<EventDetail_S> GetEventDetailListPaged(EventDetail_S model, PageInfo pi);

        /// <summary>
        /// 新增专题明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddEventDetail(EventDetail_S model);

        /// <summary>
        /// 修改专题明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool EditEventDetail(EventDetail_S model);
    }
}
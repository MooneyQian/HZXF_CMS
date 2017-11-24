
using Business.Model.Models;
using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Controller.Facades
{

    public interface IFloatWindowFacade : IBaseFacade
    {
        /// <summary>
        /// 分页获取专题明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<FloatWindow_S> GetFloatWindowListPaged(FloatWindow_S model, PageInfo pi);

        /// <summary>
        /// 新增专题明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddFloatWindow(FloatWindow_S model);

        /// <summary>
        /// 修改专题明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool EditFloatWindow(FloatWindow_S model);

        /// <summary>
        /// 获取最新可用飘窗
        /// </summary>
        /// <returns></returns>
        FloatWindow_S GetLastestFloat();
    }
}
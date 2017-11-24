
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

    public class FloatWindowFacade : BaseFacade<FloatWindowEntity>, IFloatWindowFacade
    {
        /// <summary>
        /// 分页获取专题明细列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pi"></param>
        /// <returns></returns>
        public List<FloatWindow_S> GetFloatWindowListPaged(FloatWindow_S model, PageInfo pi)
        {
            using (var factory = new BaseAccess())
            {
                List<Orderby<FloatWindowEntity>> orders = new List<Orderby<FloatWindowEntity>>()
                {
                    new Orderby<FloatWindowEntity>(c => c.DT_OP_TIME, SortOrder.Ascending)
                };

                var spec = Specification<FloatWindowEntity>.Create(c => true);
                if (!string.IsNullOrWhiteSpace(model.VC_TITLE))
                {
                    spec &= Specification<FloatWindowEntity>.Create(c => c.VC_TITLE.Contains(model.VC_TITLE));
                }

                var list = factory.GetPage<FloatWindowEntity>(pi, spec, orders)
                    .Adapter<FloatWindowEntity, FloatWindow_S>(new List<FloatWindow_S>());
                return list;
            }
        }

        /// <summary>
        /// 新增专题明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddFloatWindow(FloatWindow_S model)
        {
            using (var factory = new BaseAccess())
            {
                try
                {
                    var entity = model.Adapter<FloatWindowEntity>(new FloatWindowEntity());
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
        public bool EditFloatWindow(FloatWindow_S model)
        {
            using (var factory = new BaseAccess())
            {
                try
                {
                    var entity = model.Adapter<FloatWindowEntity>(new FloatWindowEntity());
                    factory.Update<FloatWindowEntity>(entity);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取最新可用飘窗
        /// </summary>
        /// <returns></returns>
        public FloatWindow_S GetLastestFloat()
        {
            using (var factory = new BaseAccess())
            {
                try
                {
                    List<Orderby<FloatWindowEntity>> orders = new List<Orderby<FloatWindowEntity>>()
                {
                    new Orderby<FloatWindowEntity>(c => c.DT_OP_TIME, SortOrder.Descending)
                };

                    var spec = Specification<FloatWindowEntity>.Create(c => true);
                    spec &= Specification<FloatWindowEntity>.Create(c => c.C_STATUS == ((int)RecordStatus.Enable).ToString());
                    var entity = factory.GetSingle<FloatWindowEntity>(spec);
                    return entity.Adapter<FloatWindow_S>(new FloatWindow_S());
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
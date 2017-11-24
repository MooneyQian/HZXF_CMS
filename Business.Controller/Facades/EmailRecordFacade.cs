
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Manage.Framework;
using Business.Model.Entitys.Entity;
using Business.Model.Models;
using Manage.Open;
using System.Data;

namespace Business.Controller.Facades
{

    public class EmailRecordFacade : BaseFacade<EmailRecordEntity>, IEmailRecordFacade
    {
        public EmailRecordFacade()
        {

        }

        /// <summary>
        /// 获取所有站点
        /// </summary>
        /// <param name="searchContent"></param>
        /// <returns></returns>
        public bool Add(EmailRecord_S model)
        {
            using (var factory = new BaseAccess())
            {
                try
                {
                    var entity = model.Adapter<EmailRecordEntity>(new EmailRecordEntity());
                    factory.Insert<EmailRecordEntity>(entity);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 分页获取文章
        /// </summary>
        /// <returns></returns>
        public List<EmailRecord_S> GetEmailListPaged(EmailRecord_S model, PageInfo pi)
        {
            using (var factory = new BaseAccess())
            {
                List<Orderby<EmailRecordEntity>> orders = new List<Orderby<EmailRecordEntity>>()
                {
                    new Orderby<EmailRecordEntity>(c => c.DT_TIME, SortOrder.Descending)
                };
                var spec = Specification<EmailRecordEntity>.Create(c => true);
                spec &= Specification<EmailRecordEntity>.Create(c => c.VC_CONTENT != "");

                if (!string.IsNullOrEmpty(model.C_STATUS))
                {
                    spec &= Specification<EmailRecordEntity>.Create(c => c.C_STATUS == model.C_STATUS);
                }
                if (!string.IsNullOrEmpty(model.C_EMAIL_TYPE))
                {
                    spec &= Specification<EmailRecordEntity>.Create(c => c.C_EMAIL_TYPE == model.C_EMAIL_TYPE);
                }
                if (!string.IsNullOrEmpty(model.VC_CONTENT))
                {
                    spec &= Specification<EmailRecordEntity>.Create(c => c.VC_CONTENT.Contains(model.VC_CONTENT));
                }
                if (!string.IsNullOrEmpty(model.VC_NAME))
                {
                    spec &= (Specification<EmailRecordEntity>.Create(c => c.VC_NAME.Contains(model.VC_NAME)));
                }
                if (model.N_START_DATE != null)
                {
                    spec &= (Specification<EmailRecordEntity>.Create(c => c.DT_TIME >= model.N_START_DATE));
                }
                if (model.N_END_DATE != null)
                {
                    spec &= (Specification<EmailRecordEntity>.Create(c => c.DT_TIME <= model.N_END_DATE));
                }

                var list = factory.GetPage<EmailRecordEntity>(pi, spec, orders).Adapter<EmailRecordEntity, EmailRecord_S>(new List<EmailRecord_S>());

                return list;
            }
        }
    }
}

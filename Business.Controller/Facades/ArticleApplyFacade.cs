
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

    public class ArticleApplyFacade : BaseFacade<ArticleApplyEntity>, IArticleApplyFacade
    {
        /// <summary>
        /// 分页获取专题明细列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pi"></param>
        /// <returns></returns>
        public List<ArticleApply_S> GetArticleApplyListPaged(ArticleApply_S model, PageInfo pi)
        {
            using (var factory = new BaseAccess())
            {
                List<Orderby<ArticleApplyEntity>> orders = new List<Orderby<ArticleApplyEntity>>()
                {
                    new Orderby<ArticleApplyEntity>(c => c.DT_APPLY_TIME, SortOrder.Descending)
                };

                var spec = Specification<ArticleApplyEntity>.Create(c => true);
                if (!string.IsNullOrWhiteSpace(model.VC_ARTICLE_NAME))
                {
                    var ArticleIDs = factory.GetAll<ArticleEntity>(Specification<ArticleEntity>.Create(c => c.VC_TITLE.Contains(model.VC_ARTICLE_NAME))).Select(c => c.ID).ToList().ToArray();
                    spec &= Specification<ArticleApplyEntity>.Create(c => ArticleIDs.Contains(c.N_ARTICLE_ID));
                }
                if (!string.IsNullOrWhiteSpace(model.C_CHECK_STATUS))
                {
                    spec &= Specification<ArticleApplyEntity>.Create(c => c.C_CHECK_STATUS == model.C_CHECK_STATUS);
                }
                if (!string.IsNullOrWhiteSpace(model.VC_APPLYER_NAME))
                {
                    spec &= Specification<ArticleApplyEntity>.Create(c => c.VC_APPLYER_NAME.Contains(model.VC_APPLYER_NAME));
                }
                if (model.N_START_DATE != null)
                {
                    spec &= (Specification<ArticleApplyEntity>.Create(c => c.DT_APPLY_TIME >= model.N_START_DATE));
                }
                if (model.N_END_DATE != null)
                {
                    spec &= (Specification<ArticleApplyEntity>.Create(c => c.DT_APPLY_TIME <= model.N_END_DATE));
                }
                var list = factory.GetPage<ArticleApplyEntity>(pi, spec, orders)
                    .Adapter<ArticleApplyEntity, ArticleApply_S>(new List<ArticleApply_S>());
                foreach (var item in list)
                {
                   // item.VC_ARTICLE_NAME = factory.GetSingle<ArticleEntity>(item.N_ARTICLE_ID).VC_TITLE;
                    item.VC_ARTICLE_NAME = factory.GetSingle<ArticleEntity>(item.N_ARTICLE_ID) == null ? "未知" : factory.GetSingle<ArticleEntity>(item.N_ARTICLE_ID).VC_TITLE;
                    if (!string.IsNullOrWhiteSpace(item.VC_CHECKER_ID))
                    {
                        var checker = factory.GetSingle<SYS_UserEntity>(item.VC_CHECKER_ID);
                        item.VC_CHECKER_NAME = checker == null ? "" : checker.UserDisplayName;
                    }
                }
                return list;
            }
        }

        /// <summary>
        /// 新增专题明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddArticleApply(ArticleApply_S model)
        {
            using (var factory = new BaseAccess())
            {
                try
                {
                    var entity = model.Adapter<ArticleApplyEntity>(new ArticleApplyEntity());
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
        public bool EditArticleApply(ArticleApply_S model)
        {
            using (var factory = new BaseAccess())
            {
                try
                {
                    var entity = model.Adapter<ArticleApplyEntity>(new ArticleApplyEntity());
                    factory.Update<ArticleApplyEntity>(entity);
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
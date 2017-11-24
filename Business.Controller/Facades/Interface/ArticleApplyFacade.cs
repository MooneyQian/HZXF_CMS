
using Business.Model.Models;
using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Controller.Facades
{

    public interface IArticleApplyFacade : IBaseFacade
    {
        /// <summary>
        /// 分页获取专题明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ArticleApply_S> GetArticleApplyListPaged(ArticleApply_S model, PageInfo pi);

        /// <summary>
        /// 新增专题明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddArticleApply(ArticleApply_S model);

        /// <summary>
        /// 修改专题明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool EditArticleApply(ArticleApply_S model);
    }
}
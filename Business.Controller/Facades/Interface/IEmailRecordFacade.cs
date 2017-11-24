
using Business.Model.Models;
using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Controller.Facades
{

    public interface IEmailRecordFacade : IBaseFacade
    {
        /// <summary>
        /// 新增邮件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(EmailRecord_S model);

        /// <summary>
        /// 分页获取邮件列表
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pi"></param>
        /// <returns></returns>
        List<EmailRecord_S> GetEmailListPaged(EmailRecord_S email, PageInfo pi);
    }
}
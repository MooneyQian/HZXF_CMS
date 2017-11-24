
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

    public class CustomerHomeFacade : BaseFacade<SYS_UserEntity>, ICustomerHomeFacade
    {
        public CustomerHomeFacade()
        {
        }

        /// <summary>
        /// 获取所有站点
        /// </summary>
        /// <param name="searchContent"></param>
        /// <returns></returns>
        public SysUser_S GetUserInfoByLoginName(string LoginName)
        {
            using (var factory = new BaseAccess())
            {
                var spec = Specification<SYS_UserEntity>.Create(c => c.UserLoginName == LoginName);

                //factory.DbContext.ExecuteString("",null)
                var model = factory.GetSingle<SYS_UserEntity>(spec);
                return model.Adapter<SysUser_S>(new SysUser_S());
            }
        }
    }
}
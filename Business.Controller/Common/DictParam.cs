using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Controller.Common
{
    /// <summary>
    /// 对应数据库字典表
    /// </summary>
    public static class DictParam
    {
        /// <summary>
        /// 功能类型
        /// </summary>
        public static string FunType { get { return "FunType"; } }

        /// <summary>
        /// 获取系统内置字典
        /// </summary>
        public static string Sysdictionary
        {
            get { return "SYS"; }
        }

        /// <summary>
        /// 获取功能类型
        /// </summary>
        public static string SysPrivilegeType
        {
            get { return "PrivilegeType"; }
        }

    }
}

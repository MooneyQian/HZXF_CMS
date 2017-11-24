using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Manage.SSO.Entity;


namespace Business.Model.Entitys.Entity
{
    //OperatorEntity
    [Serializable]
    public class EmailRecordEntity : AggregateRoot
    {
        /// <summary>
        /// 标题
        /// </summary>
        public virtual string VC_TITLE
        {
            get;
            set;
        }
        /// <summary>
        /// 内容
        /// </summary>
        public virtual string VC_CONTENT
        {
            get;
            set;
        }
        /// <summary>
        /// IP地址
        /// </summary>
        public virtual string VC_IP_ADDRESS
        {
            get;
            set;
        }
        
        /// <summary>
        /// 时间
        /// </summary>		
        public virtual DateTime DT_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string VC_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// 联系方式
        /// </summary>
        public virtual string VC_PHONE
        {
            get;
            set;
        }
        /// <summary>
        /// 邮件类型
        /// </summary>
        public virtual string C_EMAIL_TYPE
        {
            get;
            set;
        }


        /// <summary>
        /// 审核时间
        /// </summary>		
        public virtual DateTime? DT_VERIFY_TIME
        {
            get;
            set;
        }

        /// <summary>
        /// 回复时间
        /// </summary>		
        public virtual DateTime? DT_REPLY_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// 回复人
        /// </summary>
        public virtual string VC_REPLYER
        {
            get;
            set;
        }
        /// <summary>
        /// 回复内容
        /// </summary>
        public virtual string VC_REPLY_CONTENT
        {
            get;
            set;
        }
        /// <summary>
        /// 审核状态 0 未审核 1已审核 2已回复
        /// </summary>
        public virtual string C_STATUS
        {
            get;
            set;
        }
        

        #region 扩展
        #endregion
    }
}
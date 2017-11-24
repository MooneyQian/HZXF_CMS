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
    public class HitRecordEntity : AggregateRoot
    {
        /// <summary>
        /// 文章ＩＤ
        /// </summary>
        public virtual string N_ARTICLE_ID
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
        /// 点击时间
        /// </summary>		
        public virtual DateTime DT_HIT_TIME
        {
            get;
            set;
        }
        
        /// <summary>
        /// 点击类型
        /// </summary>		
        public virtual string C_HIT_TYPE
        {
            get;
            set;
        }
        

        #region 扩展
        #endregion
    }
}
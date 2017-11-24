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
    public class ArticleEntity : AggregateRoot
    {
        /// <summary>
        /// N_COLUMN_ID
        /// </summary>
        public virtual string N_COLUMN_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 标题
        /// </summary>		
        public virtual string VC_TITLE
        {
            get;
            set;
        }
        /// <summary>
        /// 关键字
        /// </summary>		
        public virtual string VC_KEYWORDS
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
        /// 添加时间
        /// </summary>		
        public virtual DateTime DT_ADD_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// 更新时间
        /// </summary>		
        public virtual DateTime DT_UPDATE_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// 添加人
        /// </summary>		
        public virtual string N_ADD_OP_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 修改人
        /// </summary>		
        public virtual string N_UPDATE_OP_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 附件地址
        /// </summary>		
        public virtual string VC_ENCLOSURE_URL
        {
            get;
            set;
        }
        /// <summary>
        /// 推荐等级
        /// </summary>		
        public virtual string C_RECOMMEND_LEVEL
        {
            get;
            set;
        }
        /// <summary>
        /// 推荐等级
        /// </summary>		
        public virtual string VC_IMG_URL
        {
            get;
            set;
        }
        /// <summary>
        /// 点击量
        /// </summary>		
        public virtual int N_HITS
        {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>		
        public virtual string C_STATUS
        {
            get;
            set;
        }
        /// <summary>
        /// 审核状态 0未审核1一级审核2二级审核
        /// </summary>		
        public virtual string C_VERIFY_STATUS
        {
            get;
            set;
        }
        /// <summary>
        /// 是否图片新闻
        /// </summary>		
        public virtual bool B_IMG_NEWS
        {
            get;
            set;
        }
        /// <summary>
        /// 点赞数
        /// </summary>		
        public virtual int N_LIKES
        {
            get;
            set;
        }

        #region 扩展
        public virtual SYS_UserEntity OPADD { get; set; }
        public virtual SYS_UserEntity OPUPDATE { get; set; }
        #endregion
    }
}
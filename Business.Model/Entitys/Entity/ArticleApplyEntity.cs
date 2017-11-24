using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Nhibernate Code Generation Template 1.0
//author:MythXin
//blog:www.cnblogs.com/MythXin
//Entity Code Generation Template
namespace Business.Model.Entitys.Entity
{
    //T_ARTICLE_APPLY
    public class ArticleApplyEntity : AggregateRoot
    {

        /// <summary>
        /// N_APPLY_ID
        /// </summary>
        //public virtual string N_APPLY_ID
        //{
        //    get;
        //    set;
        //}
        /// <summary>
        /// N_ARTICLE_ID
        /// </summary>
        public virtual string N_ARTICLE_ID
        {
            get;
            set;
        }
        /// <summary>
        /// VC_APPLYER_NAME
        /// </summary>
        public virtual string VC_APPLYER_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// VC_APPLYER_IDCARD
        /// </summary>
        public virtual string VC_APPLYER_IDCARD
        {
            get;
            set;
        }
        /// <summary>
        /// VC_APPLYER_PHONE
        /// </summary>
        public virtual string VC_APPLYER_PHONE
        {
            get;
            set;
        }
        /// <summary>
        /// VC_APPLYER_EMAIL
        /// </summary>
        public virtual string VC_APPLYER_EMAIL
        {
            get;
            set;
        }
        /// <summary>
        /// VC_APPLYER_UNIT
        /// </summary>
        public virtual string VC_APPLYER_UNIT
        {
            get;
            set;
        }
        /// <summary>
        /// VC_APPLYER_ADDRESS
        /// </summary>
        public virtual string VC_APPLYER_ADDRESS
        {
            get;
            set;
        }
        /// <summary>
        /// C_APPLY_TYPE
        /// </summary>
        public virtual string C_APPLY_TYPE
        {
            get;
            set;
        }
        /// <summary>
        /// C_RESULT_TYPE
        /// </summary>
        public virtual string C_RESULT_TYPE
        {
            get;
            set;
        }
        /// <summary>
        /// C_DATA_TYPE
        /// </summary>
        public virtual string C_DATA_TYPE
        {
            get;
            set;
        }
        /// <summary>
        /// DT_APPLY_TIME
        /// </summary>
        public virtual DateTime? DT_APPLY_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// VC_APPLY_MEMO
        /// </summary>
        public virtual string VC_APPLY_MEMO
        {
            get;
            set;
        }
        /// <summary>
        /// VC_CHECKER_ID
        /// </summary>
        public virtual string VC_CHECKER_ID
        {
            get;
            set;
        }
        /// <summary>
        /// DT_CHECK_TIME
        /// </summary>
        public virtual DateTime? DT_CHECK_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// VC_CHECK_MEMO
        /// </summary>
        public virtual string VC_CHECK_MEMO
        {
            get;
            set;
        }
        /// <summary>
        /// C_CHECK_STATUS
        /// </summary>
        public virtual string C_CHECK_STATUS
        {
            get;
            set;
        }
        /// <summary>
        /// VC_APPLY_FILES
        /// </summary>
        public virtual string VC_APPLY_FILES
        {
            get;
            set;
        }

    }
}
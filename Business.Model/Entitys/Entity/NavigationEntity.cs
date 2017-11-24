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
    public class NavigationEntity : AggregateRoot
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
        /// VC_TEXT
        /// </summary>
        public virtual string VC_NAVIGATION_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// VC_IMAGE
        /// </summary>
        public virtual string VC_IMAGE
        {
            get;
            set;
        }
        /// <summary>
        /// VC_VEDIO
        /// </summary>
        public virtual string VC_VEDIO
        {
            get;
            set;
        }
        /// <summary>
        /// VC_LINK
        /// </summary>
        public virtual string VC_LINK
        {
            get;
            set;
        }
        /// <summary>
        /// VC_TARGET
        /// </summary>
        public virtual string VC_TARGET
        {
            get;
            set;
        }
        /// <summary>
        /// N_SUPER_NAVIGATION_ID
        /// </summary>
        public virtual string N_SUPER_NAVIGATION_ID
        {
            get;
            set;
        }
        /// <summary>
        /// N_ORDER_NO
        /// </summary>
        public virtual int N_ORDER_NO
        {
            get;
            set;
        }

        #region 扩展
        #endregion
    }
}
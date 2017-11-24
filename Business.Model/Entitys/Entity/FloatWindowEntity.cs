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
    public class FloatWindowEntity : AggregateRoot
    {

        /// <summary>
        /// N_EVENT_ID
        /// </summary>
        //public virtual string N_EVENT_ID
        //{
        //    get;
        //    set;
        //}
        /// <summary>
        /// VC_TITLE
        /// </summary>
        public virtual string VC_TITLE
        {
            get;
            set;
        }
        /// <summary>
        /// VC_IMG_URL
        /// </summary>
        public virtual string VC_IMG_URL
        {
            get;
            set;
        }
        /// <summary>
        /// VC_TARGET_URL
        /// </summary>
        public virtual string VC_TARGET_URL
        {
            get;
            set;
        }
        /// <summary>
        /// C_START_POSITION
        /// </summary>
        public virtual string C_START_POSITION
        {
            get;
            set;
        }

        /// <summary>
        /// N_SPEED
        /// </summary>
        public virtual int N_SPEED
        {
            get;
            set;
        }
        /// <summary>
        /// DT_OP_TIME
        /// </summary>
        public virtual DateTime? DT_OP_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// N_OP_ID
        /// </summary>
        public virtual string VC_OP_NAME
        {
            get;
            set;
        }

        /// <summary>
        /// C_STATUS
        /// </summary>
        public virtual string C_STATUS
        {
            get;
            set;
        }
    }
}
using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Business.Model.Entitys.Entity
{
    //OperatorEntity
    [Serializable]
    public class SYS_UserEntity : AggregateRoot
    {
        /// <summary>
        /// UserLoginName
        /// </summary>
        public virtual string UserLoginName
        {
            get;
            set;
        }
        /// <summary>
        /// UserDisplayName
        /// </summary>
        public virtual string UserDisplayName
        {
            get;
            set;
        }
        /// <summary>
        /// UserPassword
        /// </summary>
        public virtual string UserPassword
        {
            get;
            set;
        }
        /// <summary>
        /// UserType
        /// </summary>
        public virtual int? UserType
        {
            get;
            set;
        }
        /// <summary>
        /// UserPhone
        /// </summary>
        public virtual string UserPhone
        {
            get;
            set;
        }
        /// <summary>
        /// RecordStatus
        /// </summary>
        public virtual int? RecordStatus
        {
            get;
            set;
        }
        /// <summary>
        /// Extend1
        /// </summary>
        public virtual string Extend1
        {
            get;
            set;
        }
        /// <summary>
        /// Extend2
        /// </summary>
        public virtual string Extend2
        {
            get;
            set;
        }
        /// <summary>
        /// Extend3
        /// </summary>
        public virtual string Extend3
        {
            get;
            set;
        }
        /// <summary>
        /// Extend4
        /// </summary>
        public virtual string Extend4
        {
            get;
            set;
        }
        /// <summary>
        /// Extend5
        /// </summary>
        public virtual string Extend5
        {
            get;
            set;
        }     
    }
}
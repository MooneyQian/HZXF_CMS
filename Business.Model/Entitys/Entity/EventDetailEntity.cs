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
    public class EventDetailEntity : AggregateRoot
	{
	
      	/// <summary>
		/// N_EVENT_DETAIL_ID
        /// </summary>
        //public virtual string N_EVENT_DETAIL_ID
        //{
        //    get; 
        //    set; 
        //}        
		/// <summary>
		/// N_EVENT_ID
        /// </summary>
        public virtual string N_EVENT_ID
        {
            get; 
            set; 
        }        
		/// <summary>
		/// VC_TITLE
        /// </summary>
        public virtual string VC_TITLE
        {
            get; 
            set; 
        }        
		/// <summary>
		/// VC_CONTENT
        /// </summary>
        public virtual string VC_CONTENT
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
		/// N_OP_ID
        /// </summary>
        public virtual string N_OP_ID
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
		   
	}
}
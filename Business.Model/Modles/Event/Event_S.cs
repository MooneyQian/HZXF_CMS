using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Business.Model.Models
{
    //T_EVENT
    [Serializable]
    public class Event_S : BaseModel
    {

        /// <summary>
        /// N_EVENT_ID
        /// </summary>		
        //private string _n_event_id;
        //public string N_EVENT_ID
        //{
        //    get { return _n_event_id; }
        //    set { _n_event_id = value; }
        //}
        /// <summary>
        /// VC_TITLE
        /// </summary>		
        private string _vc_title;
        public string VC_TITLE
        {
            get { return _vc_title; }
            set { _vc_title = value; }
        }
        /// <summary>
        /// VC_CONTENT
        /// </summary>		
        private string _vc_content;
        public string VC_CONTENT
        {
            get { return _vc_content; }
            set { _vc_content = value; }
        }
        /// <summary>
        /// N_OP_ID
        /// </summary>		
        private string _n_op_id;
        public string N_OP_ID
        {
            get { return _n_op_id; }
            set { _n_op_id = value; }
        }
        /// <summary>
        /// DT_OP_TIME
        /// </summary>		
        private DateTime _dt_op_time;
        public DateTime DT_OP_TIME
        {
            get { return _dt_op_time; }
            set { _dt_op_time = value; }
        }
        /// <summary>
        /// VC_IMG_URL
        /// </summary>		
        private string _vc_img_url;
        public string VC_IMG_URL
        {
            get { return _vc_img_url; }
            set { _vc_img_url = value; }
        }
        /// <summary>
        /// C_STATUS
        /// </summary>		
        private string _c_status;
        public string C_STATUS
        {
            get { return _c_status; }
            set { _c_status = value; }
        }
        #region 扩展
        /// <summary>
        /// 开始时间
        /// </summary>		
        private DateTime? _n_start_date;
        public DateTime? N_START_DATE
        {
            get { return _n_start_date; }
            set { _n_start_date = value; }
        }

        /// <summary>
        /// 结束时间
        /// </summary>		
        private DateTime? _n_end_date;
        public DateTime? N_END_DATE
        {
            get { return _n_end_date; }
            set { _n_end_date = value; }
        }
        /// <summary>
        /// 操作人
        /// </summary>		
        private string _vc_op_name;
        public string VC_OP_NAME
        {
            get { return _vc_op_name; }
            set { _vc_op_name = value; }
        }
        public List<EventDetail_S> listEventDetail { get; set; }

        public Event_S prevEvent { get; set; }
        public Event_S nextEvent { get; set; }
        #endregion
    }
}


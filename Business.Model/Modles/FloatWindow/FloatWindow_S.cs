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
    public class FloatWindow_S : BaseModel
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
        /// VC_IMG_URL
        /// </summary>		
        private string _vc_img_url;
        public string VC_IMG_URL
        {
            get { return _vc_img_url; }
            set { _vc_img_url = value; }
        }
        /// <summary>
        /// VC_TARGET_URL
        /// </summary>		
        private string _vc_target_url;
        public string VC_TARGET_URL
        {
            get { return _vc_target_url; }
            set { _vc_target_url = value; }
        }
        /// <summary>
        /// C_START_POSITION
        /// </summary>		
        private string _c_start_position;
        public string C_START_POSITION
        {
            get { return _c_start_position; }
            set { _c_start_position = value; }
        }
        /// <summary>
        /// N_SPEED
        /// </summary>		
        private int _n_speed;
        public int N_SPEED
        {
            get { return _n_speed; }
            set { _n_speed = value; }
        }
        /// <summary>
        /// VC_OP_NAME
        /// </summary>		
        private string _vc_op_name;
        public string VC_OP_NAME
        {
            get { return _vc_op_name; }
            set { _vc_op_name = value; }
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
        /// VC_START_POSITION
        /// </summary>		
        private string _vc_start_position;
        public string VC_START_POSITION
        {
            get { return _vc_start_position; }
            set { _vc_start_position = value; }
        }
        #endregion
    }
}


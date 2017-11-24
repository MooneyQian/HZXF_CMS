using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Business.Model.Models
{
    /// <summary>
    /// 
    /// <summary>
    [Serializable]
    public class EmailRecord_S : BaseModel
    {
        /// <summary>
        /// 标题
        /// </summary>		
        private string _vc_title;
        public string VC_TITLE
        {
            get { return _vc_title; }
            set { _vc_title = value; }
        }
        /// <summary>
        /// 内容
        /// </summary>		
        private string _vc_content;
        public string VC_CONTENT
        {
            get { return _vc_content; }
            set { _vc_content = value; }
        }
        /// <summary>
        /// IP地址
        /// </summary>		
        private string _vc_ip_address;
        public string VC_IP_ADDRESS
        {
            get { return _vc_ip_address; }
            set { _vc_ip_address = value; }
        }
        /// <summary>
        /// 时间
        /// </summary>		
        private DateTime? _dt_time;
        public DateTime? DT_TIME
        {
            get { return _dt_time; }
            set { _dt_time = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>		
        private string _vc_name;
        public string VC_NAME
        {
            get { return _vc_name; }
            set { _vc_name = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>		
        private string _vc_phone;
        public string VC_PHONE
        {
            get { return _vc_phone; }
            set { _vc_phone = value; }
        }
        /// <summary>
        /// 邮件类型 1局长信箱2我要留言
        /// </summary>		
        private string _c_email_type;
        public string C_EMAIL_TYPE
        {
            get { return _c_email_type; }
            set { _c_email_type = value; }
        }
        /// <summary>
        /// 审核时间
        /// </summary>		
        private DateTime? _dt_verify_time;
        public DateTime? DT_VERIFY_TIME
        {
            get { return _dt_verify_time; }
            set { _dt_verify_time = value; }
        }
        /// <summary>
        /// 回复时间
        /// </summary>		
        private DateTime? _dt_reply_time;
        public DateTime? DT_REPLY_TIME
        {
            get { return _dt_reply_time; }
            set { _dt_reply_time = value; }
        }
        /// <summary>
        /// 回复人姓名
        /// </summary>		
        private string _vc_replyer;
        public string VC_REPLYER
        {
            get { return _vc_replyer; }
            set { _vc_replyer = value; }
        }
        /// <summary>
        /// 回复内容
        /// </summary>		
        private string _vc_reply_content;
        public string VC_REPLY_CONTENT
        {
            get { return _vc_reply_content; }
            set { _vc_reply_content = value; }
        }
        /// <summary>
        /// 状态0未审核 1已审核2已回复
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
        #endregion
    }
}
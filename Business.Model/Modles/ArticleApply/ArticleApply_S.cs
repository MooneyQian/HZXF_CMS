using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Business.Model.Models
{
    //T_ARTICLE_APPLY
    public class ArticleApply_S : BaseModel
    {

        /// <summary>
        /// N_APPLY_ID
        /// </summary>		
        //private string _n_apply_id;
        //public string N_APPLY_ID
        //{
        //    get { return _n_apply_id; }
        //    set { _n_apply_id = value; }
        //}
        /// <summary>
        /// N_ARTICLE_ID
        /// </summary>		
        private string _n_article_id;
        public string N_ARTICLE_ID
        {
            get { return _n_article_id; }
            set { _n_article_id = value; }
        }
        /// <summary>
        /// VC_APPLYER_NAME
        /// </summary>		
        private string _vc_applyer_name;
        public string VC_APPLYER_NAME
        {
            get { return _vc_applyer_name; }
            set { _vc_applyer_name = value; }
        }
        /// <summary>
        /// VC_APPLYER_IDCARD
        /// </summary>		
        private string _vc_applyer_idcard;
        public string VC_APPLYER_IDCARD
        {
            get { return _vc_applyer_idcard; }
            set { _vc_applyer_idcard = value; }
        }
        /// <summary>
        /// VC_APPLYER_PHONE
        /// </summary>		
        private string _vc_applyer_phone;
        public string VC_APPLYER_PHONE
        {
            get { return _vc_applyer_phone; }
            set { _vc_applyer_phone = value; }
        }
        /// <summary>
        /// VC_APPLYER_EMAIL
        /// </summary>		
        private string _vc_applyer_email;
        public string VC_APPLYER_EMAIL
        {
            get { return _vc_applyer_email; }
            set { _vc_applyer_email = value; }
        }
        /// <summary>
        /// VC_APPLYER_UNIT
        /// </summary>		
        private string _vc_applyer_unit;
        public string VC_APPLYER_UNIT
        {
            get { return _vc_applyer_unit; }
            set { _vc_applyer_unit = value; }
        }
        /// <summary>
        /// VC_APPLYER_ADDRESS
        /// </summary>		
        private string _vc_applyer_address;
        public string VC_APPLYER_ADDRESS
        {
            get { return _vc_applyer_address; }
            set { _vc_applyer_address = value; }
        }
        /// <summary>
        /// C_APPLY_TYPE
        /// </summary>		
        private string _c_apply_type;
        public string C_APPLY_TYPE
        {
            get { return _c_apply_type; }
            set { _c_apply_type = value; }
        }
        /// <summary>
        /// C_RESULT_TYPE
        /// </summary>		
        private string _c_result_type;
        public string C_RESULT_TYPE
        {
            get { return _c_result_type; }
            set { _c_result_type = value; }
        }
        /// <summary>
        /// C_DATA_TYPE
        /// </summary>		
        private string _c_data_type;
        public string C_DATA_TYPE
        {
            get { return _c_data_type; }
            set { _c_data_type = value; }
        }
        /// <summary>
        /// DT_APPLY_TIME
        /// </summary>		
        private DateTime? _dt_apply_time;
        public DateTime? DT_APPLY_TIME
        {
            get { return _dt_apply_time; }
            set { _dt_apply_time = value; }
        }
        /// <summary>
        /// VC_APPLY_MEMO
        /// </summary>		
        private string _vc_apply_memo;
        public string VC_APPLY_MEMO
        {
            get { return _vc_apply_memo; }
            set { _vc_apply_memo = value; }
        }
        /// <summary>
        /// VC_CHECKER_ID
        /// </summary>		
        private string _vc_checker_id;
        public string VC_CHECKER_ID
        {
            get { return _vc_checker_id; }
            set { _vc_checker_id = value; }
        }
        /// <summary>
        /// DT_CHECK_TIME
        /// </summary>		
        private DateTime? _dt_check_time;
        public DateTime? DT_CHECK_TIME
        {
            get { return _dt_check_time; }
            set { _dt_check_time = value; }
        }
        /// <summary>
        /// VC_CHECK_MEMO
        /// </summary>		
        private string _vc_check_memo;
        public string VC_CHECK_MEMO
        {
            get { return _vc_check_memo; }
            set { _vc_check_memo = value; }
        }
        /// <summary>
        /// C_CHECK_STATUS
        /// </summary>		
        private string _c_check_status;
        public string C_CHECK_STATUS
        {
            get { return _c_check_status; }
            set { _c_check_status = value; }
        }
        /// <summary>
        /// VC_APPLY_FILES
        /// </summary>		
        private string _vc_apply_files;
        public string VC_APPLY_FILES
        {
            get { return _vc_apply_files; }
            set { _vc_apply_files = value; }
        }
        #region 扩展
        /// <summary>
        /// VC_ARTICLE_NAME
        /// </summary>		
        private string _vc_article_name;
        public string VC_ARTICLE_NAME
        {
            get { return _vc_article_name; }
            set { _vc_article_name = value; }
        }
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
        /// VC_CHECKER_NAME
        /// </summary>		
        private string _vc_checker_name;
        public string VC_CHECKER_NAME
        {
            get { return _vc_checker_name; }
            set { _vc_checker_name = value; }
        }
        #endregion
    }
}


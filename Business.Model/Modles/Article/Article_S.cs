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
    public class Article_S : BaseModel
    {
        /// <summary>
        /// 所属栏目ID
        /// </summary>		
        private string _n_column_id;
        public string N_COLUMN_ID
        {
            get { return _n_column_id; }
            set { _n_column_id = value; }
        }
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
        /// 关键字
        /// </summary>		
        private string _vc_keywords;
        public string VC_KEYWORDS
        {
            get { return _vc_keywords; }
            set { _vc_keywords = value; }
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
        /// 添加时间
        /// </summary>		
        private DateTime _dt_add_time;
        public DateTime DT_ADD_TIME
        {
            get { return _dt_add_time; }
            set { _dt_add_time = value; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>		
        /// 
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日 HH:mm:ss}")]
        private DateTime _dt_update_time;
        public DateTime DT_UPDATE_TIME
        {
            get { return _dt_update_time; }
            set { _dt_update_time = value; }
        }
        /// <summary>
        /// 添加人
        /// </summary>		
        private string _n_add_op_id;
        public string N_ADD_OP_ID
        {
            get { return _n_add_op_id; }
            set { _n_add_op_id = value; }
        }
        /// <summary>
        /// 修改人
        /// </summary>		
        private string _n_update_op_id;
        public string N_UPDATE_OP_ID
        {
            get { return _n_update_op_id; }
            set { _n_update_op_id = value; }
        }
        /// <summary>
        /// 附件地址
        /// </summary>		
        private string _vc_enclosure_url;
        public string VC_ENCLOSURE_URL
        {
            get { return _vc_enclosure_url; }
            set { _vc_enclosure_url = value; }
        }
        /// <summary>
        /// 推荐等级
        /// </summary>		
        private string _c_recommend_level;
        public string C_RECOMMEND_LEVEL
        {
            get { return _c_recommend_level; }
            set { _c_recommend_level = value; }
        }
        /// <summary>
        /// 推荐等级
        /// </summary>		
        private string _vc_img_url;
        public string VC_IMG_URL
        {
            get { return _vc_img_url; }
            set { _vc_img_url = value; }
        }
        /// <summary>
        /// 点击数
        /// </summary>		
        private int _n_hits;
        public int N_HITS
        {
            get { return _n_hits; }
            set { _n_hits = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>		
        private string _c_status;
        public string C_STATUS
        {
            get { return _c_status; }
            set { _c_status = value; }
        }
        /// <summary>
        /// 审核状态 0未审核1一级审核2二级审核
        /// </summary>		
        private string _c_verify_status;
        public string C_VERIFY_STATUS
        {
            get { return _c_verify_status; }
            set { _c_verify_status = value; }
        }
        /// <summary>
        /// 是否图片新闻
        /// </summary>		
        private bool _b_img_news;
        public bool B_IMG_NEWS
        {
            get { return _b_img_news; }
            set { _b_img_news = value; }
        }
        /// <summary>
        /// 点赞数
        /// </summary>		
        private int _n_likes;
        public int N_LIKES
        {
            get { return _n_likes; }
            set { _n_likes = value; }
        }

        #region 扩展
        /// <summary>
        /// 栏目名称
        /// </summary>		
        private string _vc_column_name;
        public string VC_COLUMN_NAME
        {
            get { return _vc_column_name; }
            set { _vc_column_name = value; }
        }
        /// <summary>
        /// 添加人
        /// </summary>		
        private string _vc_add_op_name;
        public string VC_ADD_OP_NAME
        {
            get { return _vc_add_op_name; }
            set { _vc_add_op_name = value; }
        }
        /// <summary>
        /// 修改人
        /// </summary>		
        private string _vc_update_op_name;
        public string VC_UPDATE_OP_NAME
        {
            get { return _vc_update_op_name; }
            set { _vc_update_op_name = value; }
        }
        /// <summary>
        /// 编辑器内容
        /// </summary>		
        private string _editorValue;
        public string editorValue
        {
            get { return _editorValue; }
            set { _editorValue = value; }
        }
        /// <summary>
        /// 推荐等级
        /// </summary>		
        private string _vc_recommend_name;
        public string VC_RECOMMEND_NAME
        {
            get { return _vc_recommend_name; }
            set { _vc_recommend_name = value; }
        }
        /// <summary>
        /// 推荐等级
        /// </summary>		
        private string _vc_update_show;
        public string VC_UPDATE_SHOW
        {
            get { return _vc_update_show; }
            set { _vc_update_show = value; }
        }
        /// <summary>
        /// 所有子栏目
        /// </summary>		
        private string _vc_columnids;
        public string VC_COLUMNIDS
        {
            get { return _vc_columnids; }
            set { _vc_columnids = value; }
        }
        /// <summary>
        /// 是否一周热点
        /// </summary>		
        private bool _b_hotpoints;
        public bool B_HOTPOINTS
        {
            get { return _b_hotpoints; }
            set { _b_hotpoints = value; }
        }
        #endregion

        private int rowid;

        public int Rowid
        {
            get { return rowid; }
            set { rowid = value; }
        }
    }
}
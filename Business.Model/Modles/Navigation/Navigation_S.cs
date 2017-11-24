using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Model.Models
{
    /// <summary>
    /// 
    /// <summary>
    [Serializable]
    public class Navigation_S : BaseModel
    {
        /// <summary>
        /// N_COLUMN_ID
        /// </summary>		
        private string _n_column_id;
        public string N_COLUMN_ID
        {
            get { return _n_column_id; }
            set { _n_column_id = value; }
        }
        /// <summary>
        /// VC_NAVIGATION_NAME
        /// </summary>		
        private string _vc_navigation_name;
        public string VC_NAVIGATION_NAME
        {
            get { return _vc_navigation_name; }
            set { _vc_navigation_name = value; }
        }
        /// <summary>
        /// VC_IMAGE
        /// </summary>		
        private string _vc_image;
        public string VC_IMAGE
        {
            get { return _vc_image; }
            set { _vc_image = value; }
        }
        /// <summary>
        /// VC_VEDIO
        /// </summary>		
        private string _vc_vedio;
        public string VC_VEDIO
        {
            get { return _vc_vedio; }
            set { _vc_vedio = value; }
        }
        /// <summary>
        /// VC_LINK
        /// </summary>		
        private string _vc_link;
        public string VC_LINK
        {
            get { return _vc_link; }
            set { _vc_link = value; }
        }
        /// <summary>
        /// VC_TARGET
        /// </summary>		
        private string _vc_target;
        public string VC_TARGET
        {
            get { return _vc_target; }
            set { _vc_target = value; }
        }
        /// <summary>
        /// N_SUPER_NAVIGATION_ID
        /// </summary>		
        private string _n_super_navigation_id;
        public string N_SUPER_NAVIGATION_ID
        {
            get { return _n_super_navigation_id; }
            set { _n_super_navigation_id = value; }
        }
        /// <summary>
        /// Extend1
        /// </summary>		
        private int _n_order_no;
        public int N_ORDER_NO
        {
            get { return _n_order_no; }
            set { _n_order_no = value; }
        }


        #region
        /// <summary>
        /// VC_COLUMN_NAME
        /// </summary>		
        private string _vc_column_name;
        public string VC_COLUMN_NAME
        {
            get { return _vc_column_name; }
            set { _vc_column_name = value; }
        }
        /// <summary>
        /// VC_NAVIGATION_NAME
        /// </summary>		
        private string _vc_super_navigation_name;
        public string VC_SUPER_NAVIGATION_NAME
        {
            get { return _vc_super_navigation_name; }
            set { _vc_super_navigation_name = value; }
        }
        public List<Navigation_S> ChildrenList { get; set; }
        #endregion
    }
}
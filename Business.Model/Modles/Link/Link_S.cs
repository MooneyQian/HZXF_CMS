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
    public class Link_S : BaseModel
    {
        private string _N_LINK_ID;

        public string N_LINK_ID
        {
            get { return _N_LINK_ID; }
            set { _N_LINK_ID = value; }
        }
        private string _VC_LINK_NAME;

        public string VC_LINK_NAME
        {
            get { return _VC_LINK_NAME; }
            set { _VC_LINK_NAME = value; }
        }
        private string _VC_LINK_URL;

        public string VC_LINK_URL
        {
            get { return _VC_LINK_URL; }
            set { _VC_LINK_URL = value; }
        }
        private string _C_LINK_TYPE;

        public string C_LINK_TYPE
        {
            get { return _C_LINK_TYPE; }
            set { _C_LINK_TYPE = value; }
        }
        private string _N_COLUMN_ID;

        public string N_COLUMN_ID
        {
            get { return _N_COLUMN_ID; }
            set { _N_COLUMN_ID = value; }
        }
        private string _VC_IMG_URL;

        public string VC_IMG_URL
        {
            get { return _VC_IMG_URL; }
            set { _VC_IMG_URL = value; }
        }
        private string _VC_VEDIO_URL;

        public string VC_VEDIO_URL
        {
            get { return _VC_VEDIO_URL; }
            set { _VC_VEDIO_URL = value; }
        }
        private string _N_OP_ID;

        public string N_OP_ID
        {
            get { return _N_OP_ID; }
            set { _N_OP_ID = value; }
        }
        private DateTime _DT_OP_TIME;

        public DateTime DT_OP_TIME
        {
            get { return _DT_OP_TIME; }
            set { _DT_OP_TIME = value; }
        }

    }
}
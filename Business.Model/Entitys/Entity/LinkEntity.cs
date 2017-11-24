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
    public class LinkEntity : AggregateRoot
    {
        public virtual string N_LINK_ID { get; set; }
        public virtual string VC_LINK_NAME { get; set; }
        public virtual string VC_LINK_URL { get; set; }
        public virtual string C_LINK_TYPE { get; set; }
        public virtual string N_COLUMN_ID { get; set; }
        public virtual string VC_IMG_URL { get; set; }
        public virtual string VC_VEDIO_URL { get; set; }
        public virtual string N_OP_ID { get; set; }
        public virtual DateTime DT_OP_TIME { get; set; }
    }
}
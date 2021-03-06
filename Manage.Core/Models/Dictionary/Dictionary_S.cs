﻿using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manage.Core.Models
{
    /// <summary>
    /// 系统字典表
    /// </summary>
    [Serializable]
    [System.ComponentModel.Description("系统字典表")]
    public class Dictionary_S : BaseModel
    {
        /// <summary>
        /// 父节点ID，0为顶层
        /// </summary>
        public string ParDictID { get; set; }

        /// <summary>
        /// 字典类型
        /// </summary>
        public string DictType { get; set; }

        /// <summary>
        /// 字典名
        /// </summary>
        public string DictName { get; set; }

        /// <summary>
        /// 字典编号
        /// </summary>
        public string DictCode { get; set; }

        /// <summary>
        /// 字典描述
        /// </summary>
        public string DictDesc { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        public int? LevelNO { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? DictOrder { get; set; }

        /// <summary>
        /// 是否缓存 1：是 0否
        /// </summary>
        public int? IsCache { get; set; }

        #region 扩展

        /// <summary>
        /// 父节点名称
        /// </summary>
        public string ParDictName { get; set; }

        /// <summary>
        /// 父节点编码
        /// </summary>
        public string ParDictCode { get; set; }

        /// <summary>
        /// 营养成分计量
        /// </summary>
        public decimal N_COMPOSITION_AMOUNT { get; set; }
        #endregion
    }
}

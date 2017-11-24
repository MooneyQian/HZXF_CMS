using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// 用户类型
    /// </summary>
    public enum EMUSERTYPE
    {
        超级管理员 = 0,
        管理员 = 2,
        用户 = 1,
        匿名用户 = 3
    }

    public enum EMRECOMMENDLEVEL
    {
        正常 = 1,
        推荐 = 2,
        强烈推荐 = 3
    }

    public enum EMHITTYPE
    {
        点击量 = 0,
        点赞数 = 1
    }
    public enum EMEMAILSTATUS
    {
        未审核 = 0,
        已审核 = 1,
        已回复 = 2
    }
    public enum EMEMAILTYPE
    {
        局长信箱 = 1,
        我要留言 = 2
    }
    public enum EMSTATUS
    {
        历史 = 0,
        在用 = 1
    }
    /// <summary>
    /// 统计报表，查询类型
    /// </summary>
    public enum SEARCHTYPE
    {
        按季度 = 1,
        按时间 = 2
    }
    /// <summary>
    /// 标记
    /// </summary>
    public enum EMFLAG
    {
        全部 = -1,
        未标记 = 0,
        已标记 = 1
    }
    /// <summary>
    /// 申请类型
    /// </summary>
    public enum EMAPPLYTYPE
    {
        个人 = 1,
        单位 = 2
    }
    /// <summary>
    /// 结果类型
    /// </summary>
    public enum EMRESULTTYPE
    {
        邮件 = 1
    }
    /// <summary>
    /// 档案类型
    /// </summary>
    public enum EMDATATYPE
    {
        开放档案 = 0
    }
    /// <summary>
    /// 审核标志
    /// </summary>
    public enum EMCHECKSTATUS
    {
        未审核 = 0,
        审核通过 = 1,
        审核不通过 = 2
    }
    /// <summary>
    /// 文章状态 0 未审核 1 一级审核 2 二级审核
    /// </summary>
    public enum EMARTICLESTATUS
    {
        未审核 = 0,
        一级审核 = 1,
        二级审核 = 2,
        初审不通过 = 3,
        复审不通过 = 4
    }
    /// <summary>
    /// 浮窗起始位置
    /// </summary>
    public enum EMSTARTPOSITION
    {
        左上 = 1,
        右上 = 2,
        左下 = 3,
        右下 = 4
    }
}

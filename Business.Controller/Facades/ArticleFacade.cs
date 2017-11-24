
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Manage.Framework;
using Business.Model.Entitys.Entity;
using Business.Model.Models;
using Manage.Open;
using System.Data;
using Manage.Core.Models;
using Manage.SSO.Entity;
using Manage.Core.Entitys;
using Business.Controller.Common;
using System.IO;

namespace Business.Controller.Facades
{

    public class ArticleFacade : BaseFacade<ArticleEntity>, IArticleFacade
    {
        #region 链接方法
        /// <summary>
        /// 得到链接类型地址
        /// 3国内档案网站 4省内档案网站 5热门网站
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public List<Link_S> GetAllLinks(string typeId)
        {
            using (var factory = new BaseAccess())
            {
                List<Orderby<LinkEntity>> orders = new List<Orderby<LinkEntity>>()
                {
                    new Orderby<LinkEntity>(c => c.DT_OP_TIME, SortOrder.Descending)
                };

                var spec = Specification<LinkEntity>.Create(c => c.C_LINK_TYPE == typeId);
                var list = factory.GetAll<LinkEntity>(spec, orders)
                    .Adapter<LinkEntity, Link_S>(new List<Link_S>());
                return list;
            }
        }
        #endregion

        /// <summary>
        /// 获取所有菜单（除管理员菜单）
        /// </summary>
        /// <returns></returns>
        public List<Article_S> GetAllArticles(string ColumnId)
        {
            using (var factory = new BaseAccess())
            {
                List<Orderby<ArticleEntity>> orders = new List<Orderby<ArticleEntity>>()
                {
                    new Orderby<ArticleEntity>(c => c.DT_ADD_TIME, SortOrder.Descending)
                };
                var Column = factory.GetSingle<MenuEntity>(Specification<MenuEntity>.Create(c => c.MenuCode == ColumnId));
                var spec = Specification<ArticleEntity>.Create(c => c.N_COLUMN_ID == ColumnId);
                spec &= Specification<ArticleEntity>.Create(c => c.C_STATUS == "1");
                var list = factory.GetAll<ArticleEntity>(spec, orders)
                    .Adapter<ArticleEntity, Article_S>(new List<Article_S>());
                return list;
            }
        }

        /// <summary>
        /// 分页获取文章
        /// </summary>
        /// <returns></returns>
        public List<Article_S> GetArticlesPaged(Article_S model, PageInfo pi)
        {
            using (var factory = new BaseAccess())
            {
              
                    List<Orderby<ArticleEntity>> orders = new List<Orderby<ArticleEntity>>()
                {
                    new Orderby<ArticleEntity>(c => c.DT_ADD_TIME, SortOrder.Descending)
                };
                    var spec = Specification<ArticleEntity>.Create(c => true);
                    if (!string.IsNullOrEmpty(model.C_STATUS))
                    {
                        spec &= Specification<ArticleEntity>.Create(c => c.C_STATUS == model.C_STATUS);
                    }
                    if (!string.IsNullOrEmpty(model.C_VERIFY_STATUS))
                    {
                        spec &= Specification<ArticleEntity>.Create(c => c.C_VERIFY_STATUS == model.C_VERIFY_STATUS);
                    }
                    else
                        spec &= Specification<ArticleEntity>.Create(c => c.C_VERIFY_STATUS == ((int)EMARTICLESTATUS.二级审核).ToString());
                    if (!string.IsNullOrEmpty(model.N_COLUMN_ID))
                    {
                        if (model.N_COLUMN_ID == "999")
                        {
                            spec &= Specification<ArticleEntity>.Create(c => c.DT_ADD_TIME > DateTime.Now.AddDays(-7));
                            orders = new List<Orderby<ArticleEntity>>()
                {
                    new Orderby<ArticleEntity>(c => c.N_HITS, SortOrder.Descending),
                    new Orderby<ArticleEntity>(c => c.DT_ADD_TIME, SortOrder.Descending)
                };
                        }
                        else
                            spec &= Specification<ArticleEntity>.Create(c => c.N_COLUMN_ID.Contains(model.N_COLUMN_ID));
                    }
                    else if (!string.IsNullOrEmpty(model.VC_KEYWORDS))
                    {
                        spec &= (Specification<ArticleEntity>.Create(c => c.VC_KEYWORDS.Contains(model.VC_KEYWORDS)) || Specification<ArticleEntity>.Create(c => c.VC_TITLE.Contains(model.VC_KEYWORDS)) || Specification<ArticleEntity>.Create(c => c.VC_CONTENT.Contains(model.VC_KEYWORDS)));
                    }
                    if (!string.IsNullOrEmpty(model.VC_TITLE))
                    {
                        spec &= Specification<ArticleEntity>.Create(c => c.VC_TITLE.Contains(model.VC_TITLE));
                    }

                    var list = factory.GetPage<ArticleEntity>(pi, spec, orders);
                    List<Article_S> modellist = new List<Article_S>();
                    foreach (var item in list)
                    {
                        if (item.N_COLUMN_ID == "0")
                            continue;
                        var modelitem = item.Adapter<Article_S>(new Article_S());
                        var column = factory.GetSingle<MenuEntity>(Specification<MenuEntity>.Create(m => m.MenuCode == item.N_COLUMN_ID));
                        if (column != null)
                            modelitem.VC_COLUMN_NAME = column.MenuName;
                        modelitem.VC_ADD_OP_NAME = item.OPADD == null ? "未知" : item.OPADD.UserDisplayName;
                        modelitem.VC_UPDATE_OP_NAME = item.OPUPDATE == null ? "未知" : item.OPUPDATE.UserDisplayName;
                        modelitem.VC_RECOMMEND_NAME = Enum.GetName(typeof(EMRECOMMENDLEVEL), (item.C_RECOMMEND_LEVEL).Convert<int>(1));
                        if (model.N_COLUMN_ID == "999")
                            modelitem.B_HOTPOINTS = true;
                        else
                            modelitem.B_HOTPOINTS = false;
                        modellist.Add(modelitem);
                    }
                    WriteLog("success");
                    return modellist;
             
            }
        }

        /// <summary>
        /// 分页获取文章状态为1的文章
        /// </summary>
        /// <returns></returns>
        public List<Article_S> GetDisplayArticlesPaged(Article_S model, PageInfo pi)
        {
            using (var factory = new BaseAccess())
            {
                List<Orderby<ArticleEntity>> orders = new List<Orderby<ArticleEntity>>()
                {
                    new Orderby<ArticleEntity>(c => c.DT_ADD_TIME, SortOrder.Descending)
                };
                var spec = Specification<ArticleEntity>.Create(c => true);
                if (!string.IsNullOrEmpty(model.C_STATUS))
                {
                    spec &= Specification<ArticleEntity>.Create(c => c.C_STATUS == model.C_STATUS);
                }
                if (!string.IsNullOrEmpty(model.C_VERIFY_STATUS))
                {
                    spec &= Specification<ArticleEntity>.Create(c => c.C_VERIFY_STATUS == model.C_VERIFY_STATUS);
                }
                else
                    spec &= Specification<ArticleEntity>.Create(c => c.C_VERIFY_STATUS == ((int)EMARTICLESTATUS.二级审核).ToString());
                if (!string.IsNullOrEmpty(model.N_COLUMN_ID))
                {
                    if (model.N_COLUMN_ID == "999")
                    {
                        spec &= Specification<ArticleEntity>.Create(c => c.DT_ADD_TIME > DateTime.Now.AddDays(-7));
                        orders = new List<Orderby<ArticleEntity>>()
                        {
                    new Orderby<ArticleEntity>(c => c.N_HITS, SortOrder.Descending),
                    new Orderby<ArticleEntity>(c => c.DT_ADD_TIME, SortOrder.Descending)
                        };
                    }
                    else
                        spec &= Specification<ArticleEntity>.Create(c => c.N_COLUMN_ID.Contains(model.N_COLUMN_ID));
                }
                else if (!string.IsNullOrEmpty(model.VC_KEYWORDS))
                {
                    spec &= (Specification<ArticleEntity>.Create(c => c.VC_KEYWORDS.Contains(model.VC_KEYWORDS)) || Specification<ArticleEntity>.Create(c => c.VC_TITLE.Contains(model.VC_KEYWORDS)) || Specification<ArticleEntity>.Create(c => c.VC_CONTENT.Contains(model.VC_KEYWORDS)));
                }
                if (!string.IsNullOrEmpty(model.VC_TITLE))
                {
                    spec &= Specification<ArticleEntity>.Create(c => c.VC_TITLE.Contains(model.VC_TITLE));
                }
             
                spec &= Specification<ArticleEntity>.Create(c => c.C_STATUS == "1");
                var list = factory.GetPage<ArticleEntity>(pi, spec, orders);
                List<Article_S> modellist = new List<Article_S>();
                foreach (var item in list)
                {
                    if (item.N_COLUMN_ID == "0")
                        continue;
                    var modelitem = item.Adapter<Article_S>(new Article_S());
                    var column = factory.GetSingle<MenuEntity>(Specification<MenuEntity>.Create(m => m.MenuCode == item.N_COLUMN_ID));
                    if (column != null)
                        modelitem.VC_COLUMN_NAME = column.MenuName;
                    modelitem.VC_ADD_OP_NAME = item.OPADD == null ? "未知" : item.OPADD.UserDisplayName;
                    modelitem.VC_UPDATE_OP_NAME = item.OPUPDATE == null ? "未知" : item.OPUPDATE.UserDisplayName;
                    modelitem.VC_RECOMMEND_NAME = Enum.GetName(typeof(EMRECOMMENDLEVEL), (item.C_RECOMMEND_LEVEL).Convert<int>(1));
                    if (model.N_COLUMN_ID == "999")
                        modelitem.B_HOTPOINTS = true;
                    else
                        modelitem.B_HOTPOINTS = false;
                    modellist.Add(modelitem);
                }
                return modellist;
            }
        }

        /// <summary>
        /// 分页获取开放鉴定文章
        /// </summary>
        /// <returns></returns>
        public List<Article_S> GetArticlesVerifyPaged(Article_S model, PageInfo pi)
        {
            using (var factory = new BaseAccess())
            {
                List<Orderby<ArticleEntity>> orders = new List<Orderby<ArticleEntity>>()
                {
                    new Orderby<ArticleEntity>(c => c.DT_ADD_TIME, SortOrder.Descending)
                };
                var spec = Specification<ArticleEntity>.Create(c => true);
                if (!string.IsNullOrEmpty(model.C_STATUS))
                {
                    spec &= Specification<ArticleEntity>.Create(c => c.C_STATUS == model.C_STATUS);
                }
                if (!string.IsNullOrEmpty(model.C_VERIFY_STATUS))
                {
                    spec &= Specification<ArticleEntity>.Create(c => c.C_VERIFY_STATUS == model.C_VERIFY_STATUS);
                }
                if (!string.IsNullOrEmpty(model.N_COLUMN_ID))
                {
                    spec &= Specification<ArticleEntity>.Create(c => c.N_COLUMN_ID.Contains(model.N_COLUMN_ID));
                }
                else if (!string.IsNullOrEmpty(model.VC_KEYWORDS))
                {
                    spec &= (Specification<ArticleEntity>.Create(c => c.VC_KEYWORDS.Contains(model.VC_KEYWORDS)) || Specification<ArticleEntity>.Create(c => c.VC_TITLE.Contains(model.VC_KEYWORDS)) || Specification<ArticleEntity>.Create(c => c.VC_CONTENT.Contains(model.VC_KEYWORDS)));
                }
                if (!string.IsNullOrEmpty(model.VC_TITLE))
                {
                    spec &= Specification<ArticleEntity>.Create(c => c.VC_TITLE.Contains(model.VC_TITLE));
                }
                var list = factory.GetPage<ArticleEntity>(pi, spec, orders);
                List<Article_S> modellist = new List<Article_S>();
                foreach (var item in list)
                {
                    if (item.N_COLUMN_ID == "0")
                        continue;
                    var modelitem = item.Adapter<Article_S>(new Article_S());
                    var column = factory.GetSingle<MenuEntity>(Specification<MenuEntity>.Create(m => m.MenuCode == item.N_COLUMN_ID));
                    if (column != null)
                        modelitem.VC_COLUMN_NAME = column.MenuName;
                    modelitem.VC_ADD_OP_NAME = item.OPADD == null ? "未知" : item.OPADD.UserDisplayName;
                    modelitem.VC_UPDATE_OP_NAME = item.OPUPDATE == null ? "未知" : item.OPUPDATE.UserDisplayName;
                    modelitem.VC_RECOMMEND_NAME = Enum.GetName(typeof(EMRECOMMENDLEVEL), (item.C_RECOMMEND_LEVEL).Convert<int>(1));
                    modelitem.B_HOTPOINTS = false;
                    modellist.Add(modelitem);
                }
                return modellist;
            }
        }

        /// <summary>
        /// 根据栏目编号获取栏目名称
        /// </summary>
        /// <returns></returns>
        public string GetColumnNameByColumnId(string ColumnId)
        {
            using (var factory = new BaseAccess())
            {
                try
                {
                    var Column = factory.GetSingle<MenuEntity>(Specification<MenuEntity>.Create(c => c.MenuCode == ColumnId));
                    return Column.MenuName;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 根据栏目编号得到父级ID
        /// </summary>
        /// <returns></returns>
        public string GetPreMenuIdByColumnId(string ColumnId)
        {
            using (var factory = new BaseAccess())
            {
                var Column = factory.GetSingle<NavigationEntity>(Specification<NavigationEntity>.Create(c => c.VC_LINK.Contains("?columnid=" + ColumnId)));
                if (Column == null)
                {
                    return "0";
                }
                return Column.N_SUPER_NAVIGATION_ID;
            }
        }

        /// <summary>
        /// 根据栏目编号获取栏目名称
        /// </summary>
        /// <returns></returns>
        public string GetColumnIDsByColumnId(string ColumnId)
        {
            using (var factory = new BaseAccess())
            {
                var Columns = factory.GetAll<MenuEntity>(Specification<MenuEntity>.Create(c => c.MenuCode.Contains(ColumnId)));
                string ColumnIDs = string.Empty;
                Columns.ForEach(c => ColumnIDs += c.MenuCode + ",");
                return ColumnIDs;
            }
        }

        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddArticle(Article_S model)
        {
            using (var factory = new BaseAccess())
            {
                try
                {
                    var entity = model.Adapter<ArticleEntity>(new ArticleEntity());
                    factory.Insert(entity);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditArticle(Article_S model)
        {
            using (var factory = new BaseAccess())
            {
                try
                {
                    var entity = model.Adapter<ArticleEntity>(new ArticleEntity());
                    factory.Update<ArticleEntity>(entity);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取指定栏目前N条数据
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <param name="TopNum"></param>
        /// <returns></returns>
        public List<Article_S> GetTopArticleByColumnID(string ColumnID, int TopNum)
        {
            using (var factory = new BaseAccess())
            {
                var list = new List<Article_S>();
                PageInfo pi = new PageInfo();
                var spec = Specification<ArticleEntity>.Create(c => true);
                spec &= Specification<ArticleEntity>.Create(c => c.C_STATUS == ((int)RecordStatus.Enable).ToString());
                spec &= Specification<ArticleEntity>.Create(c => c.C_VERIFY_STATUS == ((int)EMARTICLESTATUS.二级审核).ToString());
                if (ColumnID == "999")
                {
                    spec &= Specification<ArticleEntity>.Create(c => c.DT_ADD_TIME >= DateTime.Now.AddDays(-7));
                    List<Orderby<ArticleEntity>> orders = new List<Orderby<ArticleEntity>>()
                {
                    new Orderby<ArticleEntity>(c => c.N_HITS, SortOrder.Descending),
                    new Orderby<ArticleEntity>(c => c.DT_ADD_TIME, SortOrder.Descending)
                };
                    pi.PageSize = TopNum;
                    pi.PageIndex = 1;
                    list = factory.GetPage(pi, spec, orders).Adapter<ArticleEntity, Article_S>(new List<Article_S>());
                    list.ForEach(c => c.B_HOTPOINTS = true);
                }
                else
                {
                    List<Orderby<ArticleEntity>> orders = new List<Orderby<ArticleEntity>>()
                {
                     new Orderby<ArticleEntity>(c=>c.C_RECOMMEND_LEVEL,SortOrder.Descending),//强烈推荐
                    new Orderby<ArticleEntity>(c => c.DT_ADD_TIME, SortOrder.Descending)
                };
                    spec &= Specification<ArticleEntity>.Create(c => c.N_COLUMN_ID.Contains(ColumnID));
                    if (TopNum != 0)
                    {
                        pi.PageSize = TopNum;
                        pi.PageIndex = 1;
                        list = factory.GetPage<ArticleEntity>(pi, spec, orders).Adapter<ArticleEntity, Article_S>(new List<Article_S>());
                    }
                    else
                    {
                        list = factory.GetAll<ArticleEntity>(spec, orders).Adapter<ArticleEntity, Article_S>(new List<Article_S>());
                    }
                    list.ForEach(c => c.B_HOTPOINTS = false);
                }
                return list;
            }
        }

        /// <summary>
        /// 获取栏目集合前N条数据
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <param name="TopNum"></param>
        /// <returns></returns>
        public List<Article_S> GetTopArticleByColumnIDs(string ColumnIDs, string ColumnNums)
        {
            using (var factory = new BaseAccess())
            {
                var listAll = new List<Article_S>();
                for (int i = 0; i < ColumnIDs.Split(',').Length; i++)
                {
                    var ColumnID = ColumnIDs.Split(',')[i];
                    var ColumnNum = ColumnNums.Split(',')[i].Convert<int>(0);
                    var list = GetTopArticleByColumnID(ColumnID, ColumnNum);
                    listAll.AddRange(list);
                }
                return listAll;
            }
        }

        /// <summary>
        /// 获取栏目集合前N条数据
        /// 图片信息获取强烈推荐
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <param name="TopNum"></param>
        /// <returns></returns>
        public List<Article_S> GetImageArticles(string ColumnIDs, int nCount)
        {
            using (var factory = new BaseAccess())
            {
                var listAll = new List<Article_S>();
                List<Orderby<ArticleEntity>> orders = new List<Orderby<ArticleEntity>>()
                {
                     new Orderby<ArticleEntity>(c=>c.C_RECOMMEND_LEVEL,SortOrder.Descending),//强烈推荐
                    new Orderby<ArticleEntity>(c => c.DT_ADD_TIME, SortOrder.Descending)
                   
                };
                var spec = Specification<ArticleEntity>.Create(c => c.B_IMG_NEWS == true);//是图片新闻

                spec &= Specification<ArticleEntity>.Create(c => c.C_STATUS == ((int)RecordStatus.Enable).ToString());
                if (!string.IsNullOrEmpty(ColumnIDs))
                    spec = Specification<ArticleEntity>.Create(c => c.B_IMG_NEWS == true && ("," + ColumnIDs + ",").Contains(("," + c.N_COLUMN_ID + ",")));//防止104将10的情况搜索出来
                PageInfo pi = new PageInfo();
                pi.PageSize = nCount;
                pi.PageIndex = 1;
                List<ArticleEntity> list = new List<ArticleEntity>();
                if (pi.PageSize == 0)
                    list = factory.GetAll<ArticleEntity>(spec, orders);
                else
                    list = factory.GetPage<ArticleEntity>(pi, spec, orders);
                return list.Adapter<ArticleEntity, Article_S>(new List<Article_S>());
            }
        }

        /// <summary>
        /// 点击||点赞
        /// </summary>
        /// <param name="ArticleID">文章ID</param>
        /// <param name="HitType">点击类型0点击量1点赞数</param>
        /// <returns></returns>
        public bool Hit(string ArticleID, string HitType, string IpAddress)
        {
            using (var factory = new BaseAccess())
            {
                try
                {
                    var spec = Specification<HitRecordEntity>.Create(c => c.VC_IP_ADDRESS == IpAddress);
                    spec = Specification<HitRecordEntity>.Create(c => c.N_ARTICLE_ID == ArticleID);
                    if (HitType == "3" || HitType == "4" || HitType == "5")//3满意 4一般 5不满意
                    {
                        spec &= Specification<HitRecordEntity>.Create(c => (",3,4,5,").Contains("," + c.C_HIT_TYPE + ","));

                    }
                    else
                    {
                        spec &= Specification<HitRecordEntity>.Create(c => c.C_HIT_TYPE == HitType);
                    }
                    spec &= Specification<HitRecordEntity>.Create(c => c.DT_HIT_TIME >= DateTime.Now.AddDays(-1));
                    var hitrecord = factory.GetSingle<HitRecordEntity>(spec);
                    if (hitrecord != null)
                        return false;
                    else
                    {
                        if (HitType == "0" || HitType == "1")//2网站访问量 0点击量 1点赞量 3满意 4一般 5不满意
                        {
                            var article = factory.GetSingle<ArticleEntity>(ArticleID);
                            if (HitType == ((int)EMHITTYPE.点击量).ToString())
                                article.N_HITS += 1;
                            else
                                article.N_LIKES += 1;
                            factory.Update<ArticleEntity>(article);
                        }
                        hitrecord = new HitRecordEntity();
                        hitrecord.ID = Guid.NewGuid().ToString();
                        hitrecord.N_ARTICLE_ID = ArticleID;
                        hitrecord.VC_IP_ADDRESS = IpAddress;
                        hitrecord.C_HIT_TYPE = HitType;
                        hitrecord.DT_HIT_TIME = DateTime.Now;
                        factory.Insert<HitRecordEntity>(hitrecord);
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 得到网站访问量
        /// </summary>
        /// <returns></returns>
        public int GetPageViewsCount()
        {
            using (var factory = new BaseAccess())
            {
                try
                {
                    var spec = Specification<HitRecordEntity>.Create(c => c.C_HIT_TYPE == "2");//网站访问量 

                    int hitrecord = factory.GetCount<HitRecordEntity>(spec);

                    return hitrecord;

                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 判断文章标题是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsTitleExisted(Article_S model)
        {
            using (var factory = new BaseAccess())
            {
                try
                {
                    var spec = Specification<ArticleEntity>.Create(c => c.N_COLUMN_ID == model.N_COLUMN_ID);
                    spec &= Specification<ArticleEntity>.Create(c => c.VC_TITLE == model.VC_TITLE);
                    var article = factory.GetSingle<ArticleEntity>(spec);
                    if (article != null)
                        return true;
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            }
        }// <summary>
        /// 写日志
        /// </summary>
        /// <param name="filePath">日志文件路径，不包括日志文件名</param>
        /// <param name="strMemo">要写入的字符串</param>
        public void WriteLog(string strMemo)
        {

            DateTime dnow = DateTime.Now;
            string filePath = @"D:\log";

            filePath = filePath + dnow.ToString("yyyy-MM") + @"\" + dnow.ToString("dd") + @"\";
            string filename = filePath + "log.txt";
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            StreamWriter sr = null;
            try
            {
                if (!File.Exists(filename))
                {
                    sr = File.CreateText(filename);
                }
                else
                {
                    sr = File.AppendText(filename);
                }
                sr.WriteLine(dnow.ToString("HH:mm:ss ffff") + "    " + strMemo + "\n\n");
            }
            catch
            {
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

        }


    }
}

using Business.Model.Models;
using Manage.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Controller.Facades
{

    public interface IArticleFacade : IBaseFacade
    { 
        /// <summary>
        /// 获取所有菜单（除管理员菜单）
        /// </summary>
        /// <returns></returns>
        List<Article_S> GetAllArticles(string ColumnId);

        /// <summary>
        /// 根据栏目编号获取栏目名称
        /// </summary>
        /// <returns></returns>
        string GetColumnNameByColumnId(string ColumnId);
         /// <summary>
        /// 根据栏目编号得到父级ID
        /// </summary>
        /// <returns></returns>
        string GetPreMenuIdByColumnId(string ColumnId);
        /// <summary>
        /// 根据栏目编号获取栏目名称
        /// </summary>
        /// <returns></returns>
        string GetColumnIDsByColumnId(string ColumnId);

        /// <summary>
        /// 获取所有菜单（除管理员菜单）
        /// </summary>
        /// <returns></returns>
        List<Article_S> GetArticlesPaged(Article_S model, PageInfo pi);
        /// <summary>
        /// 获取所有菜单（除管理员菜单）
        /// </summary>
        /// <returns></returns>
        List<Article_S> GetDisplayArticlesPaged(Article_S model, PageInfo pi);
        /// <summary>
        /// 获取所有菜单（除管理员菜单）
        /// </summary>
        /// <returns></returns>
        List<Article_S> GetArticlesVerifyPaged(Article_S model, PageInfo pi);

        /// <summary>
        /// 获取所有菜单（除管理员菜单）
        /// </summary>
        /// <returns></returns>
        bool AddArticle(Article_S model);

        /// <summary>
        /// 获取所有菜单（除管理员菜单）
        /// </summary>
        /// <returns></returns>
        bool EditArticle(Article_S model);

        /// <summary>
        /// 获取指定栏目前N条数据
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <param name="TopNum"></param>
        /// <returns></returns>
        List<Article_S> GetTopArticleByColumnID(string ColumnID, int TopNum);

        /// <summary>
        /// 获取栏目集合前N条数据
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <param name="TopNum"></param>
        /// <returns></returns>
        List<Article_S> GetTopArticleByColumnIDs(string ColumnIDs, string ColumnNums);

        /// <summary>
        /// 获取栏目集合前N条数据
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <param name="TopNum"></param>
        /// <returns></returns>
        List<Article_S> GetImageArticles(string ColumnIDs, int nCount);

        /// <summary>
        /// 点击||点赞
        /// </summary>
        /// <param name="ArticleID">文章ID</param>
        /// <param name="HitType">点击类型0点击量1点赞数</param>
        /// <returns></returns>
        bool Hit(string ArticleID, string HitType, string IpAddress);
          /// <summary>
        /// 得到网站访问量
        /// </summary>
        /// <returns></returns>
        int GetPageViewsCount();

        /// <summary>
        /// 判断文章标题是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool IsTitleExisted(Article_S model);
    }
}
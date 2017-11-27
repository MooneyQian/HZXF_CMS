/*
 * @Author: ying.qian
 * @Date:   2017-09-26
 * @lastModify 2017-09-26
 * +----------------------------------------------------------------------
 * | Description: 管理后台首页
 * +----------------------------------------------------------------------
 */
layui.define(["jquery", "element", "form", "qian", "MainIndex"], function (exports) {
    var element = layui.element;
    var $ = layui.jquery;
    var qian = layui.qian;
    var MainIndex = layui.MainIndex;


    function _Admin() { };

    //页面初始化
    _Admin.prototype.init = function () {
        MainIndex.init();
    }
  

    //加载左侧菜单
    MainIndex.loadLeftMenus = '/Home/GetMenuTree';
 

    var Admin = new _Admin();
    exports('Admin', Admin);
});
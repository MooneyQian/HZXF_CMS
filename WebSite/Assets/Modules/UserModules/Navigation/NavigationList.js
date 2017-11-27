/*
 * @Author: ying.qian
 * @Date:   2017-09-26
 * @lastModify 2017-09-26
 * +----------------------------------------------------------------------
 * | Description: 导航管理列表模块
 * +----------------------------------------------------------------------
 */
layui.define(["jquery", "TreeList"], function (exports) {
    var $ = layui.jquery;
    var TreeList = layui.TreeList;

    function _Navigation_List() { };

    //页面初始化
    _Navigation_List.prototype.init = function () {
        TreeList.init();
        listObj = this;
    }

    //更新节点
    _Navigation_List.prototype.updateNode = function (type, data) {
        if (type == "Add") {
            TreeList.addNode(data);
        } else {
            TreeList.updateNode(data);
        }
    }


    /************************** 重写父类方法 start **************************/

    TreeList.settings = function () {
        return {
            loadUrl: 'GetNavTree?ColumnId=' + $("#N_COLUMN_ID").val(),
            addUrl: 'Add?pid',
            delUrl: '_Delete?ids',
            editUrl: 'Edit?id'
        };
    }

    /************************** 重写父类方法 end **************************/


    var NavigationList = new _Navigation_List();

    exports('NavigationList', NavigationList);
});
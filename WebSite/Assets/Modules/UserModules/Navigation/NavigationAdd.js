/*
 * @Author: ying.qian
 * @Date:   2017-09-26
 * @lastModify 2017-09-26
 * +----------------------------------------------------------------------
 * | Description: 栏目管理编辑模块
 * +----------------------------------------------------------------------
 */
layui.define(["jquery", "qian", "html", "Add"], function (exports) {
    var $ = layui.jquery;
    var qian = layui.qian;
    var Add = layui.Add;

    function _Navigation_Add() { };

    //页面初始化
    _Navigation_Add.prototype.init = function () {
        Add.init();
    }

    /************************** 重写父类方法 start **************************/

    Add.onSuccess = function (obj) {
        parent.updateNode(Add.operType(), obj.Data);
        $("#N_NAV_CODE").val(obj.Data.navcode);
        qian.tips("操作成功");
    }

  
    /************************** 重写父类方法 end **************************/


    var Navigation_Add = new _Navigation_Add();
    exports('NavigationAdd', Navigation_Add);
});
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
    var html = layui.html;
    var Add = layui.Add;

    function _Column_Add() { };

    //页面初始化
    _Column_Add.prototype.init = function () {
        Add.init();
    }

    /************************** 重写父类方法 start **************************/

    //页面初始化方法
    Add.pageReady = function () {

    }

    //表单自定义校验
    Add.validForm = function () {
        var menutype = html.getRadioValueByName("MenuType");
        if (menutype == "") {
            qian.tips("请选择栏目");
            return false;
        }
        if (menutype == "1") {
            var Extend5 = $("#Extend5").val();
            if ($.trim(Extend5) == "") {
                qian.tips("请选择栏目类型！");
                return false;
            }
        }

        if (menutype == "2") {
            var Extend3 = $("#Extend3").val();
            if ($.trim(Extend3) == "") {
                qian.tips("请选择权限类型！");
                return false;
            }
        }
        
        return true;
    }
    Add.checkForm = function () {
        return {
            'q-samecheck': function (v, item) {
                var result = '';
                qian.ajax({
                    url: '_MenuFuncCodeIsSuc',
                    type: 'post',
                    async: false,
                    data: {
                        MenuCode: $("#MenuCode").val(),
                        PerMenuID: $("#PerMenuID").val()
                    },
                    success: function (res) {
                        if (res == true) {
                            result = '同级菜单中已经存在该菜单编号！';
                        }
                    }
                });
                return result;
            }

        }
    }


    Add.complexCheck = function () {
        return true;
    }

    Add.onSuccess = function (obj) {
        parent.updateNode(Add.operType(), obj.Data);
        $("#MenuIcon").val(html.base64Decode($("#MenuIcon").val()));
        $("#MenuCode").val(obj.Data.menucode);
        qian.tips("操作成功");
    }

    //监听开关
    Add.listenSwitch = function (id, obj, isChecked, v) {

    }

    //监听radio
    Add.listenRadio = function (obj, v) {
        if (obj.name == "MenuType") {//菜单类型
            if (v == "1") {
                html.show(".MenuType1", true);
                html.show(".MenuType2", false);
            } else {
                html.show(".MenuType1", false);
                html.show(".MenuType2", true);
            } 
        }
    }

    Add.listenSelect = function (id, obj, v) {
        if (id == "元素名") {
            //do something
        }
    }



    /************************** 重写父类方法 end **************************/


    var Column_Add = new _Column_Add();
    exports('ColumnAdd', Column_Add);
});
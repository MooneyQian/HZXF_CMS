/*
 * @Author: ying.qian
 * @Date:   2017-09-26
 * @lastModify 2017-09-26
 * +----------------------------------------------------------------------
 * | Description: 网站主体结构
 * +----------------------------------------------------------------------
 */
layui.define(["jquery", "element", "layer", "form", "util", "upload", "laytpl", "qian"], function (exports) {
    var util = layui.util;
    var form = layui.form;
    var element = layui.element;
    var laytpl = layui.laytpl;
    var upload = layui.upload;
    var layer = layui.layer;
    var device = layui.device();
    var qian = layui.qian;
    var $ = layui.jquery;

    var _this;
    var DISABLED = 'layui-btn-disabled';
    var tplPath = 'Basic/Master/tpl/web/webdefault/';


    function _WebDefault() {
        _this = this;
    }

    _WebDefault.prototype.init = function () {
        //阻止IE7以下访问
        if (device.ie && device.ie < 8) {
            layer.alert('如果您非得使用 IE 浏览器访问Fly社区，那么请使用 IE8+');
            return;
        }
       
        loadTopNav();

        //手机设备的简单适配
        var treeMobile = $('.site-tree-mobile')
        , shadeMobile = $('.site-mobile-shade')

        treeMobile.on('click', function () {
            $('body').addClass('site-mobile');
        });

        shadeMobile.on('click', function () {
            $('body').removeClass('site-mobile');
        });

        //固定Bar
        util.fixbar();
    }


    





    /**************************** 子类可复写方法 start ********************************/




    /**************************** 子类可复写方法 end ********************************/



    /**************************** 成员方法 start ********************************/

    //加载导航
    function loadTopNav() {
        qian.ajax({
            url: '_GetTopNavs',
            type: 'post',
            success: function (res) {
                var list = sonsTree(res.Data);
                qian.ajaxTemplate({
                    path: tplPath + "topNavTpl.html",
                    dom: "topNav",
                    data: list,
                    render: function () {
                        element.render('nav');
                    }
                });
            }
        });
    }

    function sonsTree(arr, id) {
        var temp = [];
        var forFn = function (arr, parent) {
            for (var i = 0; i < arr.length; i++) {
                var item = arr[i];
                var id;
                if (!parent) {
                    id = '0';
                } else {
                    id = parent.ID;
                }
                if (item.N_SUPER_NAVIGATION_ID == id) {
                    if (!item.childList) {
                        item.childList = [];
                    }
                    if (id == '0') {
                        temp.push(item);
                    } else {
                        parent.childList.push(item);
                    }
                    forFn(arr, item);
                }
            }
        };
        forFn(arr, id);
        return temp;
    }



    /**************************** 成员方法 end ********************************/

    var WebDefault = new _WebDefault();
    exports('WebDefault', WebDefault);
});
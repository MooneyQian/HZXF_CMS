/*
 * @Author: ying.qian
 * @Date:   2017-09-26
 * @lastModify 2017-09-26
 * +----------------------------------------------------------------------
 * | Description: 默认网站主题
 * +----------------------------------------------------------------------
 */
layui.define(["jquery", "qian", "WebDefault"], function (exports) {
    var $ = layui.jquery;
    var qian = layui.qian;
    var WebDefault = layui.WebDefault;

    var tplPath = "Modules/WebDefaultModules/tpl/";

    function _Mainbody() { };

    //页面初始化
    _Mainbody.prototype.init = function () {
        WebDefault.init();
    }

    /************************** 重写父类方法 start **************************/

    //加载主体内容
    WebDefault.loadBody = function () {
        load();
    }




    /************************** 重写父类方法 end **************************/

    function load() {
        qian.ajax({
            url: '_GetSingleNav',
            type: 'post',
            loadingType: '2',
            loadingDom: 'aaa',
            data: {
                key:'danweijianjie'
            },
            success: function (res) {
                qian.ajaxTemplate({
                    path: tplPath + "articlelistTpl.html",
                    dom: "aaa",
                    data: res.Data,
                    render: function () {
                       
                    }
                });
            }
        });
    }
   

    var Mainbody = new _Mainbody();
    exports('Mainbody', Mainbody);
});
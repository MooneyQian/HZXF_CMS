/*
 * @Author: ying.qian
 * @Date:   2017-09-26
 * @lastModify 2017-09-26
 * +----------------------------------------------------------------------
 * | Description: 用户首页
 * +----------------------------------------------------------------------
 */
layui.define(["jquery", "element", "form", "qian", "MainIndex", "usercenter"], function (exports) {
    var element = layui.element;
    var $ = layui.jquery;
    var qian = layui.qian;
    var MainIndex = layui.MainIndex;
    var usercenter = layui.usercenter;

    //模板文件路径
    var tplPath = "Modules/UserModules/CustomerHome/tpl/";

    var sysmsg;

    function _CustomerHome() { };

    //加载头部
    MainIndex.loadHeader = function () {
        //消息提醒
        //loadTips();
        //更改密码
        //$("#h-change-pwd").click(function () {

        //});
    }

    //加载左侧菜单
    MainIndex.loadLeftMenus = "/Main/Column/GetLeftMenuTree";

    //左侧菜单父id
    MainIndex.parentKeyV = "34b3b356-8880-4049-b8b6-199003ca9bce";

    //打开首页
    MainIndex.loadTabMain = function () {
        return;
        qian.ajax({
            url: '/CustomerHome/_GetHomeData',
            type: 'post',
            hasLoading: false,
            success: function (res) {
                qian.ajaxTemplate({
                    path: tplPath + "mainBodyTpl.html",
                    dom: "mainBody",
                    data: res,
                    render: function () {
                        $(".content-scroll").css("height", MainIndex.getHeight());
                       
                    }
                });
            }
        });

    }

    //页面初始化
    _CustomerHome.prototype.init = function () {
        MainIndex.init();

        $(window).resize(function () {
            $(".content-scroll").css("height", MainIndex.getHeight());
        });
    }


    //图标跳动
    _CustomerHome.prototype.msgblink = function (t, objname) {
        msgblink(t, objname);
    }

    //获得案件提醒
    _CustomerHome.prototype.getCaseInfoOut = function () {
        getCaseInfo();
    }

    

    //图标跳动主方法
    function msgblink(t, objname) {
        var soccer = document.getElementById(objname);
        if (t) {
            soccer.style.visibility = "visible";
        } else {
            soccer.style.visibility = (soccer.style.visibility == "hidden") ? "visible" : "hidden";
        }

    }


    //提醒设置
    function loadTips() {
        //点击事件
        $(".case-remind").click(function () {
            alert(11);
        });
        //请求案件提醒数量
        getCaseInfo();

        setInterval("layui.CustomerHome.getCaseInfoOut()", 1000 * 60 * 2);//2分钟执行一次
    }

    //获得案件提醒
    function getCaseInfo() {
        qian.ajax({
            url: '/LegalCase/_GetCaseInfo',
            type: 'post',
            hasLoading: false,
            success: function (res) {
                if (res > 0) {
                    $("#case-badge").removeClass("layui-hide");
                    clearSysMsg();
                    soccerOnload();
                    obtainSoundtips();
                } else {
                    $("#case-badge").addClass("layui-hide");
                    clearSysMsg();
                }
                $("#case-badge").html(res);
            }

        });
    }


    //清除计时器
    function clearSysMsg() {
        if (typeof (sysmsg) == "undefined") {

        } else {
            window.clearInterval(sysmsg);
            msgblink("1", "case-tips");
        }
    }

    //图标跳动
    function soccerOnload(type) {
        sysmsg = window.setInterval("layui.CustomerHome.msgblink('', 'case-tips')", 500);
    }

    //获取声音配置
    function obtainSoundtips() {
        usercenter.playSound();
    }
    
    

    var CustomerHome = new _CustomerHome();
    exports('CustomerHome', CustomerHome);
});
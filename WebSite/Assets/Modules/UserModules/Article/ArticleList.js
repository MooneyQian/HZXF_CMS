/*
 * @Author: ying.qian
 * @Date:   2017-09-26
 * @lastModify 2017-09-26
 * +----------------------------------------------------------------------
 * | Description: 文章管理模块
 * +----------------------------------------------------------------------
 */
layui.define(["List"], function (exports) {
    var List = layui.List;

    var _this;

    function _Article_List() {
        _this = this;
    };

    //页面初始化
    _Article_List.prototype.init = function () {
        List.init();
    }

    /************************** 重写父类方法 start **************************/

    //定义数据结构
    List.dataGrid = function () {
        return {
            url: '_ArticleList',
            grid:[
                { display: "标题", name: "VC_TITLE", type: "text", align: "center", width:300},
                { display: "所属栏目", name: "VC_COLUMN_NAME", type: "text", align: "center"},
                { display: "添加时间", name: "DT_ADD_TIME", type: "date", align: "center",width:150 },
                { display: "修改时间", name: "DT_UPDATE_TIME", type: "date", align: "center", width: 150 },
                { display: "添加人", name: "VC_ADD_OP_NAME", type: "text", align: "center"},
                { display: "修改人", name: "VC_UPDATE_OP_NAME", type: "text", align: "center" },
                { display: "图片新闻", name: "B_IMG_NEWS", type: "text", align: "center", width: 80 },
                { display: "推荐等级", name: "VC_RECOMMEND_NAME", type: "text", align: "center" },
                { display: "状态", name: "C_STAUTS", type: "text", align: "center" }
            ], checked: true
        };
    }


    /************************** 重写父类方法 end **************************/


    var ArticleList = new _Article_List();

    exports('ArticleList', ArticleList);
});
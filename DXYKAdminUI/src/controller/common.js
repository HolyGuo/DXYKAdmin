/**
 @Name：DXYKAdmin 公共业务
 */

layui.define(function (exports) {
  var $ = layui.$
    , layer = layui.layer
    , laytpl = layui.laytpl
    , setter = layui.setter
    , view = layui.view
    , admin = layui.admin;

  //公共业务的逻辑处理可以写在此处，切换任何页面都会执行
  //……



  //退出
  admin.events.logout = function () {
    //执行退出接口
    admin.req({
      url: 'static/json/user/logout.js'
      , type: 'get'
      , data: {}
      , done: function (res) { //这里要说明一下：done 是只有 response 的 code 正常才会执行。而 succese 则是只要 http 为 200 就会执行

        //清空本地记录的 token，并跳转到登入页
        admin.exit();
      }
    });
  };


  common = {
    v: "V1.0",
    ajax: function (url, method = 'post', async, data, callFun) {
      var _headers = {};
      var access_token = setter.request.tokenName;
      if (access_token !== null) {
        _headers = {
          'Authorization': access_token
        };
      }
      data = ((method === 'get') || (method === 'delete')) ? data : JSON.stringify(data);
      // var tData = null;
      // if (method === 'get') {
      //   tData = data;
      // } else {
      //   tData = JSON.stringify(data);
      // }
      // data = method === 'get' ? data : JSON.stringify(data);
      $.ajax({
        url: url,
        type: method,
        dataType: 'json',
        data: data,
        contentType: 'application/json',
        headers: _headers,
        async: async,
        success: function (res) {
          callFun(res);
        },
        error: function (xhr, type, errorThrown) {
          if (type === 'timeout') {
            console.log(url + '连接超时，请稍后重试！');
          } else if (type === 'error') {
            console.log(url + '连接异常，请稍后重试！');
          }
        }
      });
    },//ajax end
    layerOpen: function (id, title, maxmin = true, width, height, callFun, callFunYes) {
      layer.open({
        id: id,
        type: 1,
        title: title,
        maxmin: maxmin,
        area: [width + 'px', height + 'px'],
        btn: ['确定', '取消'],
        success: function (layero, index) {
          //渲染子页面
          callFun(layero, index);
        },
        yes: function (index, layero) {
          //点击确认按钮
          callFunYes(index, layero);
          // $("#LAY-user-front-submit").click();
        }
      });
    }
  }

  //对外暴露的接口
  exports('common', common);
});
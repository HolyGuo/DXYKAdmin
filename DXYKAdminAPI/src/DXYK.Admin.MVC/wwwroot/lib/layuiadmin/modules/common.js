/**
 @Name 公共业务
 @Author：HolyGuo
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
            url: 'api/Login/LogOut'
            , type: 'get'
            , data: { token: cookie.get('Cookies') }
            , done: function (res) { //这里要说明一下：done 是只有 response 的 code 正常才会执行。而 succese 则是只要 http 为 200 就会执行
                //清空本地记录的 token，并跳转到登入页
                cookie.remove('Cookies', 'AppId');//清除Cookies
                layer.msg('登出成功', {
                    offset: '15px'
                    , icon: 1
                    , time: 1000
                }, function () {
                    admin.exit(function () {
                        location.href = 'Login';
                    });
                });

            }
        });
    };

    Utils = {
        v: "V1.0",
        ajax: function (url, method = 'post', async, data, callFun) {
            var _headers = {};
            //var access_token = setter.request.tokenName;
            //if (access_token !== null) {
            //    _headers = {
            //        'Authorization': access_token
            //    };
            //}
            if (setter.request.tokenName) {
                //自动给参数传入默认 token
                data[setter.request.tokenName] = setter.request.tokenName in data
                    ? data[setter.request.tokenName]
                    : (layui.data(setter.tableName)[setter.request.tokenName] || '');
                //options.data[request.tokenName] = layui.data(setter.tableName)[request.tokenName];

                //自动给 Request Headers 传入 token
                _headers[setter.request.tokenName] = setter.request.tokenName in _headers
                    ? _headers[setter.request.tokenName]
                    : (layui.data(setter.tableName)[setter.request.tokenName] || '');
                //options.headers[request.tokenName] = layui.data(setter.tableName)[request.tokenName];
            }
            _headers = JSON.stringify(_headers);
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
        layerOpen: function (id, url, title, maxmin = true, width, height, callFun, callFunYes) {
            layer.open({
                id: id,
                content: $("#" + url + ""),
                type: 1,
                title: title,
                maxmin: maxmin,
                area: [width + 'px', height + 'px'],
                btn: ['确定', '取消'],
                scrollbar: true,//屏蔽浏览器滚动条
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
    exports('common', { Utils });
});
layui.define(function (exports) {

    layui.use(['admin', 'table', 'jquery', 'form', 'common', 'formtool'], function () {
        var admin = layui.admin,
            view = layui.view,
            form = layui.form,
            com = layui.common.Utils,
            table = layui.table,
            formTool = layui.formtool;

        var queryParam = { keyWords: "", field: "id", order: "desc" };
        var $ = layui.$, active = {
            reload: function (initSort) {
                //执行重载
                table.reload('test-table-toolbar', {
                    page: {
                        curr: 1 //重新从第 1 页开始
                    },
                    initSort: initSort,
                    where: queryParam
                });
            },
            add: function () {
                //清空表单
                var formtool = new formTool({ elem: '#from_user' });//表单选择器
                formtool.filling(null);
                com.layerOpen("LAY-popup-user-add", "from_user", "添加用户", true, 680, 560, function (layero, index) {
                    form.render(null, 'from_user');
                    //监听提交
                    form.on('submit(LAY-user-front-submit)', function (data) {
                        var field = data.field; //获取提交的字段
                        com.ajax('../api/SysUser/Insert', 'post', true, field, function (res) {
                            if (res.success === true) {
                                layer.msg('保存成功！', {
                                    icon: 1,
                                    time: 2000 //2秒关闭（如果不配置，默认是3秒）
                                }, function () {
                                    active.reload();//重载表格
                                    layer.close(index); //执行关闭 
                                });
                            } else {
                                layer.msg('保存失败！', {
                                    icon: 2,
                                    time: 2000 //2秒关闭（如果不配置，默认是3秒）
                                });
                            }
                        });//ajax end
                    });//form end
                }, function (layero, index) {
                    $("#LAY-user-front-submit").click();
                });
            },//add end
            edit: function (id) {
                //查询当前条数据
                com.ajax('../api/SysUser/GetById', 'get', true, { id: id }, function (res) {
                    if (res.success === true) {
                        com.layerOpen("LAY-popup-user-add", "from_user", "添加用户", true, 680, 560, function (layero, index) {
                            form.render(null, 'from_user');
                            //清空表单
                            var formtool = new formTool({ elem: '#from_user' });//表单选择器
                            formtool.filling(res.data);
                            //监听提交
                            form.on('submit(LAY-user-front-submit)', function (data) {
                                var field = data.field; //获取提交的字段
                                com.ajax('../api/SysUser/Update', 'put', true, field, function (res) {
                                    if (res.success === true) {
                                        layer.msg('保存成功！', {
                                            icon: 1,
                                            time: 2000 //2秒关闭（如果不配置，默认是3秒）
                                        }, function () {
                                            active.reload();//重载表格
                                            layer.close(index); //执行关闭 
                                        });
                                    } else {
                                        layer.msg('保存失败！', {
                                            icon: 2,
                                            time: 2000 //2秒关闭（如果不配置，默认是3秒）
                                        });
                                    }
                                });//ajax end
                            });//form end
                        }, function (layero, index) {
                            $("#LAY-user-front-submit").click();
                        });
                    } else {
                        layer.msg('保存失败！', {
                            icon: 2,
                            time: 2000 //2秒关闭（如果不配置，默认是3秒）
                        });
                    }
                });//ajax end
            },//edit end
            delete: function (id) {
                layer.confirm('你确定要删除用户：' + data.true_name, function (index) {
                    com.ajax(layui.setter.apiUri + '/api/SysUser/DeleteById?id=' + id, 'delete', true, null, function (res) {
                        if (res.success === true && res.data > 0) {
                            layer.msg('删除成功！', {
                                icon: 1,
                                time: 2000 //2秒关闭（如果不配置，默认是3秒）
                            }, function () {
                                active.reload();//重载表格
                            });
                        } else {
                            layer.msg('删除失败！', {
                                icon: 2,
                                time: 2000 //2秒关闭（如果不配置，默认是3秒）
                            });
                        }
                    });//ajax end
                    layer.close(index);
                });
            }//delete end

        }//active end

        //搜索
        $('.test-table-reload-btn .layui-btn').on('click', function () {
            queryParam.keyWords = $("#keyWords").val();
            var type = $(this).data('type');
            active[type] ? active[type].call(this) : '';
        });

        $(".test-table-reload-btn .layui-input").bind('keydown', function (e) {
            if (e.keyCode == 13) {
                e.preventDefault();
                $(".test-table-reload-btn .layui-btn")[0].click();
            }
        });

        table.render({
            elem: '#test-table-toolbar',
            url: '../api/SysUser/QueryDataByPage',
            method: 'post',
            contentType: 'application/json',
            title: '用户数据表',
            height: 'full-100',
            initSort: {
                field: 'id'
                , type: 'desc'
            },
            where: queryParam,
            cols: [[
                // { field: 'id', title: 'ID', width: 80, fixed: 'left', hide: true },
                { type: 'numbers' },
                //{ field: 'id', title: 'ID', width: 80, fixed: 'left' },
                { field: 'true_name', title: '姓名', width: 120, sort: true },
                // { field: 'nick_name', title: '昵称', width: 120, sort: true },
                { field: 'login_name', title: '登录名', width: 150, sort: true },
                { field: 'is_enable', title: '是否启用', width: 150, sort: true, templet: '#is_enable_Tpl' },
                { field: 'sex', title: '性别', width: 80, sort: true },
                //{ field: 'head_pic', title: '头像', width: 120, sort: true }, 
                { field: 'telephone', title: '电话', width: 120, sort: true },
                { field: 'mobile', title: '手机', width: 120, sort: true },
                { field: 'email', title: '邮箱', width: 200, sort: true },
                // { field: 'role_id', title: '角色id', width: 120, sort: true, hide: true },
                // { field: 'dept_id', title: '部门id', width: 120, sort: true, hide: true },
                { field: 'org_name', title: '部门', width: 120, sort: true },
                { field: 'wx_id', title: '微信号', width: 120, sort: true },
                { field: 'wx_name', title: '微信昵称', width: 120, sort: true },
                { field: 'qq_id', title: 'QQ号', width: 120, sort: true },
                { field: 'qq_name', title: 'QQ昵称', width: 120, sort: true },
                { field: 'summary', title: '备注', width: 120, sort: true },
                // { field: 'sort', title: '排序', width: 120, sort: true },
                { fixed: 'right', title: '操作', toolbar: '#test-table-toolbar-barDemo', width: 115, align: 'center' }
            ]],
            page: true,
            limits: [10, 15, 20, 30, 40, 50],
            limit: 15
        });

        //监听行工具事件
        table.on('tool(test-table-toolbar)', function (obj) {
            var id = obj.data.id + "";
            if (obj.event === 'del') {
                active.delete(id);
            } else if (obj.event === 'edit') {
                active.edit(id);
            } else {
                layer.msg('数据加载失败！', {
                    icon: 2,
                    time: 2000 //2秒关闭（如果不配置，默认是3秒）
                });
            }
        });//table.on end

        //监听排序事件
        table.on('sort(test-table-toolbar)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            queryParam.field = obj.field; //排序字段
            queryParam.order = obj.type; //排序方式
            active.reload(obj);
        });

    });//layui.use end

    exports('user', {})
});//layui.define end
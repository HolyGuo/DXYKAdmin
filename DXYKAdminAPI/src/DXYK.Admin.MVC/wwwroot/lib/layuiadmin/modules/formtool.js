layui.define(['jquery', 'form'],
    function (exports) {
        var $ = layui.jquery,
            form = layui.form,
            formObj,
            hint = layui.hint();
        var FormTool = function (options) {
            this.options = options;
            formObj = $(options.elem);
        };
        /**
         * 设置select选中值
         * @param {String} name 对象名称，指“name”
         * @param {String} val 值
         * @param {Boolean} isOnSelect 是否触发选中事件
         * @returns {} 
         */
        FormTool.prototype.setSelectVal = function (name, val, isOnSelect) {
            if (name === undefined) {
                throw "name no undefined";
            }
            formObj.find('select[name="' + name + '"]').val(val);
            form.render('select');
            if (typeof (isOnSelect) === "boolean") {
                if (isOnSelect) {
                    formObj.find("dd[lay-value='" + val + "']").trigger("click");
                }
            }
            return this;
        };
        /**
         * 设置radio选中
         * @param {String} name 对象名称，指“name”
         * @param {String} val 对象值
         * @returns {} 
         */
        FormTool.prototype.setRadioVal = function (name, val) {
            if (name === undefined) {
                throw "name no undefined";
            }
            formObj.find('input[type="radio"][name="' + name + '"][value="' + val + '"]').prop("checked", true);
            form.render('radio');
            return this;
        };
        /**
         * 设置checkbox选中
         * @param {String} name 对象名称，指“name”
         * @returns {} 
         */
        FormTool.prototype.setCheckboxVal = function (name) {
            if (name === undefined) {
                throw "name no undefined";
            }
            formObj.find('input[type="checkbox"][name="' + name + '"]').prop("checked", true);
            form.render('checkbox');
            return this;
        }
        /**
         * 设置表单元素禁用
         * @param {String} type 类型，select、checkbox、radio
         * @param {String} name  对象名称，指“name”
         * @param {String} val 值，radio元素需要用到
         * @returns {} 
         */
        FormTool.prototype.setElemDisabled = function (type, name, val) {
            switch (type) {
                case "select":
                    formObj.find('select[name="' + name + '"]').prop("disabled", true);
                    form.render('select');
                    break;
                case "checkbox":
                    formObj.find('input[type="checkbox"][name="' + name + '"]').prop("disabled", true);
                    form.render('checkbox');
                    break;
                case "radio":
                    if (val === undefined) {
                        throw "val不能为undefined";
                    }
                    formObj.find('input[type="radio"][name="' + name + '"][value="' + val + '"]').prop("disabled", true);
                    form.render('radio');
                    break;
                default:
                    hint.error('layui.formtool 不支持该类型，type：' + type);
            }
            return this;
        }
        /**
         * 表单填充
         * @param {Object} data 
         * @returns {} 
         */
        FormTool.prototype.filling = function (data) {
            if (typeof data !== "object") {
                throw "data no object";
            }
            if (data == null) {
                var inputs = formObj.find('input');
                for (var i = 0; i < inputs.length; i++) {
                    var obj = inputs[i];
                    var type = $(obj).attr('type');
                    switch (type) {
                        case "checkbox":
                            $(obj).removeAttr("checked");
                            break;
                        case "radio":
                            $(obj).removeAttr("checked");
                            break;
                        default:
                            $(obj).val("");
                            break;
                    }
                }
                var selects = formObj.find("select");
                for (var i = 0; i < selects.length; i++) {
                    var obj = selects[i];
                    $(obj).val("");
                }
                var areas = formObj.find("textarea");
                for (var i = 0; i < areas.length; i++) {
                    var obj = areas[i];
                    $(obj).val("");
                }
            } else {
                for (var key in data) {
                    if (data.hasOwnProperty(key)) {
                        var inputs = formObj.find('input[name = "' + key + '"]');
                        if (inputs.length > 0) {
                            var input = inputs[0];
                            switch (input.type) {
                                case "text":
                                    input.value = data[key];
                                    break;
                                case "hidden":
                                    input.value = data[key];
                                    break;
                                case "radio":
                                    this.setRadioVal(key, data[key]);
                                    break;
                                case "checkbox":
                                    if (data[key] === true) {
                                        this.setCheckboxVal(key, data[key]);
                                    }
                                    break;
                            }
                        } else {
                            var select = formObj.find('select[name="' + key + '"]');
                            if (select.length > 0) {
                                this.setSelectVal(key, data[key], true);
                            }
                        }
                    }
                }
            }

            return this;
        };
        /**
         * 接口输出
         */
        exports('formtool',
            function (options) {
                var formtool = new FormTool(options = options || {});
                var elem = $(options.elem);
                if (!elem[0]) {
                    return hint.error('layui.formtool 没有找到' + options.elem + '元素');
                }
                return formtool;
            });
    });
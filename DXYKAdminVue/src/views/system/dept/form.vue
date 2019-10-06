<template>
  <el-dialog :append-to-body="true" :close-on-click-modal="false" :before-close="cancel" :visible.sync="dialog" :title="isAdd ? '新增部门' : '编辑部门'" width="500px">
    <el-form ref="form" :model="form" :rules="rules" size="small" label-width="80px">
      <el-form-item label="名称" prop="org_name">
        <el-input v-model="form.org_name" style="width: 370px;"/>
      </el-form-item>
      <el-form-item v-if="form.parent_id !== 0" label="状态" prop="dept_type">
        <el-radio v-for="item in dicts" :key="item.id" v-model="form.dept_type" :label="item.value">{{ item.label }}</el-radio>
      </el-form-item>
      <el-form-item style="margin-bottom: 0px;" label="上级部门">
        <treeselect v-model="form.parent_id" :options="depts" style="width: 370px;" placeholder="选择上级类目" />
      </el-form-item>
    </el-form>
    <div slot="footer" class="dialog-footer">
      <el-button type="text" @click="cancel">取消</el-button>
      <el-button :loading="loading" type="primary" @click="doSubmit">确认</el-button>
    </div>
  </el-dialog>
</template>

<script>
import { add, edit, getDepts } from '@/api/dept'
import Treeselect from '@riophae/vue-treeselect'
import '@riophae/vue-treeselect/dist/vue-treeselect.css'
export default {
  components: { Treeselect },
  props: {
    isAdd: {
      type: Boolean,
      required: true
    },
    dicts: {
      type: Array,
      required: true
    }
  },
  data() {
    return {
      loading: false, dialog: false, depts: [],
      form: {
        id: '',
        org_name: '',
        parent_id: 1,
        leader_id: 0,
        dept_type: 'true',
        dept_address: 'string',
        telphone: 'string',
        email: 'string',
        is_enable: 'string',
        sort: 0,
        group_id: 0,
        re_vision: 0,
        created_by: 0,
        created_time: '2019-10-05T18:58:59.837Z',
        updated_by: 0,
        updated_time: '2019-10-05T18:58:59.837Z',
        deleted_by: 0,
        deleted_time: '2019-10-05T18:58:59.837Z'
      },
      rules: {
        name: [
          { required: true, message: '请输入名称', trigger: 'blur' }
        ]
      }
    }
  },
  methods: {
    cancel() {
      this.resetForm()
    },
    doSubmit() {
      this.$refs['form'].validate((valid) => {
        if (valid) {
          if (this.form.parent_id !== undefined) {
            this.loading = true
            if (this.isAdd) {
              this.doAdd()
            } else this.doEdit()
          } else {
            this.$message({
              message: '上级部门不能为空',
              type: 'warning'
            })
          }
        }
      })
    },
    doAdd() {
      add(this.form).then(res => {
        this.resetForm()
        this.$notify({
          title: '添加成功',
          type: 'success',
          duration: 2500
        })
        this.loading = false
        this.$parent.init()
      }).catch(err => {
        this.loading = false
        console.log(err.response.data.message)
      })
    },
    doEdit() {
      edit(this.form).then(res => {
        this.resetForm()
        this.$notify({
          title: '修改成功',
          type: 'success',
          duration: 2500
        })
        this.loading = false
        this.$parent.init()
      }).catch(err => {
        this.loading = false
        console.log(err.response.data.message)
      })
    },
    resetForm() {
      this.dialog = false
      this.$refs['form'].resetFields()
      this.form = {
        id: '',
        name: '',
        parent_id: 1,
        dept_type: 'true'
      }
    },
    getDepts() {
      getDepts({ enabled: true }).then(res => {
        this.depts = res.data.content
      })
    }
  }
}
</script>

<style scoped>

</style>

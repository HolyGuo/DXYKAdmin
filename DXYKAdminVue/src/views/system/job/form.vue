<template>
  <el-dialog :append-to-body="true" :close-on-click-modal="false" :before-close="cancel" :visible.sync="dialog" :title="isAdd ? '新增岗位' : '编辑岗位'" width="500px">
    <el-form ref="form" :model="form" :rules="rules" size="small" label-width="80px">
      <el-form-item label="名称" prop="name">
        <el-input v-model="form.job_name" style="width: 370px;"/>
      </el-form-item>
      <el-form-item label="排序" prop="sort">
        <el-input-number v-model.number="form.sort" :min="0" :max="999" controls-position="right" style="width: 370px;"/>
      </el-form-item>
      <el-form-item v-if="form.pid !== 0" label="状态" prop="enabled">
        <el-radio v-for="item in dicts" :key="item.status" v-model="form.is_enable" :label="item.value">{{ item.label }}</el-radio>
      </el-form-item>
      <el-form-item label="所属部门">
        <treeselect v-model="deptId" :options="depts" style="width: 370px" placeholder="选择部门" />
      </el-form-item>
    </el-form>
    <div slot="footer" class="dialog-footer">
      <el-button type="text" @click="cancel">取消</el-button>
      <el-button :loading="loading" type="primary" @click="doSubmit">确认</el-button>
    </div>
  </el-dialog>
</template>

<script>
import { getDepts } from '@/api/sys/dept'
import { add, edit } from '@/api/sys/job'
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
      loading: false, dialog: false, depts: [], deptId: null,
      form: {
        id: '',
        job_name: '',
        org_id: 1,
        is_enable: 'true',
        sort: 0,
        group_id: 1,
        re_vision: 0,
        created_by: 0,
        created_time: '2019-10-05T18:58:59.837Z',
        updated_by: 0,
        updated_time: '2019-10-05T18:58:59.837Z',
        deleted_by: 0,
        deleted_time: '2019-10-05T18:58:59.837Z'
      },
      rules: {
        job_name: [
          { required: true, message: '请输入名称', trigger: 'blur' }
        ],
        sort: [
          { required: true, message: '请输入序号', trigger: 'blur', type: 'number' }
        ]
      }
    }
  },
  methods: {
    cancel() {
      this.resetForm()
    },
    doSubmit() {
      this.form.org_id = this.deptId
      this.$refs['form'].validate((valid) => {
        if (valid) {
          if (this.deptId === null || this.deptId === undefined) {
            this.$message({
              message: '所属部门不能为空',
              type: 'warning'
            })
          } else {
            this.loading = true
            if (this.isAdd) {
              this.doAdd()
            } else this.doEdit()
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
      this.deptId = null
      this.form = {
        id: '',
        job_name: '',
        org_id: 1,
        is_enable: 'true',
        sort: 0,
        group_id: 0,
        re_vision: 0,
        created_by: 0,
        created_time: '2019-10-05T18:58:59.837Z',
        updated_by: 0,
        updated_time: '2019-10-05T18:58:59.837Z',
        deleted_by: 0,
        deleted_time: '2019-10-05T18:58:59.837Z'
      }
    },
    getDepts() {
      getDepts({ page: 1, limit: 100, order: 'asc', field: 'sort', status: 'true' }).then(res => {
        this.depts = res.data.content
      })
    }
  }
}
</script>

<style rel="stylesheet/scss" lang="scss" scoped>
  /deep/ .el-input-number .el-input__inner {
    text-align: left;
  }
</style>

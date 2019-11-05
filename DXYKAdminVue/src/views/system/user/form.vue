<template>
  <el-dialog :visible.sync="dialog" :close-on-click-modal="false" :before-close="cancel" :title="isAdd ? '新增用户' : '编辑用户'" append-to-body width="570px">
    <el-form ref="form" :inline="true" :model="form" :rules="rules" size="small" label-width="66px">
      <el-form-item label="用户名" prop="nick_name">
        <el-input v-model="form.nick_name"/>
      </el-form-item>
      <el-form-item label="状态" prop="is_enabled">
        <el-radio v-for="item in dicts" :key="item.id" v-model="form.is_enabled" :label="item.value">{{ item.label }}</el-radio>
      </el-form-item>
      <el-form-item label="电话" prop="telephone">
        <el-input v-model.number="form.telephone" />
      </el-form-item>
      <el-form-item label="邮箱" prop="email">
        <el-input v-model="form.email" />
      </el-form-item>
      <el-form-item label="部门">
        <treeselect v-model="deptId" :options="depts" style="width: 178px" placeholder="选择部门" @select="selectFun" />
      </el-form-item>
      <el-form-item label="岗位">
        <treeselect v-model="jobId" :options="jobs" style="width: 178px" placeholder="请先选择部门" @select="selectFun" />
        <!-- <el-select v-model="jobId" style="width: 178px" placeholder="请先选择部门">
          <el-option
            v-for="(item, index) in jobs"
            :key="item.job_name"
            :label="item.job_name"
            :value="item.id"/>
        </el-select> -->
      </el-form-item>
      <el-form-item style="margin-bottom: 0px;" label="角色">
        <el-select v-model="roleIds" style="width: 450px;" multiple placeholder="请选择">
          <el-option
            v-for="(item, index) in role"
            :key="item.name"
            :label="item.name"
            :value="item.id"/>
        </el-select>
      </el-form-item>
    </el-form>
    <div slot="footer" class="dialog-footer">
      <el-button type="text" @click="cancel">取消</el-button>
      <el-button :loading="loading" type="primary" @click="doSubmit">确认</el-button>
    </div>
  </el-dialog>
</template>

<script>

import { add, edit } from '@/api/sys/user'
import { getDepts } from '@/api/sys/dept'
import { GetAllByName } from '@/api/sys/role'
import { getAllJob } from '@/api/sys/job'
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
    const validPhone = (rule, value, callback) => {
      if (!value) {
        callback(new Error('请输入电话号码'))
      } else if (!this.isvalidPhone(value)) {
        callback(new Error('请输入正确的11位手机号码'))
      } else {
        callback()
      }
    }
    return {
      dialog: false, loading: false, 
      form: { id: '', true_name: '', nick_name: '',
        login_name: '', login_pwd: '123456', is_enable: '启用',
        user_type: '', sex: '', head_pic: '', 
        telephone: '', mobile: '', email: '', summary: '', 
        org_id: '', job_id: '', last_login_time: '', 
        sort: '', group_id: '', 
        role: [], dept: { id: '' }, job: { id: '' }},
      roleIds: [], role: [], depts: [], deptId: null, jobId: null, jobs: [],
      rules: {
        username: [
          { required: true, message: '请输入用户名', trigger: 'blur' },
          { min: 2, max: 20, message: '长度在 2 到 20 个字符', trigger: 'blur' }
        ],
        email: [
          { required: true, message: '请输入邮箱地址', trigger: 'blur' },
          { type: 'email', message: '请输入正确的邮箱地址', trigger: 'blur' }
        ],
        phone: [
          { required: true, trigger: 'blur', validator: validPhone }
        ],
        enabled: [
          { required: true, message: '状态不能为空', trigger: 'blur' }
        ]
      }
    }
  },
  methods: {
    cancel() {
      this.resetForm()
    },
    doSubmit() {
      this.form.dept.id = this.deptId
      this.form.job.id = this.jobId
      this.$refs['form'].validate((valid) => {
        if (valid) {
          if (this.deptId === null || this.deptId === undefined) {
            this.$message({
              message: '部门不能为空',
              type: 'warning'
            })
          } else if (this.jobId === null) {
            this.$message({
              message: '岗位不能为空',
              type: 'warning'
            })
          } else if (this.roleIds.length === 0) {
            this.$message({
              message: '角色不能为空',
              type: 'warning'
            })
          } else {
            this.loading = true
            this.form.role = []
            const _this = this
            this.roleIds.forEach(function(data, index) {
              const role = { id: data }
              _this.form.role.push(role)
            })
            if (this.isAdd) {
              this.doAdd()
            } else this.doEdit()
          }
        } else {
          return false
        }
      })
    },
    doAdd() {
      add(this.form).then(res => {
        this.resetForm()
        this.$notify({
          title: '添加成功',
          message: '默认密码：123456',
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
      this.jobId = null
      this.roleIds = []
      this.form = { id: '', true_name: '', nick_name: '',
        login_name: '', login_pwd: '123456', is_enable: '启用',
        user_type: '', sex: '', head_pic: '', 
        telephone: '', mobile: '', email: '', summary: '', 
        org_id: '', job_id: '', last_login_time: '', 
        sort: '', group_id: '', 
        role: [], dept: { id: '' }, job: { id: '' }}
    },
    getRoles() {
      GetAllByName({ page: 1, limit: 100 }).then(res => {
        this.role = res.data.content
      }).catch(err => {
        console.log(err.response.data.message)
      })
    },
    getJobs(id) {
      getAllJob(id).then(res => {
        this.jobs = res.data.content
      }).catch(err => {
        console.log(err.response.data.message)
      })
    },
    getDepts() {
      getDepts({ page: 1, limit: 100, order: 'asc', field: 'sort', status: 'true' }).then(res => {
        this.depts = res.data.content
      })
    },
    isvalidPhone(str) {
      const reg = /^1[3|4|5|7|8][0-9]\d{8}$/
      return reg.test(str)
    },
    selectFun(node, instanceId) {
      this.getJobs(node.id)
    }
  }
}
</script>

<style scoped>

</style>

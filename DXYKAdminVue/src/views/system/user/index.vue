<template>
  <div class="app-container">
    <!--form 组件-->
    <eForm ref="form" :is-add="isAdd" :dicts="dicts"/>
    <el-row :gutter="20">
      <!--部门数据-->
      <el-col :xs="9" :sm="6" :md="4" :lg="4" :xl="4">
        <div class="head-container">
          <el-input v-model="deptName" clearable placeholder="输入部门名称搜索" prefix-icon="el-icon-search" style="width: 100%;" class="filter-item" @input="getDeptDatas"/>
        </div>
        <el-tree :data="depts" :props="defaultProps" :expand-on-click-node="false" default-expand-all @node-click="handleNodeClick"/>
      </el-col>
      <!--用户数据-->
      <el-col :xs="15" :sm="18" :md="20" :lg="20" :xl="20">
        <!--工具栏-->
        <div class="head-container">
          <!-- 搜索 -->
          <el-input v-model="query.blurry" clearable placeholder="输入名称搜索" style="width: 200px;" class="filter-item" @keyup.enter.native="toQuery"/>
          <el-select v-model="query.enabled" clearable placeholder="状态" class="filter-item" style="width: 90px" @change="toQuery">
            <el-option v-for="item in enabledTypeOptions" :key="item.key" :label="item.display_name" :value="item.key"/>
          </el-select>
          <el-button class="filter-item" size="mini" type="success" icon="el-icon-search" @click="toQuery">搜索</el-button>
          <!-- 新增 -->
          <div v-if="checkPermission(['Admin','User_Manage','User_Add'])" style="display: inline-block;margin: 0px 2px;">
            <el-button
              class="filter-item"
              size="mini"
              type="primary"
              icon="el-icon-plus"
              @click="add">新增</el-button>
          </div>
          <!-- 导出 -->
          <!-- <div style="display: inline-block;">
            <el-button
              :loading="downloadLoading"
              size="mini"
              class="filter-item"
              type="warning"
              icon="el-icon-download"
              @click="download">导出</el-button>
          </div> -->
        </div>
        <!--表格渲染-->
        <el-table v-loading="loading" :data="data" size="small" style="width: 100%;">
          <el-table-column prop="user.true_name" label="姓名"/>
          <el-table-column prop="user.nick_name" label="昵称"/>
          <el-table-column prop="user.login_name" label="用户名"/>
          <el-table-column prop="user.telephone" label="电话"/>
          <el-table-column :show-overflow-tooltip="true" prop="user.email" label="邮箱"/>
          <el-table-column label="部门 / 岗位">
            <template slot-scope="scope">
              <div>{{ scope.row.dept.name }} / {{ scope.row.job.name }}</div>
            </template>
          </el-table-column>
          <el-table-column label="状态" align="center">
            <template slot-scope="scope">
              <el-tag>{{ scope.row.user.is_enable }}</el-tag>
            </template>
          </el-table-column>
          <el-table-column :show-overflow-tooltip="true" prop="user.createTime" label="创建日期">
            <template slot-scope="scope">
              <span>{{ parseTime(scope.row.user.createTime) }}</span>
            </template>
          </el-table-column>
          <el-table-column v-if="checkPermission(['Admin','User_Manage','User_Delete','User_Update'])" label="操作" width="125" align="center" fixed="right">
            <template slot-scope="scope">
              <el-button v-if="checkPermission(['Admin','User_Manage','User_Update'])" size="mini" type="primary" icon="el-icon-edit" @click="edit(scope.row)"/>
              <el-popover
                v-if="checkPermission(['Admin','User_Manage','User_Delete'])"
                :ref="scope.row.id"
                placement="top"
                width="180">
                <p>确定删除本条数据吗？</p>
                <div style="text-align: right; margin: 0">
                  <el-button size="mini" type="text" @click="$refs[scope.row.id].doClose()">取消</el-button>
                  <el-button :loading="delLoading" type="primary" size="mini" @click="subDelete(scope.row.id)">确定</el-button>
                </div>
                <el-button slot="reference" type="danger" icon="el-icon-delete" size="mini"/>
              </el-popover>
            </template>
          </el-table-column>
        </el-table>
        <!--分页组件-->
        <el-pagination
          :total="total"
          :current-page="page + 1"
          style="margin-top: 8px;"
          layout="total, prev, pager, next, sizes"
          @size-change="sizeChange"
          @current-change="pageChange"/>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import checkPermission from '@/utils/permission'
import initData from '@/mixins/initData'
import initDict from '@/mixins/initDict'
import { del, downloadUser } from '@/api/sys/user'
import { getDepts } from '@/api/sys/dept'
import { parseTime, downloadFile } from '@/utils/index'
import eForm from './form'
import Config from '@/config'
export default {
  name: 'User',
  components: { eForm },
  mixins: [initData, initDict],
  data() {
    return {
      height: document.documentElement.clientHeight - 180 + 'px;', isAdd: false,
      delLoading: false, deptName: '', depts: [], deptId: null,
      defaultProps: {
        children: 'children',
        label: 'name'
      },
      downloadLoading: false,
      enabledTypeOptions: [
        { key: '启用', display_name: '启用' },
        { key: '禁用', display_name: '禁用' }
      ],
      appid: Config.appid
    }
  },
  created() {
    this.getDeptDatas()
    this.$nextTick(() => {
      this.init()
      // 加载数据字典
      // this.getDict('user_status')
      this.dicts = [{ 'id': 1, 'label': '启用', 'value': '启用', 'sort': '1' },
       { 'id': 2, 'label': '禁用', 'value': '禁用', 'sort': '2' }]
    })
  },
  mounted: function() {
    const that = this
    window.onresize = function temp() {
      that.height = document.documentElement.clientHeight - 180 + 'px;'
    }
  },
  methods: {
    parseTime,
    checkPermission,
    beforeInit() {
      this.url = 'api/SysUser/QueryDataByDept'
      const order = 'asc'
      const query = this.query
      const blurry = query.blurry
      const enabled = query.enabled
      this.params = { page: this.page + 1, limit: this.size, order: order, dept: this.deptId, app: 'GXGHOA'  }
      if (blurry) { this.params['keyWords'] = blurry }
      if (enabled !== '' && enabled !== null) { this.params['enabled'] = enabled }
      return true
    },
    subDelete(id) {
      this.delLoading = true
      del(id).then(res => {
        this.delLoading = false
        this.$refs[id].doClose()
        this.dleChangePage()
        this.init()
        this.$notify({
          title: '删除成功',
          type: 'success',
          duration: 2500
        })
      }).catch(err => {
        this.delLoading = false
        this.$refs[id].doClose()
        console.log(err.response.data.message)
      })
    },
    getDeptDatas() {
      const params = { page: 1, limit: 100, order: 'asc', field: 'sort', status: '启用' }
      if (this.deptName) { params['keyWords'] = this.deptName }
      getDepts(params).then(res => {
        this.depts = res.data.content
      })
    },
    handleNodeClick(data) {
      if (data.pid === 0) {
        this.deptId = null
      } else {
        this.deptId = data.id
      }
      this.init()
    },
    add() {
      _this.appid = this.appid
      this.isAdd = true
      this.$refs.form.getDepts()
      this.$refs.form.getRoles()
      this.$refs.form.dialog = true
    },
    // 导出
    download() {
      this.downloadLoading = true
      downloadUser().then(result => {
        downloadFile(result, '用户列表', 'xlsx')
        this.downloadLoading = false
      }).catch(() => {
        this.downloadLoading = false
      })
    },
    // 数据转换
    formatJson(filterVal, jsonData) {
      return jsonData.map(v => filterVal.map(j => {
        if (j === 'createTime' || j === 'lastPasswordResetTime') {
          return parseTime(v[j])
        } else if (j === 'enabled') {
          return parseTime(v[j]) ? '启用' : '禁用'
        } else {
          return v[j]
        }
      }))
    },
    edit(data) {
      this.isAdd = false
      const _this = this.$refs.form
      this.$refs.appid = this.appid
      _this.getRoles()
      _this.getDepts()
      _this.roleIds = []
      const user = data.user
      //用户信息
      _this.form = { id: user.id, true_name: user.true_name, nick_name: user.nick_name,
        login_name: user.login_name, login_pwd: user.login_pwd, is_enable: user.is_enable,
        user_type: user.user_type, sex: user.sex, head_pic: user.head_pic, 
        telephone: user.telephone, mobile: user.mobile, email: user.email, summary: user.summary, 
        org_id: user.org_id, job_id: user.job_id, last_login_time: user.last_login_time, 
        sort: user.sort, group_id: user.group_id, 
        role: [], dept: { id: data.dept.id }, job: { id: data.job.id }}
      //角色
      data.role.forEach(function(data, index) {
        _this.roleIds.push(data.id)
      })
      _this.deptId = data.dept.id
      _this.jobId = data.job.id
      _this.getJobs(_this.deptId)
      _this.dialog = true
    }
  }
}
</script>

<style scoped>
</style>

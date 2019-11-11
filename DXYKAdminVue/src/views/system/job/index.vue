<template>
  <div class="app-container">
    <!--工具栏-->
    <div class="head-container">
      <!-- 搜索 -->
      <el-input v-model="query.value" clearable placeholder="输入岗位名称搜索" style="width: 200px;" class="filter-item" @keyup.enter.native="toQuery"/>
      <el-select v-model="query.enabled" clearable placeholder="状态" class="filter-item" style="width: 90px" @change="toQuery">
        <el-option v-for="item in enabledTypeOptions" :key="item.key" :label="item.display_name" :value="item.key"/>
      </el-select>
      <el-button class="filter-item" size="mini" type="success" icon="el-icon-search" @click="toQuery">搜索</el-button>
      <!-- 新增 -->
      <div style="display: inline-block;margin: 0px 2px;">
        <el-button
          v-if="checkPermission(['Admin','Job_Manage','Job_Add'])" 
          class="filter-item"
          size="mini"
          type="primary"
          icon="el-icon-plus"
          @click="add">新增</el-button>
      </div>
    </div>
    <!--表单组件-->
    <eForm ref="form" :is-add="isAdd" :dicts="dicts"/>
    <!--表格渲染-->
    <el-table v-loading="loading" :data="data" size="small" style="width: 100%;">
      <el-table-column prop="job_name" label="名称"/>
      <el-table-column label="所属部门">
        <template slot-scope="scope">
          <div>{{ scope.row.deptSuperiorName ? scope.row.deptSuperiorName + ' / ' : '' }}{{ scope.row.dept.name }}</div>
        </template>
      </el-table-column>
      <el-table-column prop="sort" label="排序">
        <template slot-scope="scope">
          <el-tag>{{ scope.row.sort }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column label="状态" align="center">
        <template slot-scope="scope">
          <el-tag>{{ scope.row.is_enable }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="createTime" label="创建日期">
        <template slot-scope="scope">
          <span>{{ parseTime(scope.row.createTime) }}</span>
        </template>
      </el-table-column>
      <el-table-column v-if="checkPermission(['Admin','Job_Manage','Job_Delete','Job_Update'])" label="操作" width="130px" align="center" fixed="right">
        <template slot-scope="scope">
          <el-button v-if="checkPermission(['Admin','Job_Manage','Job_Update'])" size="mini" type="primary" icon="el-icon-edit" @click="edit(scope.row)"/>
          <el-popover
            v-if="checkPermission(['Admin','Job_Manage','Job_Delete'])"
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
  </div>
</template>

<script>
import checkPermission from '@/utils/permission'
import initData from '@/mixins/initData'
import initDict from '@/mixins/initDict'
import { del } from '@/api/sys/job'
import { parseTime } from '@/utils/index'
import eForm from './form'
export default {
  name: 'Job',
  components: { eForm },
  mixins: [initData, initDict],
  data() {
    return {
      delLoading: false,
      enabledTypeOptions: [
        { key: '启用', display_name: '启用' },
        { key: '禁用', display_name: '禁用' }
      ]
    }
  },
  created() {
    this.$nextTick(() => {
      this.init()
      // 加载数据字典
      // this.getDict('job_status')
      this.dicts = [{ 'id': 11, 'label': '启用', 'value': '启用', 'sort': '1' },
       { 'id': 12, 'label': '禁用', 'value': '禁用', 'sort': '2' }]
    })
  },
  methods: {
    parseTime,
    checkPermission,
    beforeInit() {
      this.url = 'api/SysJob/QueryDataByNameAndTypeByPage'
      const order = 'asc'
      this.params = { page: this.page + 1, limit: this.size, order: order }
      const query = this.query
      const value = query.value
      const enabled = query.enabled
      if (value) { this.params['keyWords'] = value }
      if (enabled && enabled !== '' && enabled !== null) { this.params['status'] = enabled }
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
    add() {
      this.isAdd = true
      this.$refs.form.getDepts()
      this.$refs.form.dialog = true
    },
    edit(data) {
      this.isAdd = false
      const _this = this.$refs.form
      _this.getDepts()
      _this.form = {
        id: data.id,
        job_name: data.job_name,
        sort: data.sort,
        is_enable: data.is_enable,
        createTime: data.createTime,
        dept: { id: data.dept.id }
      }
      _this.deptId = data.dept.id
      _this.dialog = true
    }
  }
}
</script>

<style scoped>

</style>

<template>
  <div class="app-container">
    <!--工具栏-->
    <div class="head-container">
      <!-- 搜索 -->
      <el-input v-model="query.value" clearable placeholder="输入部门名称搜索" style="width: 200px;" class="filter-item" @keyup.enter.native="toQuery"/>
      <el-select v-model="query.enabled" clearable placeholder="状态" class="filter-item" style="width: 90px" @change="toQuery">
        <el-option v-for="item in enabledTypeOptions" :key="item.key" :label="item.display_name" :value="item.key"/>
      </el-select>
      <el-button class="filter-item" size="mini" type="success" icon="el-icon-search" @click="toQuery">搜索</el-button>
      <!-- 新增 -->
      <div v-if="checkPermission(['Admin','Org_Manage','Org_Add'])" style="display: inline-block;margin: 0px 2px;">
        <el-button
          class="filter-item"
          size="mini"
          type="primary"
          icon="el-icon-plus"
          @click="add">新增</el-button>
      </div>
      <div style="display: inline-block;">
        <el-button
          class="filter-item"
          size="mini"
          type="warning"
          icon="el-icon-more"
          @click="changeExpand">{{ expand ? '折叠' : '展开' }}</el-button>
        <eForm ref="form" :is-add="true" :dicts="dicts"/>
      </div>
    </div>
    <!--表单组件-->
    <eForm ref="form" :is-add="isAdd" :dicts="dicts"/>
    <!--表格渲染-->
    <tree-table v-loading="loading" :expand-all="expand" :data="data" :columns="columns" size="small">
      <el-table-column label="状态" align="center">
        <template slot-scope="scope">
          <el-tag>{{ scope.row.enabled }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="createTime" label="创建日期">
        <template slot-scope="scope">
          <span>{{ parseTime(scope.row.createTime) }}</span>
        </template>
      </el-table-column>
      <el-table-column v-if="checkPermission(['Admin','Org_Manage','Org_Delete','Org_Update'])" label="操作" width="130px" align="center" fixed="right">
        <template slot-scope="scope">
          <el-button v-if="checkPermission(['Admin','Org_Manage','Org_Update'])" size="mini" type="primary" icon="el-icon-edit" @click="edit(scope.row)"/>
          <el-popover
            v-if="checkPermission(['Admin','Org_Manage','Org_Delete'])"
            :ref="scope.row.id"
            placement="top"
            width="180">
            <p>确定删除本条数据吗？</p>
            <div style="text-align: right; margin: 0">
              <el-button size="mini" type="text" @click="$refs[scope.row.id].doClose()">取消</el-button>
              <el-button :loading="delLoading" type="primary" size="mini" @click="subDelete(scope.row.id)">确定</el-button>
            </div>
            <el-button slot="reference" :disabled="scope.row.id === 1" type="danger" icon="el-icon-delete" size="mini"/>
          </el-popover>
        </template>
      </el-table-column>
    </tree-table>
  </div>
</template>

<script>
import treeTable from '@/components/TreeTable'
import checkPermission from '@/utils/permission'
import initData from '@/mixins/initData'
import initDict from '@/mixins/initDict'
import { del } from '@/api/sys/dept'
import { parseTime } from '@/utils/index'
import eForm from './form'
export default {
  name: 'Dept',
  components: { eForm, treeTable },
  mixins: [initData, initDict],
  data() {
    return {
      columns: [
        {
          text: '名称',
          value: 'name'
        }
      ],
      enabledTypeOptions: [
        { key: '启用', display_name: '启用' },
        { key: '禁用', display_name: '禁用' }
      ],
      delLoading: false, expand: true
    }
  },
  created() {
    this.$nextTick(() => {
      this.init()
      // 加载数据字典
      // this.getDict('dept_status')
      this.dicts = [{ 'id': 11, 'label': '启用', 'value': '启用', 'sort': '1' },
       { 'id': 12, 'label': '禁用', 'value': '禁用', 'sort': '2' }]
    })
  },
  methods: {
    parseTime,
    checkPermission,
    beforeInit() {
      this.url = 'api/SysOrg/QueryDataByNameAndType'
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
      const _this = this.$refs.form
      _this.getDepts()
      _this.dialog = true
    },
    changeExpand() {
      this.expand = !this.expand
      this.init()
    },
    edit(data) {
      this.isAdd = false
      const _this = this.$refs.form
      _this.getDepts()
      _this.form = {
        id: data.id,
        org_name: data.name,
        parent_id: data.pid,
        createTime: data.createTime,
        dept_type: data.enabled.toString()
      }
      _this.dialog = true
    }
  }
}
</script>

<style scoped>

</style>

<template>
  <div class="app-container">
    <!--工具栏-->
    <div class="head-container">
      <!-- 搜索 -->
      <el-input v-model="query.value" clearable placeholder="模糊搜索" style="width: 200px;" class="filter-item" @keyup.enter.native="toQuery"/>
      <el-button class="filter-item" size="mini" type="success" icon="el-icon-search" @click="toQuery">搜索</el-button>
      <!-- 新增 -->
      <div v-if="checkPermission(['Admin','Menu_Manage','Menu_Add'])" style="display: inline-block;margin: 0px 2px;">
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
          @click="changExpand">{{ expand ? '折叠' : '展开' }}</el-button>
        <eForm ref="form" :is-add="true"/>
      </div>
    </div>
    <!--表单组件-->
    <eForm ref="form" :is-add="isAdd"/>
    <!--表格渲染-->
    <tree-table v-loading="loading" :data="data" :expand-all="expand" :columns="columns" :height="height" size="small">
      <el-table-column prop="icon" label="图标" align="center" width="60px">
        <template slot-scope="scope">
          <svg-icon :icon-class="scope.row.icon" />
        </template>
      </el-table-column>
      <el-table-column prop="sort" align="center" label="排序">
        <template slot-scope="scope">
          <el-tag>{{ scope.row.sort }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column :show-overflow-tooltip="true" prop="jump" label="链接地址"/>
      <el-table-column v-if="checkPermission(['Admin','Menu_Manage','Menu_Delete','Menu_Update'])" label="操作" width="130px" align="center" fixed="right">
        <template slot-scope="scope">
          <el-button v-if="checkPermission(['Admin','Menu_Manage','Menu_Update'])" size="mini" type="primary" icon="el-icon-edit" @click="edit(scope.row)"/>
          <el-popover
            v-if="checkPermission(['Admin','Menu_Manage','Menu_Delete'])"
            :ref="scope.row.id"
            placement="top"
            width="200">
            <p>确定删除吗,如果存在下级节点则一并删除，此操作不能撤销！</p>
            <div style="text-align: right; margin: 0">
              <el-button size="mini" type="text" @click="$refs[scope.row.id].doClose()">取消</el-button>
              <el-button :loading="delLoading" type="primary" size="mini" @click="subDelete(scope.row.id)">确定</el-button>
            </div>
            <el-button slot="reference" type="danger" icon="el-icon-delete" size="mini"/>
          </el-popover>
        </template>
      </el-table-column>
    </tree-table>
  </div>
</template>

<script>
import checkPermission from '@/utils/permission' // 权限判断函数
import treeTable from '@/components/TreeTable'
import initData from '@/mixins/initData'
import { del } from '@/api/sys/menu'
import { parseTime } from '@/utils/index'
import eForm from './form'
export default {
  name: 'Menu',
  components: { treeTable, eForm },
  mixins: [initData],
  data() {
    return {
      columns: [
        {
          text: '名称',
          value: 'title',
          width: 140
        }
      ],
      delLoading: false, expand: true, height: 625
    }
  },
  created() {
    this.$nextTick(() => {
      this.height = document.documentElement.clientHeight - 200
      this.init()
    })
  },
  methods: {
    parseTime,
    checkPermission,
    beforeInit() {
      this.url = 'api/SysAppMenu/GetALL'
      const query = this.query
      const value = query.value
      this.params = {}
      if (value) { this.params['name'] = value }
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
      this.$refs.form.getMenus()
      this.$refs.form.dialog = true
    },
    edit(data) {
      this.isAdd = false
      const _this = this.$refs.form
      _this.getMenus()
      _this.form = { id: data.id, menu_code: data.menu_code, app_id: data.app_id,  title: data.title,
       parent_id: data.parent_id, icon: data.icon, menu_type: data.menu_type,
       jump: data.jump, is_enable: data.is_enable, sort: data.sort, group_id: data.group_id }
      _this.dialog = true
    },
    changExpand() {
      this.expand = !this.expand
      this.init()
    }
  }
}
</script>

<style scoped>

</style>

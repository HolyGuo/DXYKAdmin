<template>
    <div class="app-container calendar-list-container">
    
        <div class="filter-container">
    
            <el-button @click="reply()" type="primary" class="tool-item filter-item btn-reply">
                回复
            </el-button>
            <el-button @click="reply(true)" type="primary" class="tool-item filter-item btn-reply-all">
                回复所有
            </el-button>
            <el-button @click="forward" type="primary" icon="swagger" class="tool-item filter-item btn-forward">
                转发
            </el-button>
            <el-button type="danger" icon="swagger" class="tool-item filter-item btn-del" v-on:click="handleDelete()">
                删除
            </el-button>
            <el-button type="primary" class="tool-item filter-item btn-reload" v-on:click="initPage">
                 刷新
            </el-button>
            <el-input @keyup.enter.native="handleFilter" style="width: 300px;" class="filter-item" placeholder="标题" v-model="listQuery.keyWords">
            </el-input>
    
            <el-select clearable style="width: 120px" class="filter-item" v-model="listQuery.status" placeholder="状态">
                <el-option v-for="status in statusOptions" :key="status.value" :label="status.showValue" :value="status.value">
                </el-option>
            </el-select>
    
            <el-button class="filter-item" type="primary" icon="search" @click="handleFilter">搜索</el-button>
        </div>
    
        <el-table :key='tableKey' :data="list" ref="multipleTable" @sort-change="customSort" @selection-change="handleSelectionChange" v-loading.body="listLoading" border highlight-current-row style="width: 100%">
    
            <el-table-column type="selection" min-width="30px">
            </el-table-column>
            
            <el-table-column prop="sendName" sortable="custom" align="center" label="发件人">
                <template scope="scope">
                    <el-tooltip class="item" effect="dark" :content="scope.row.sender_name" placement="top">
                        <span>{{scope.row.sender_name}}</span>
                    </el-tooltip>
                </template>
            </el-table-column>
    
            <el-table-column prop="title" sortable="custom" label="主题" :show-overflow-tooltip="true" min-width="400px">
                <template scope="scope">
                    <span class="link-type" 
                    @click="goToDetail(scope.row.mail_id, scope.row.sender_name, scope.row.send_time, scope.row.attachment_ids)">
                    {{scope.row.mail_title}}</span>
                </template>
            </el-table-column>
    
            <el-table-column prop="receiveDate" sortable="custom" align="center" label="接收时间" width="150px">
                <template scope="scope">
                    <span>{{scope.row.send_time }}</span>
                </template>
            </el-table-column>
    
            <el-table-column prop="readDate" sortable="custom" align="center" label="阅读时间" width="150px">
                <template scope="scope">
                    <span>{{scope.row.read_time }}</span>
                </template>
            </el-table-column>
        </el-table>
    
        <div v-show="!listLoading" class="pagination-container">
            <el-pagination @size-change="handleSizeChange" @current-change="handleCurrentChange" :current-page.sync="listQuery.page" :page-sizes="[10,20,30, 50]" :page-size="listQuery.limit" layout="total, sizes, prev, pager, next, jumper" :total="total">
            </el-pagination>
        </div>
    
    </div>
</template>

<script>
import * as inboxAPI from 'api/mail/inbox';
import * as labelAPI from 'api/mail/mail_detail';
import { parseTime } from '@/utils';
import { mapGetters } from 'vuex'
import router from '@/router/routers'

export default {
    name: 'inbox',
    data() {
        return {
            list: null,
            total: null,
            listLoading: true,
            listQuery: {
                page: 1,
                limit: 20,
                keyWords: undefined,
                status: undefined,
                field: '',
                order: '',
                token:''
            },
            statusOptions: [
                {
                    value: 0,
                    showValue: '未读'
                },
                {
                    value: 1,
                    showValue: '已读'
                }
            ],
            multipleSelection: [],
            tableKey: 0
        }
    },
    computed: {
        ...mapGetters([
        'token'
        ])
    },
    created() {
        this.initPage();
        this.listQuery.token = this.token;
    },
    filters: {
        statusTypeFilter(status) {
            const statusMap = {
                0: 'danger',
                1: 'primary'
            };
            return statusMap[status]
        },
        statusShowFilter(status) {
            const statusMap = {
                0: '未读',
                1: '已读'
            };
            return statusMap[status]
        }
    },
    methods: {
        initPage() {
            this.getList();
        },
        getList() {
            this.listLoading = true;
            inboxAPI.fetchList(this.listQuery).then(response => {
                this.list = response.data;
                this.total = response.count;
                this.listLoading = false;
            })
        },
        handleFilter() {
            this.getList();
        },
        handleSizeChange(val) {
            this.listQuery.limit = val;
            this.getList();
        },
        handleCurrentChange(val) {
            this.listQuery.page = val;
            this.getList();
        },
        customSort(sortObj) {
            this.listQuery.field = sortObj.prop;
            this.listQuery.order = sortObj.order;
            this.getList();
        },
        timeFilter(time) {
            if (!time[0]) {
                this.listQuery.start = undefined;
                this.listQuery.end = undefined;
                return;
            }
            this.listQuery.start = parseInt(+time[0] / 1000);
            this.listQuery.end = parseInt((+time[1] + 3600 * 1000 * 24) / 1000);
        },
        goToDetail(id, sender_name, send_time, attachment_ids) {
            this.$store.commit('SET_MAIL_ID', id);
            this.$store.commit('SET_MAIL_TYPE', 'receive');
            this.$store.commit('SET_MAIL_SENDER', sender_name);
            this.$store.commit('SET_MAIL_SENDTIME', send_time);
            this.$store.commit('SET_MAIL_ATTACH', attachment_ids);
            this.$router.push({ path: '/mail/mail/detail' });
        },
        reply(isALL) {
            const selectedLen = this.multipleSelection.length || 0;
            if (selectedLen !== 1) {
                this.$message('请选择一封邮件进行回复');
                return;
            }
            this.$store.commit('SET_MAIL_ID', this.multipleSelection[0].id);
            if (isALL) {
                this.$store.commit('SET_PAGE_TYPE', 'replyAll');
            } else {
                this.$store.commit('SET_PAGE_TYPE', 'reply');
            }
            this.$store.commit('SET_MAIL_TYPE', 'receive');
            this.$router.push({ path: '/mail_send/index' });
        },
        forward() {
            const selectedLen = this.multipleSelection.length || 0;
            if (selectedLen !== 1) {
                this.$message('请选择一封邮件进行转发');
                return;
            }
            this.$store.commit('SET_MAIL_ID', this.multipleSelection[0].id);
            this.$store.commit('SET_PAGE_TYPE', 'forward');
            this.$store.commit('SET_MAIL_TYPE', 'receive');
            this.$router.push({ path: '/mail_send/index' });
        },
        handleSelectionChange(val) {
            this.multipleSelection = val;
        },
        handleDelete() {
            const selectedLen = this.multipleSelection.length || 0;
            if (selectedLen < 1) {
                this.$message('请选择邮件进行删除');
                return;
            }
            this.$confirm('是否删除这' + selectedLen + '封邮件?', '提示', {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning'
            }).then(() => {
                const idArr = [];
                this.multipleSelection.forEach(item => idArr.push(item.id));
                inboxAPI.delReceiveMail(idArr).subscribe({
                    next: () => {
                        this.$message({
                            message: '删除成功',
                            type: 'success',
                            duration: 2000
                        });
                        this.getList();
                    },
                    error: () => this.$message({
                        showClose: true,
                        message: '删除失败',
                        type: 'error'
                    })
                });
            }).catch(() => {
                this.$message('操作已取消');
            });
        },
        formatJson(filterVal, jsonData) {
            return jsonData.map(v => filterVal.map(j => {
                if (~j.indexOf('Date')) {
                    return parseTime(v[j])
                } else {
                    return v[j]
                }
            }))
        }
    }
}
</script>

<style>

</style>

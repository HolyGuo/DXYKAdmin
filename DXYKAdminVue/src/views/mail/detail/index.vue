<template>
  <div v-loading.body="loading" class="app-container calendar-list-container">
    <el-row class="tool-bar">
      <el-button-group>
        <el-button
          v-if="mailType === 'receive'"
          @click="reply()"
          type="primary"
          icon="edit"
          size="small"
        >回复</el-button>
        <el-button
          v-if="mailType === 'receive'"
          @click="reply(true)"
          type="primary"
          icon="edit"
          size="small"
        >回复全部</el-button>
        <el-button
          v-if="mailType === 'send'"
          @click="edit"
          type="primary"
          icon="edit"
          size="small"
        >编辑</el-button>
        <el-button @click="forward" type="primary" icon="share" size="small">转发</el-button>
        <el-button @click="deleteMail" type="primary" icon="delete" size="small">删除</el-button>
        <el-button @click="initPage" type="primary" size="small">刷新</el-button>
      </el-button-group>
      <el-dropdown split-button type="primary" size="small" menu-align="start">附件
        <el-dropdown-menu slot="dropdown">
          <el-dropdown-item v-for="file in this.attachs" :key="file.name">
            <a @click="OpenPage(file.file_name)"  download>{{file.file_name}}</a>
          </el-dropdown-item>
        </el-dropdown-menu>
      </el-dropdown>
    </el-row>
    <div class="mail-info">
      <div class="title-info">
        <span class="mail-title">{{mail.title}}</span>
      </div>
      <div>
        <el-tag type="primary" class="info-tag">发件人</el-tag>
        <span class="send-name">{{senderName}}</span>
      </div>
      <div>
        <el-tag type="primary" class="info-tag">时间&nbsp;&nbsp;&nbsp;&nbsp;</el-tag>
        {{ sendTime }}
      </div>
      <el-row>
        <el-col :span="1">
          <el-tag type="primary">收件人</el-tag>
        </el-col>
        <el-col :span="22">
          <span v-for="item in this.receivers" :key="item.id" class="target-item">
            <span class="target-name">{{item.receiver_name}}</span>
            <>;
          </span>
        </el-col>
      </el-row>
    </div>
    <div class="mail-content" v-html="mail.content"></div>
  </div>
</template>

<script>
import * as mailDetailAPI from 'api/mail/mail_detail';
import { parseTime } from '@/utils/index';

export default {
  name: 'mail_detail',
  data() {
    return {
      mail: {
        id: '',
        title: '',
        target: [],
        copy: [],
        sender: '',
        sendMail: '',
        receiveDate: '',
        sendDate: '',
        oldFileList: [],
        oldAudioList: [],
        labelList: [],
        isStar: false
      },
      receivers: [],
      loading: true,
      activeGroup: ['target'],
      labelList: [],
      mailType: '',
      mailId: null,
      senderName: '',
      sendTime: '',
      attachs: []
    };
  },
  created() {
    this.initPage();
  },
  computed: {
    showMailTime() {
      return this.mail.receiveDate || this.mail.sendData;
    }
  },
  methods: {
    initPage() {
      this.mailId = this.$route.params.mailId || this.$store.getters.mailId;
      this.mailType = this.$store.getters.mailType;
      this.senderName = this.$store.getters.senderName;
      this.sendTime = this.$store.getters.sendTime;
      this.getDetail();
    },
    getDetail() {
      this.loading = true;
      if (!this.mailId) {
        this.$router.push('/');
      }
      mailDetailAPI.fetchDetail(this.mailId).then(res => {
        this.loading = false;
        this.mail = res.data;
      });
      mailDetailAPI.fetchReceiver(this.mailId).then(res => {
        this.receivers = res.data;
        mailDetailAPI.fetchAttach(res.data[0].attachment_ids).then(res => {
          this.attachs = res.data;
        });
      });
    },
    OpenPage(filename) {
      window.open('http://192.168.173.33/wv/wordviewerframe.aspx?WOPISrc=http://192.168.173.32/wopi/files/' 
      + filename + '&access_token=token&ui=zh-CN');
    },
    reply(isALL) {
      if (isALL) {
        this.$store.commit('SET_PAGE_TYPE', 'replyAll');
      } else {
        this.$store.commit('SET_PAGE_TYPE', 'reply');
      }
      this.$store.commit('SET_MAIL_TYPE', 'receive');
      this.$router.push({ path: '/mail_send/index' });
    },
    edit() {
      this.$store.commit('SET_PAGE_TYPE', 'edit');
      this.$store.commit('SET_MAIL_TYPE', this.mailType);
      this.$router.push({ path: '/mail_send/index' });
    },
    forward() {
      this.$store.commit('SET_PAGE_TYPE', 'forward');
      this.$store.commit('SET_MAIL_TYPE', this.mailType);
      this.$router.push({ path: '/mail_send/index' });
    },
    deleteMail() {
      this.$confirm('是否删除这封邮件', '确认', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
        .then(() => {
          mailDetailAPI.delMail().subscribe({
            next: () => {
              this.$message({
                type: 'success',
                message: '删除成功',
                duration: 1000
              });
              setTimeout(() => this.$router.go(-1), 1000);
            },
            error: () =>
              this.$message({
                type: 'error',
                message: '删除失败'
              })
          });
        })
        .catch();
    },
    delLabel(index) {
      this.mail.labelList.splice(index, 1);
    }
  }
};
</script>

<style>
.tool-bar {
  margin-top: -20px;
  margin-left: -20px;
}

.mail-info {
  background-color: #eff2f7;
}

.mail-info div {
  font-size: 14px;
  margin: 4px;
}

.mail-info .el-tag {
  margin-right: 6px;
}

.title-info {
  padding: 2px 5px;
}

.mail-title {
  font-size: 18px;
  vertical-align: -3px;
}

.detail-mark-star {
  font-size: 18px;
  vertical-align: -3px;
  color: #f08a5d;
  cursor: pointer;
}

.label-item {
  margin-left: 5px;
}

.info-tag {
  margin-left: inherit;
}

.target-board {
  display: inline-block;
}

.send-name,
.target-name {
  color: #1fab89;
  font-weight: 600;
}

.el-collapse-item__header {
  height: 30px;
  line-height: 30px;
  padding-left: 0;
  color: #20a0ff;
  font-size: 13px;
}

.el-collapse-item__content {
  padding: 2px;
}
</style>

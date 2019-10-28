<template>
  <div class="app-container calendar-list-container">
    <el-row :gutter="10">
      <el-col :span="2">
        <el-tag class="target-label" color="#36c6d3">收件人
        </el-tag>
      </el-col>
      <el-col :span="20">
        <multiselect
          v-model="target"
          :options="contacts"
          :multiple="true"
          :taggable="true"
          @tag="addContact"
          :clear-on-select="false"
          :hide-target="true"
          placeholder="请选择或输入联系人"
          label="show"
          track-by="id"
        ></multiselect>
      </el-col>
      <el-col :span="2">
        <el-button type="danger" @click="cleanTarget">清空</el-button>
      </el-col>
    </el-row>
    <el-row :gutter="20">
      <el-col :span="2">
        <el-tag class="target-label" color="#36c6d3">主题</el-tag>
      </el-col>
      <el-col :span="20">
        <el-input v-model="mail.title" placeholder="请输入主题"></el-input>
      </el-col>
    </el-row>
    <el-row :gutter="20">
      <el-col :span="12">
        <el-upload
          class="upload-file"
          ref="upload"
          :data="uploadData"
          :before-upload="handleBefore"
          :on-preview="handlePreview"
          :on-success="handleSuccess"
          :on-remove="handleRemove"
          :show-file-list="true"
          :file-list="mail.oldFileList"
          drag
          action="http://localhost:8088/api/OaAttachment/UploadFile"
          multiple
        >
          <i class="el-icon-upload"></i>
          <i class="el-upload__text">
            将文件拖到此处，或
            <em>点击上传</em>
          </i>
        </el-upload>
        <ul v-show="!!mail.oldFileList.length" class="old-file-list"></ul>
      </el-col>
    </el-row>
    <div class="editor-container">
      <el-input v-model="mail.content" type="textarea" :rows="7" placeholder="请输入内容" style="width:1000px;">
      </el-input>
    </div>
    <el-row>
      <el-col :span="12" :offset="9">
        <el-button type="primary" @click="sendSubmit">发送</el-button>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import { fetchList } from 'api/mail/mail_contacts';
import * as mailSendAPI from 'api/mail/mail_send';
import * as mailDetailAPI from 'api/mail/mail_detail';
import { isEmail, isEmpty, getType } from '@/utils/validate';
import { getNowFormatDate, parseTime } from '@/utils/index';
import { mapGetters } from 'vuex'

export default {
  name: 'mail_send',
  data() {
    return {
      loading: true,
      mail: {
        title: '',
        oldFileList: [],
        oldAudioList: [],
        content: '',
        target: [],
        copy: [],
        fileList: [],
        audioList: []
      },
      date: '',
      target: [],
      copy: [],
      isRecording: false,
      recorder: null,
      contacts: [],
      editorId: 'mail_send_ediotr',
      editorHeight: '400px',
      editorWidth: '200px',
      timing: '',
      uploadData: { userId:"admin" }
    };
  },
  computed: {
    ...mapGetters([
      'token'
    ])
  },
  created() {
    this.initSendPage();
  },
  methods: {
    initSendPage() {
      fetchList().then(res => {
          this.contacts = res.data.contacts;
        });
      this.editorHeight = window.innerHeight - 420;
    },
    addContact(newTag) {
      if (!isEmail(newTag)) {
        this.$message({
          showClose: true,
          message: '输入的邮箱不合法',
          type: 'warning',
          duration: 1200
        });
        return;
      }
      const tag = {
        name: newTag,
        show: newTag,
        mail: newTag
      };
      this.contacts.push(tag);
      this.target.push(tag);
    },
    cleanTarget() {
      this.target = [];
    },
    handleBefore(file) {
      // 上传前可以对要上传文件进行控制
    },
    handleSuccess(file, fileInfo) {
      this.mail.fileList.push(fileInfo.name);
    },
    handlePreview(file) {
      // 预览,一些文件因为格式问题无法预览。推荐使用a标签，src为文件的下载地址，点击即可下载,参照录音
      window.open(file.url);
    },
    handleRemove(file) {
      // 移除
      this.mail.fileList.forEach((item, index) => {
        if (item.uuid === file.uid) {
          this.mail.fileList.splice(index, 1);
        }
      });
    },
    sendSubmit() {
      if (this.target.length < 1) {
        this.$message({
          showClose: true,
          message: '收件人不能为空',
          type: 'warning',
          duration: 1200
        });
        return;
      }
      // 添加到formData前应该根据需求处理数据
      this.target.forEach(item => {
        this.mail.target.push(item.id);
      });
      this.loading = true;
      mailSendAPI.sendMail(this.mail.title, this.mail.content, this.mail.target.join(','),
      this.mail.fileList.join(','),this.token).then(res => {
          if(res.data == '1'){
            this.$message({
              type: 'success',
              message: '发送成功',
              duration: 1200
            });
            this.loading = false;
            this.initMail();
          }
          else{
            this.$message({
              type: 'error',
              message: '发送失败',
              duration: 2000
            });
            this.loading = false;
          }
        });
    },
    initMail() {
      for (const field in this.mail) {
        if (getType(this.mail[field]) === 'String') {
          this.mail[field] = '';
        } else if (getType(this.mail[field]) === 'Array') {
          this.mail[field] = [];
        }
      }
      this.target = [];
      this.copy = [];
      // 编辑器内容与mail.content是双向绑定，上一步中mail.content = ''不知道为什么并没有将编辑器内容清空
      // tinymce.get(this.editorId).setContent('');
    }
  }
};
</script>

<style>
* {
  padding: 0;
  margin: 0;
}

ul {
  list-style: none;
}

audio {
  width: 260px;
}

.tool-bar {
  margin-top: -20px;
  margin-left: -20px;
}

.el-row {
  margin-bottom: 10px;
}

.target-label {
  font-size: 14px;
  padding: 0px 12px;
  margin: 2px 0;
  height: 35px;
  line-height: 35px;
}

.target-label i {
  margin-left: 3px;
}

.upload-file {
  display: inline-block;
  vertical-align: middle;
}

.el-upload-dragger {
  height: 30px;
}

.el-upload-dragger .el-icon-upload {
  font-size: 30px;
  line-height: 20px;
  margin: 3px 0;
}

.audio-name {
  width: 200px;
  vertical-align: 12px;
}

.audio-list > li {
  display: flex;
  align-items: center;
}

.del-audio {
  margin-left: 5px;
  cursor: pointer;
  vertical-align: 10px;
  font-size: 20px;
  color: #00adb5;
}

.send-btn {
  margin-top: 10px;
  margin-right: 60px;
}

.cancel-btn {
  margin-top: 10px;
}

.old-audio-name {
  vertical-align: 10px;
}
</style>


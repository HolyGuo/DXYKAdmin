import request from '@/utils/request'

export function fetchList(data) {
  return request({
      url: 'api/OaMailReceiver/QueryInByFilter',
      method: 'post',
      data
    })
}

export function delReceiveMail(idArr) {
  return request({
      url: 'api/OaMailReceiver/QueryInByFilter',
      method: 'post',
      data
    })
}


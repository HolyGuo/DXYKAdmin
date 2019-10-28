import request from '@/utils/request'

export function fetchDetail(id) {
  return request({
    url: 'api/OaMail/GetById?id='+id,
    method: 'get'
  })
}

export function delMail() {
    return request({
        url: 'api/SysOrg/QueryDataByNameAndType',
        method: 'post',
        data
      })
}

export function fetchList(data) {
  return request({
      url: 'api/OaMailReceiver/QueryByPageAndFilter',
      method: 'post',
      data
    })
}

export function fetchReceiver(mailid) {
  return request({
      url: 'api/OaMailReceiver/QueryByMailId?mailid='+mailid,
      method: 'get'
    })
}

export function fetchAttach(ids) {
  return request({
      url: 'api/OaAttachment/QueryByIds?ids='+ids,
      method: 'get'
    })
}

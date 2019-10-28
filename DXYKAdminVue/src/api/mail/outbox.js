import request from '@/utils/request'

export function fetchList(query) {
    return request({
        url: 'api/SysUser/QueryContacts',
        method: 'get'
      })
}

export function delSendMail(idArr) {
  return request({
      url: 'api/SysUser/QueryContacts',
      method: 'get'
    })
}

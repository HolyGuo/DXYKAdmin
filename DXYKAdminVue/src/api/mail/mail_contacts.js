import request from '@/utils/request'

export function fetchList() {
  return request({
    url: 'api/SysUser/QueryContacts',
    method: 'get'
  })
}


 
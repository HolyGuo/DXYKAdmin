import request from '@/utils/request'

export function add(data) {
  return request({
    url: 'api/SysUser/Insert',
    method: 'post',
    data
  })
}
export function downloadUser() {
  return request({
    url: 'api/users/download',
    method: 'get',
    responseType: 'blob'
  })
}

export function del(id) {
  return request({
    url: 'api/SysUser/DeleteById?id=' + id,
    method: 'delete'
  })
}

export function edit(data) {
  return request({
    url: 'api/SysUser/Update',
    method: 'put',
    data
  })
}

export function updatePass(user) {
  const data = {
    oldPass: user.oldPass,
    newPass: user.newPass
  }
  return request({
    url: 'api/users/updatePass/',
    method: 'post',
    data
  })
}

export function updateEmail(code, data) {
  return request({
    url: 'api/users/updateEmail/' + code,
    method: 'post',
    data
  })
}


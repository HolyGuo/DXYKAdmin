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

export function updatePass(data) {
  return request({
    url: 'api/SysUser/updatePass/',
    method: 'post',
    data
  })
}

export function updateEmail(data) {
  return request({
    url: 'api/SysUser/updateEmail/',
    method: 'post',
    data
  })
}

export function addRelation(data) {
  return request({
    url: 'api/SysUserAppRole/addRelation/',
    method: 'post',
    data
  })
}


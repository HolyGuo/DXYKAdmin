import request from '@/utils/request'

// 获取所有的Role
export function getAll() {
  return request({
    url: 'api/roles/all',
    method: 'get'
  })
}

export function add(data) {
  return request({
    url: 'api/SysAppRole/Insert',
    method: 'post',
    data
  })
}

export function get(id) {
  return request({
    url: 'api/roles/' + id,
    method: 'get'
  })
}

export function getLevel() {
  return request({
    url: 'api/roles/level',
    method: 'get'
  })
}

export function del(id) {
  return request({
    url: 'api/SysAppRole/DeleteById' + id,
    method: 'delete'
  })
}

export function edit(data) {
  return request({
    url: 'api/SysAppRole/Update',
    method: 'put',
    data
  })
}

export function editPermission(data) {
  return request({
    url: 'api/SysAppRoleMap/UpdateMap',
    method: 'post',
    data
  })
}

export function editMenu(data) {
  return request({
    url: 'api/SysAppRoleMap/UpdateMap',
    method: 'post',
    data
  })
}

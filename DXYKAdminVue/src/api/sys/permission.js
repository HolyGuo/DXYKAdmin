import request from '@/utils/request'

// 获取所有的权限树
export function getPermissionTree() {
  return request({
    url: 'api/SysAppAction/GetTree',
    method: 'get'
  })
}

export function add(data) {
  return request({
    url: 'api/permissions',
    method: 'post',
    data
  })
}

export function del(id) {
  return request({
    url: 'api/permissions?id=' + id,
    method: 'delete'
  })
}

export function edit(data) {
  return request({
    url: 'api/permissions',
    method: 'put',
    data
  })
}

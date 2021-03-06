import request from '@/utils/request'

export function getDepts(data) {
  return request({
    url: 'api/SysOrg/QueryDataByNameAndType',
    method: 'post',
    data
  })
}

export function add(data) {
  return request({
    url: 'api/SysOrg/Insert',
    method: 'post',
    data
  })
}

export function del(id) {
  return request({
    url: 'api/SysOrg/DeleteById?id=' + id,
    method: 'delete',
    data: {
      id: id
    }
  })
}

export function edit(data) {
  return request({
    url: 'api/SysOrg/Update',
    method: 'put',
    data
  })
}

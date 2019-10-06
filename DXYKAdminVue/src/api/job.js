import request from '@/utils/request'

export function getAllJob(deptId) {
  const params = {
    deptId,
    page: 0,
    size: 9999
  }
  return request({
    url: 'api/job',
    method: 'get',
    params
  })
}

export function add(data) {
  return request({
    url: 'api/SysJob/Insert',
    method: 'post',
    data
  })
}

export function del(id) {
  return request({
    url: 'api/SysJob/DeleteById' + id,
    method: 'delete'
  })
}

export function edit(data) {
  return request({
    url: 'api/SysJob/Update',
    method: 'put',
    data
  })
}

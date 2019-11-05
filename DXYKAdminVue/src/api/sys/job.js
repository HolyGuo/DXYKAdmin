import request from '@/utils/request'

export function getAllJob(deptId) {
  const data = {
    keyWords: '',
    page: 1,
    limit: 100,
    dept: deptId
  }
  return request({
    url: 'api/SysJob/QueryDataByNameAndTypeByPage',
    method: 'post',
    data
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
    url: 'api/SysJob/DeleteById?id=' + id,
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

import request from '@/utils/request'

export function login(loginname, password, appid) {
  return request({
    url: 'api/Login/SignIn',
    method: 'post',
    data: {
      loginname,
      password,
      appid
    }
  })
}

export function getInfo() {
  return request({
    url: 'auth/info',
    method: 'get'
  })
}

export function getCodeImg() {
  return request({
    url: 'auth/vCode',
    method: 'get'
  })
}

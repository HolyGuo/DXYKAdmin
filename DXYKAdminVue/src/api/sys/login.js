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

export function Authorize(token, appId) {
  return request({
    url: 'api/Authorize/Authorize?token=' + token + '&appId=' + appId,
    method: 'get'
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

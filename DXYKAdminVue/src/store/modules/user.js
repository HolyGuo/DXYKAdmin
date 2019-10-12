import { login, getInfo, Authorize } from '@/api/sys/login'
import { getToken, setToken, removeToken } from '@/utils/auth'
import { decrypt } from '@/utils/rsaEncrypt'
import Config from '@/config'
import router from '@/router/routers'
import store from '@/store'
import { filterAsyncRouter } from '@/store/modules/permission'

const user = {
  state: {
    token: getToken(),
    user: {},
    roles: [],
    // 第一次加载菜单时用到
    loadMenus: false
  },

  mutations: {
    SET_TOKEN: (state, token) => {
      state.token = token
    },
    SET_USER: (state, user) => {
      state.user = user
    },
    SET_ROLES: (state, roles) => {
      state.roles = roles
    },
    SET_LOAD_MENUS: (state, loadMenus) => {
      state.loadMenus = loadMenus
    }
  },

  actions: {
    // 登录
    Login({ commit }, userInfo) {
      const username = userInfo.username
      const password = decrypt(userInfo.password)
      const code = userInfo.code
      // const uuid = userInfo.uuid
      const rememberMe = userInfo.rememberMe
      return new Promise((resolve, reject) => {
        login(username, password, code).then(res => {
          setToken(res.data, rememberMe)
          commit('SET_TOKEN', res.data)
          // 通过appid和token获取授权
          Authorize(res.data, Config.appid).then(res => {
            setUserInfo(res.data.Permission.Action, commit)
            // 加载路由
            const asyncRouter = filterAsyncRouter(res.data.Permission.MenuTree)
            asyncRouter.push({ path: '*', redirect: '/404', hidden: true })
            store.dispatch('GenerateRoutes', asyncRouter).then(() => { // 存储路由
              router.addRoutes(asyncRouter) // 动态添加可访问路由表
            })
            resolve()
          }).catch(error => {
            reject(error)
          })
          // 第一次加载菜单时用到， 具体见 src 目录下的 permission.js
          commit('SET_LOAD_MENUS', true)
          resolve()
        }).catch(error => {
          reject(error)
        })
      })
    },

    // 获取用户信息
    GetInfo({ commit }) {
      return new Promise((resolve, reject) => {
        getInfo().then(res => {
          setUserInfo(res, commit)
          resolve(res)
        }).catch(error => {
          reject(error)
        })
      })
    },

    // 登出
    LogOut({ commit }) {
      return new Promise((resolve, reject) => {
        commit('SET_TOKEN', '')
        commit('SET_ROLES', [])
        removeToken()
        resolve()
      })
    },

    updateLoadMenus({ commit }) {
      return new Promise((resolve, reject) => {
        commit('SET_LOAD_MENUS', false)
      })
    }
  }
}

export const setUserInfo = (res, commit) => {
  // 如果没有任何权限，则赋予一个默认的权限，避免请求死循环
  if (res.length === 0) {
    commit('SET_ROLES', ['ROLE_SYSTEM_DEFAULT'])
  } else {
    commit('SET_ROLES', res)
  }
  commit('SET_USER', res)
}

export default user

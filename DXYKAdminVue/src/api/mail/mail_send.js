import request from '@/utils/request'

export function sendMail(title, content, reciervers, filenames, token) {
    return request({
        url: 'api/OaMail/SendMail',
        method: 'post',
        data: {
          title,
          content,
          reciervers,
          filenames,
          token
        }
      })
}

/**
 * Created by jiachenpan on 16/11/18.
 */

export function parseTime(time) {
  if (time) {
    var date = new Date(time)
    var year = date.getFullYear()
    /* 在日期格式中，月份是从0开始的，因此要加0
     * 使用三元表达式在小于10的前面加0，以达到格式统一  如 09:11:05
     * */
    var month = date.getMonth() + 1 < 10 ? '0' + (date.getMonth() + 1) : date.getMonth() + 1
    var day = date.getDate() < 10 ? '0' + date.getDate() : date.getDate()
    var hours = date.getHours() < 10 ? '0' + date.getHours() : date.getHours()
    var minutes = date.getMinutes() < 10 ? '0' + date.getMinutes() : date.getMinutes()
    var seconds = date.getSeconds() < 10 ? '0' + date.getSeconds() : date.getSeconds()
    // 拼接
    return year + '-' + month + '-' + day + ' ' + hours + ':' + minutes + ':' + seconds
  } else {
    return ''
  }
}

export function formatTime(time, option) {
  time = +time * 1000
  const d = new Date(time)
  const now = Date.now()

  const diff = (now - d) / 1000

  if (diff < 30) {
    return '刚刚'
  } else if (diff < 3600) {
    // less 1 hour
    return Math.ceil(diff / 60) + '分钟前'
  } else if (diff < 3600 * 24) {
    return Math.ceil(diff / 3600) + '小时前'
  } else if (diff < 3600 * 24 * 2) {
    return '1天前'
  }
  if (option) {
    return parseTime(time, option)
  } else {
    return (
      d.getMonth() +
      1 +
      '月' +
      d.getDate() +
      '日' +
      d.getHours() +
      '时' +
      d.getMinutes() +
      '分'
    )
  }
}

export function debounce(func, wait, immediate) {
  let timeout, args, context, timestamp, result

  const later = function() {
    // 据上一次触发时间间隔
    const last = +new Date() - timestamp

    // 上次被包装函数被调用时间间隔last小于设定时间间隔wait
    if (last < wait && last > 0) {
      timeout = setTimeout(later, wait - last)
    } else {
      timeout = null
      // 如果设定为immediate===true，因为开始边界已经调用过了此处无需调用
      if (!immediate) {
        result = func.apply(context, args)
        if (!timeout) context = args = null
      }
    }
  }

  return function(...args) {
    context = this
    timestamp = +new Date()
    const callNow = immediate && !timeout
    // 如果延时不存在，重新设定延时
    if (!timeout) timeout = setTimeout(later, wait)
    if (callNow) {
      result = func.apply(context, args)
      context = args = null
    }

    return result
  }
}

export function isExternal(path) {
  return /^(https?:|mailto:|tel:)/.test(path)
}

// 替换邮箱字符
export function regEmail(email) {
  if (String(email).indexOf('@') > 0) {
    const str = email.split('@')
    let _s = ''
    if (str[0].length > 3) {
      for (var i = 0; i < str[0].length - 3; i++) {
        _s += '*'
      }
    }
    var new_email = str[0].substr(0, 3) + _s + '@' + str[1]
  }
  return new_email
}

// 替换手机字符
export function regMobile(mobile) {
  if (mobile.length > 7) {
    var new_mobile = mobile.substr(0, 3) + '****' + mobile.substr(7)
  }
  return new_mobile
}

/**
 * Check if an element has a class
 * @param {HTMLElement} elm
 * @param {string} cls
 * @returns {boolean}
 */
export function hasClass(ele, cls) {
  return !!ele.className.match(new RegExp('(\\s|^)' + cls + '(\\s|$)'))
}

/**
 * Add class to element
 * @param {HTMLElement} elm
 * @param {string} cls
 */
export function addClass(ele, cls) {
  if (!hasClass(ele, cls)) ele.className += ' ' + cls
}

/**
 * Remove class from element
 * @param {HTMLElement} elm
 * @param {string} cls
 */
export function removeClass(ele, cls) {
  if (hasClass(ele, cls)) {
    const reg = new RegExp('(\\s|^)' + cls + '(\\s|$)')
    ele.className = ele.className.replace(reg, ' ')
  }
}

export function downloadFile(obj, name, suffix) {
  const url = window.URL.createObjectURL(new Blob([obj]))
  const link = document.createElement('a')
  link.style.display = 'none'
  link.href = url
  const fileName = parseTime(new Date()) + '-' + name + '.' + suffix
  link.setAttribute('download', fileName)
  document.body.appendChild(link)
  link.click()
  document.body.removeChild(link)
}

// 当前日期转YYYY-MM-dd格式
export function getNowFormatDate() {
  let date = new Date();
  const separator1 = '-';
  const separator2 = ':';
  let year = date.getFullYear(),
      month = date.getMonth() + 1,
      strDate = date.getDate(),
      hour = date.getHours(),
      minute = date.getMinutes(),
      second = date.getSeconds();
  if (month >= 1 && month <= 9) {
      month = '0' + month;
  }
  if (strDate >= 0 && strDate <= 9) {
      strDate = '0' + strDate;
  }
  if (hour >= 0 && hour <= 9) {
      hour = '0' + hour;
  }
  if (minute >= 0 && minute <= 9) {
      minute = '0' + minute;
  }
  if (second >= 0 && second <= 9) {
      second = '0' + second;
  }
  // 只包含日期
  // date = year + separator1 + month + separator1 + strDate;
  // 包含时间
  date = year + separator1 + month + separator1 + strDate
      + ' ' + hour + separator2 + minute + separator2 + second;
  return date;
}

// 格式化地址栏的参数
export function getQueryObject(url) {
  url = url == null ? window.location.href : url;
  const search = url.substring(url.lastIndexOf('?') + 1);
  const obj = {};
  const reg = /([^?&=]+)=([^?&=]*)/g;
  search.replace(reg, (rs, $1, $2) => {
      const name = decodeURIComponent($1);
      let val = decodeURIComponent($2);
      val = String(val);
      obj[name] = val;
      return rs;
  });
  return obj;
}


/**
*get getByteLen
* @param {Sting} val input value
* @returns {number} output value
*/
export function getByteLen(val) {
  let len = 0;
  for (let i = 0; i < val.length; i++) {
      if (val[i].match(/[^\x00-\xff]/ig) != null) {
          len += 1;
      } else { len += 0.5; }
  }
  return Math.floor(len);
}

export function cleanArray(actual) {
  const newArray = [];
  for (let i = 0; i < actual.length; i++) {
      if (actual[i]) {
          newArray.push(actual[i]);
      }
  }
  return newArray;
}

export function param(json) {
  if (!json) return '';
  return cleanArray(Object.keys(json).map(key => {
      if (json[key] === undefined) return '';
      return encodeURIComponent(key) + '=' +
          encodeURIComponent(json[key]);
  })).join('&');
}

export function param2Obj(url) {
  const search = url.split('?')[1];
  if (search) {
      return JSON.parse('{"' + decodeURIComponent(search).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g, '":"') + '"}')
  } else {
      return {}
  }
}

export function html2Text(val) {
  const div = document.createElement('div');
  div.innerHTML = val;
  return div.textContent || div.innerText;
}

export function objectMerge(target, source) {
  /* Merges two  objects,
   giving the last one precedence */

  if (typeof target !== 'object') {
      target = {};
  }
  if (Array.isArray(source)) {
      return source.slice();
  }
  for (const property in source) {
      if (source.hasOwnProperty(property)) {
          const sourceProperty = source[property];
          if (typeof sourceProperty === 'object') {
              target[property] = objectMerge(target[property], sourceProperty);
              continue;
          }
          target[property] = sourceProperty;
      }
  }
  return target;
}

export function scrollTo(element, to, duration) {
  if (duration <= 0) return;
  const difference = to - element.scrollTop;
  const perTick = difference / duration * 10;
  setTimeout(() => {
      console.log(new Date())
      element.scrollTop = element.scrollTop + perTick;
      if (element.scrollTop === to) return;
      scrollTo(element, to, duration - 10);
  }, 10);
}

export function toggleClass(element, className) {
  if (!element || !className) {
      return;
  }
  let classString = element.className;
  const nameIndex = classString.indexOf(className);
  if (nameIndex === -1) {
      classString += '' + className;
  } else {
      classString = classString.substr(0, nameIndex) + classString.substr(nameIndex + className.length);
  }
  element.className = classString;
}

export const pickerOptions = [
  {
      text: '今天',
      onClick(picker) {
          const end = new Date();
          const start = new Date(new Date().toDateString());
          end.setTime(start.getTime());
          picker.$emit('pick', [start, end]);
      }
  }, {
      text: '最近一周',
      onClick(picker) {
          const end = new Date(new Date().toDateString());
          const start = new Date();
          start.setTime(end.getTime() - 3600 * 1000 * 24 * 7);
          picker.$emit('pick', [start, end]);
      }
  }, {
      text: '最近一个月',
      onClick(picker) {
          const end = new Date(new Date().toDateString());
          const start = new Date();
          start.setTime(start.getTime() - 3600 * 1000 * 24 * 30);
          picker.$emit('pick', [start, end]);
      }
  }, {
      text: '最近三个月',
      onClick(picker) {
          const end = new Date(new Date().toDateString());
          const start = new Date();
          start.setTime(start.getTime() - 3600 * 1000 * 24 * 90);
          picker.$emit('pick', [start, end]);
      }
  }]

export function getTime(type) {
  if (type === 'start') {
      return new Date().getTime() - 3600 * 1000 * 24 * 90
  } else {
      return new Date(new Date().toDateString())
  }
}


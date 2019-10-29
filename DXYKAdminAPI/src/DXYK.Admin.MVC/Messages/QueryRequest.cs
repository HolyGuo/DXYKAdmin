//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using System;
using System.ComponentModel.DataAnnotations;

namespace DXYK.Admin.MVC.Messages
{

    /// <summary>
    /// 查询请求
    /// </summary>
    public class QueryRequest
    {
        /// <summary>
        /// 单页行数
        /// </summary>
        [Range(1, 100)]
        public int limit { get; set; }
    }

    /// <summary>
    /// 分页查询请求
    /// </summary>
    public class QueryByPageRequest : QueryRequest
    {
        /// <summary>
        /// 群组id
        /// </summary>
        public string groupId { get; set; }
        /// <summary>
        /// 查询关键字
        /// </summary>
        public string keyWords { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        [Range(1, int.MaxValue)]
        public int page { get; set; } = 1;

        /// <summary>
        /// 忽略
        /// </summary>
        public int offset { get { return (page - 1) * limit; } }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string field { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public string order { get; set; }

        /// <summary>
        /// 拼接排序sortField + order (如： id Asc)
        /// </summary>
        public string OrderBy
        {
            get
            {
                if (!string.IsNullOrEmpty(field) && !string.IsNullOrEmpty(order))
                {
                    return field + " " + order;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
    /// <summary>
    /// 分页查询请求带查询参数
    /// </summary>
    public class QueryByPageWithParamRequest : QueryByPageRequest
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? startTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? endTime { get; set; }
    }

    /// <summary>
    /// 查询名称状态参数
    /// </summary>
    public class NameQueryRequest
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string enabled { get; set; }
    }


    /// <summary>
    /// 分页查询名称状态请求
    /// </summary>
    public class QueryNameByPageRequest : NameQueryRequest
    {
        /// <summary>
        /// 页码
        /// </summary>
        [Range(1, int.MaxValue)]
        public int page { get; set; } = 1;

        /// <summary>
        /// 单页行数
        /// </summary>
        [Range(1, 100)]
        public int limit { get; set; }

        /// <summary>
        /// 忽略
        /// </summary>
        public int offset { get { return (page - 1) * limit; } }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string field { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public string order { get; set; }

        /// <summary>
        /// 拼接排序sortField + order (如： id Asc)
        /// </summary>
        public string OrderBy
        {
            get
            {
                if (!string.IsNullOrEmpty(field) && !string.IsNullOrEmpty(order))
                {
                    return field + " " + order;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }

    /// <summary>
    /// 分页查询名称状态请求
    /// </summary>
    public class QueryByDeptRequest : QueryNameByPageRequest
    {
        /// <summary>
        /// 排序字段
        /// </summary>
        public string dept { get; set; }
    }
}




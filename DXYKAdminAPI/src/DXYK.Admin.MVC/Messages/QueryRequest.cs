//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using System;
using System.ComponentModel.DataAnnotations;

namespace DXYK.Admin.MVC.Messages
{

    /// <summary>
    /// ��ѯ����
    /// </summary>
    public class QueryRequest
    {
        /// <summary>
        /// ��ҳ����
        /// </summary>
        [Range(1, 100)]
        public int limit { get; set; }
    }

    /// <summary>
    /// ��ҳ��ѯ����
    /// </summary>
    public class QueryByPageRequest : QueryRequest
    {
        /// <summary>
        /// Ⱥ��id
        /// </summary>
        public string groupId { get; set; }
        /// <summary>
        /// ��ѯ�ؼ���
        /// </summary>
        public string keyWords { get; set; }
        /// <summary>
        /// ҳ��
        /// </summary>
        [Range(1, int.MaxValue)]
        public int page { get; set; } = 1;

        /// <summary>
        /// ����
        /// </summary>
        public int offset { get { return (page - 1) * limit; } }

        /// <summary>
        /// �����ֶ�
        /// </summary>
        public string field { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string order { get; set; }

        /// <summary>
        /// ƴ������sortField + order (�磺 id Asc)
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
    /// ��ҳ��ѯ�������ѯ����
    /// </summary>
    public class QueryByPageWithParamRequest : QueryByPageRequest
    {
        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public DateTime? startTime { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? endTime { get; set; }
    }

    /// <summary>
    /// ��ѯ����״̬����
    /// </summary>
    public class NameQueryRequest
    {
        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string enabled { get; set; }
    }


    /// <summary>
    /// ��ҳ��ѯ����״̬����
    /// </summary>
    public class QueryNameByPageRequest : NameQueryRequest
    {
        /// <summary>
        /// ҳ��
        /// </summary>
        [Range(1, int.MaxValue)]
        public int page { get; set; } = 1;

        /// <summary>
        /// ��ҳ����
        /// </summary>
        [Range(1, 100)]
        public int limit { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public int offset { get { return (page - 1) * limit; } }

        /// <summary>
        /// �����ֶ�
        /// </summary>
        public string field { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string order { get; set; }

        /// <summary>
        /// ƴ������sortField + order (�磺 id Asc)
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
    /// ��ҳ��ѯ����״̬����
    /// </summary>
    public class QueryByDeptRequest : QueryNameByPageRequest
    {
        /// <summary>
        /// �����ֶ�
        /// </summary>
        public string dept { get; set; }
    }
}




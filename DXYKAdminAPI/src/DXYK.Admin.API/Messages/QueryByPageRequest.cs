//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using System.ComponentModel.DataAnnotations;

namespace DXYK.Admin.API.Messages
{
    /// <summary>
    /// QueryByPageRequest
    /// </summary>
    public class QueryByPageRequest
    {
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
        /// ��ҳ����
        /// </summary>
        [Range(1, 100)]
        public int limit { get; set; } = 10;

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
}

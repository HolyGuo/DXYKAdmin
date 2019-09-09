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
        /// ²éÑ¯¹Ø¼ü×Ö
        /// </summary>
        public string keyWords { get; set; }
        /// <summary>
        /// Ò³Âë
        /// </summary>
        [Range(1, int.MaxValue)]
        public int page { get; set; } = 1;

        /// <summary>
        /// µ¥Ò³ÐÐÊý
        /// </summary>
        [Range(1, 100)]
        public int limit { get; set; } = 10;

        /// <summary>
        /// ºöÂÔ
        /// </summary>
        public int offset { get { return (page - 1) * limit; } }

        /// <summary>
        /// ÅÅÐò×Ö¶Î
        /// </summary>
        public string field { get; set; }

        /// <summary>
        /// ÅÅÐò
        /// </summary>
        public string order { get; set; }

        /// <summary>
        /// Æ´½ÓÅÅÐòsortField + order (Èç£º id Asc)
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

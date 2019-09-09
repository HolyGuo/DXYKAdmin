//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using System.ComponentModel.DataAnnotations;

namespace DXYK.Admin.API.Messages
{
    /// <summary>
    /// QueryRequest
    /// </summary>
    public class QueryRequest
    {
        /// <summary>
        /// µ¥Ò³ÐÐÊý
        /// </summary>
        [Range(1, 100)]
        public int limit { get; set; }
    }
}




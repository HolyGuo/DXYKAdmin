//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DXYK.Admin.API.Messages
{
    /// <summary>
    /// QueryByPageResponse
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public class QueryByPageResponse<TItem> : QueryResponse<TItem>
    {
        /// <summary>
        /// ×ÜÊý
        /// </summary>
        public int count { get; set; }
    }
}




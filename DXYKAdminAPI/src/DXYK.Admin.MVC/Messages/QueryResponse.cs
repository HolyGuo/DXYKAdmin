//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using System.Collections.Generic;

namespace DXYK.Admin.MVC.Messages
{
    /// <summary>
    /// QueryResponse
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public class QueryResponse<TItem>
    {
        /// <summary>
        /// Êý¾ÝÐÐ
        /// </summary>
        public IEnumerable<TItem> data { get; set; }
    }
}




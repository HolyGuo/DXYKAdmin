//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************

namespace DXYK.Admin.MVC.Messages
{
    /// <summary>
    /// QueryByPageResponse
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public class QueryByPageResponse<TItem> : QueryResponse<TItem>
    {
        /// <summary>
        /// ����
        /// </summary>
        public int count { get; set; }
    }
}




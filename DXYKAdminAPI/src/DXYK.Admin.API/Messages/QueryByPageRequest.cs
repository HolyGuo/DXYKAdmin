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
    /// QueryByPageRequest
    /// </summary>
    public class QueryByPageRequest
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
        public int limit { get; set; } = 10;

        /// <summary>
        /// ����
        /// </summary>
        public int offset { get { return (page - 1) * limit; } }
    }
}

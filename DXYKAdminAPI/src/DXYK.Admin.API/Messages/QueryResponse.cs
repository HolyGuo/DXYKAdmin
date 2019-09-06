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
    public class QueryResponse<TItem>
    {
        public IEnumerable<TItem> data { get; set; }
    }
}




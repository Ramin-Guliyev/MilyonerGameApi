using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milyoner.Models
{
    public class ResponseDataModel<T>:ResponseModel
    {
        public T Data { get; set; }
    }
}

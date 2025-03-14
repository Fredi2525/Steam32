using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Managers
{
    public class ManagerResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class ManagerResult<T> : ManagerResult
    {
	    public T Data { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Model.APP
{
    public class ApiResponseObj
    {
        public object data { get; set; }
        public string message { get; set; }
        public bool status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeanZhang.WebAPI
{
    public class ResponseModel<T>
    {
        public int status { get; set; } = 200;

        public string msg { get; set; } = "操作成功！";

        public T data { get; set; }

        public void Success(T data, string msg = "")
        {
            this.status = 200;
            this.msg = msg;
            this.data = data;
        }
    }
}

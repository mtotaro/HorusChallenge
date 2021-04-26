using System;
using System.Collections.Generic;
using System.Text;

namespace Horus.Core.Dtos
{
    public class RequestResult<T> where T : class
    {
        public T Data { get; set; }
    }
}

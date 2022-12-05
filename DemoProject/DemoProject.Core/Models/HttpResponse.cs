using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Core.Models
{
    public sealed class HttpResponse<T>
    {
        public T ResponseObject { get; set; }
    }
}

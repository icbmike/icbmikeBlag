using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IcbmikeBlag.Models
{
    public abstract class BlagModelBase
    {
        public bool IsAuthenticated { get { return HttpContext.Current.Request.IsAuthenticated; } }
    }
}
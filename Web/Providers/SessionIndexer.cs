using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Providers
{
    public class SessionIndexer
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public SessionIndexer(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
         
        public object this[string key]
        {
            set
            {
                _session.SetString(key,value: "");
            }
            get
            {
                return _session.GetString(key);
            }
        }
    }

    
}

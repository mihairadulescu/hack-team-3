using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;

namespace corrida.Controllers
{
    public class HomeController : ApiController
    {  
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        } 

    }
}

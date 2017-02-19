using System.Collections.Generic;
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

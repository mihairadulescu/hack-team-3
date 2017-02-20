using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace corrida.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class HomeController : ApiController
    {  
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        } 

    }
}

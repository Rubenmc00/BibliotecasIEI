using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiServer.Extractores;

namespace WebApiServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CargaController : ControllerBase
    {
        [HttpGet]
        public string[] obtenerEus()
        {
            extractorEUS extractor = new extractorEUS();
            return extractor.cogerCodigoAsync();
        }
    }
}

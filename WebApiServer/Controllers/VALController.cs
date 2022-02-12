using Aspose.Cells;
using Aspose.Cells.Utility;
using BibliotecasIEI.Modelos;
using ChoETL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VALController
    {
        [HttpGet]
        public List<BibliotecaVAL> Get()
        {
            
            StreamReader r = new StreamReader("Archivos/demo/CV.json");
            string valJson = r.ReadToEnd();
            var valList = JsonConvert.DeserializeObject<List<BibliotecaVAL>>(valJson);
            return valList;
        }

    }
}

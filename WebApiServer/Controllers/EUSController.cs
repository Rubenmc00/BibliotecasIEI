using BibliotecasIEI.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EUSController
    {
        [HttpGet]
        public List<BibliotecaEUS> Get()
        {
            StreamReader r = new StreamReader("Archivos/demo/EUS.json");
            string eusJson = r.ReadToEnd();
            var eusList = JsonConvert.DeserializeObject<List<BibliotecaEUS>>(eusJson);
            //System.Diagnostics.Debug.WriteLine(the_array + "++++++++++++++");
            return eusList;
        }

    }
}

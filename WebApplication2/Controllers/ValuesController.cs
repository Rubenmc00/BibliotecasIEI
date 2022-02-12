using BibliotecasIEI.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("{id}")] 
        public string get(int id) {
            return id switch
            {
                1 => "ASIER FEO",

                2 => "NYONYET MANCO",

                _ => throw new NotSupportedException("ASIER SA ENGAÑAO")

            };
                
            
        }
    }


    private List<BibliotecaEUS> ObtenerBibliotecasEUS()
    {
        StreamReader r = new StreamReader("Archivos/demo/EUS.json");
        string eusJson = r.ReadToEnd();
        var eusList = JsonConvert.DeserializeObject<List<BibliotecaEUS>>(eusJson);
        return eusList;
    }
}

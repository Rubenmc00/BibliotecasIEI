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
        [HttpGet("EXTR1")]
        public async Task<string> obtenerEusAsync(int id)
        {
            extractorEUS extractor = new extractorEUS();
            //_ = await extractor.cogerCodigoAsyncEUS();
            return await extractor.cogerCodigoAsyncEUS(); 
        }
        [HttpGet("EXTR2")]
        public async Task<string> obtenerCatAsync(int id)
        {
            extractorCAT extractor = new extractorCAT();
            _ = await extractor.cogerCodigoAsyncCAT();
            return "";
        }
        [HttpGet("EXTR3")]
        public async Task<string> obtenerValAsync(int id)
        {
            extractorVAL extractor = new extractorVAL();
            _ = await extractor.cogerCodigoAsyncVAL();
            return "";
        }
        [HttpGet("Borrar")]
        public async Task<string> obtenerBorrarAsync(int id)
        {
            extractorVAL extractor = new extractorVAL();
            _ = await extractor.cogerCodigoAsyncVAL();
            return "";
        }

    }
}

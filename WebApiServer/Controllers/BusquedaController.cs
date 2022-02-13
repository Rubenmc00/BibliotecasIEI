using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApiServer.Busqueda;

namespace WebApiServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BusquedaController : ControllerBase
    {
        [HttpGet]
        public async Task<string> accesoDatos()
        {
                SqlConnection sqlConnection1 = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ruben\\Desktop\\BibliotecasIEI\\BibliotecasIEI\\bin\\Debug\\BaseDeDatos.mdf;Integrated Security=True");
               
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("select * from Biblioteca For JSON PATH");
                cmd.Connection = sqlConnection1;
                cmd.CommandType = CommandType.Text;
                
                

            SqlDataReader registros = cmd.ExecuteReader();
            //System.Diagnostics.Debug.WriteLine(cmd.ExecuteReader().Read());
            while (registros.Read())
            {
                ReadSingleRow((IDataRecord)registros);
            }
            

            return "";
        }

        private static void ReadSingleRow(IDataRecord record) { Console.WriteLine(String.Format("{0}, {1}", record[0], record[1])); }
    }
}




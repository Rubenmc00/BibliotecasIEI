using BibliotecasIEI.Modelos;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiServer.Extractores
{
    public class extractorVAL
    {
        public async Task<string> cogerCodigoAsyncVAL()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:63554/VAL");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    var CV = JsonConvert.DeserializeObject<List<BibliotecaVAL>>(message);
                    List<string> codProvincias = new List<string>();
                    List<string> codMunicipios = new List<string>();
                    for (int i = 0; i < CV.Count; i++)
                     {

                        
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("port=53100");
                        ChromeDriver driver = new ChromeDriver("C:\\Users\\Ruben\\Desktop\\BibliotecasIEI\\WebApiServer\\bin\\Debug\\net5.0");
                        driver.Url = "https://www.coordenadas-gps.com/";
                       
                        options.AddArgument("--headless");
                        options.AddArgument("--disable-geolocation");
                        driver.Manage().Window.Maximize();
                        //Thread.Sleep(1000);


                        driver.FindElement(By.Id("longitude")).Clear();
                             driver.FindElement(By.Id("latitude")).Clear();
                             Thread.Sleep(1000);

                             driver.FindElement(By.Id("address")).Clear();
                             driver.FindElement(By.Id("address")).SendKeys(CV[i].DIRECCION);

                             driver.FindElement(By.XPath("//button[text()='Obtener Coordenadas GPS']")).Click();

                            // Thread.Sleep(2500);

                             //Thread.Sleep(1000);
                             String longi = driver.FindElement(By.Id("longitude")).GetAttribute("value");
                             String lat = driver.FindElement(By.Id("latitude")).GetAttribute("value");

                             Thread.Sleep(1000);
                             driver.Quit();

                             System.Diagnostics.Debug.WriteLine(CV[i].COD_MUNICIPIO);

                             String telf = CV[i].TELEFONO.Substring(6);

                            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ruben\\Desktop\\BibliotecasIEI\\BibliotecasIEI\\bin\\Debug\\BaseDeDatos.mdf;Integrated Security=True");

                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.Text;

                            cmd.Connection = sqlConnection1;
                            sqlConnection1.Open();
                        if (i != 0)
                        {

                            if (!codMunicipios.Contains(CV[i].COD_MUNICIPIO))
                            {

                                codMunicipios.Add(CV[i].COD_MUNICIPIO);
                                cmd.CommandText = "INSERT Localidad(codigoMunicipal, municipio, codProvincia)" +
                            " values ('" + CV[i].COD_MUNICIPIO + "', '" + CV[i].NOM_MUNICIPIO + "', '" + CV[i].COD_PROVINCIA + "')";
                                cmd.ExecuteNonQuery();

                            }
                            if (!codProvincias.Contains(CV[i].COD_PROVINCIA))
                            {
                                codProvincias.Add(CV[i].COD_PROVINCIA);
                                cmd.CommandText = "INSERT Provincia(codigo, provincia)" +
                            " values ('" + CV[i].COD_PROVINCIA + "', '" + CV[i].NOM_PROVINCIA + "')";
                                cmd.ExecuteNonQuery();
                            }

                        }
                        else
                        {
                            codProvincias.Add(CV[i].COD_PROVINCIA);
                            codMunicipios.Add(CV[i].COD_MUNICIPIO);
                            cmd.CommandText = "INSERT Localidad(codigoMunicipal, municipio, codProvincia)" +
                             " values ('" + CV[i].COD_MUNICIPIO + "', '" + CV[i].NOM_MUNICIPIO + "', '" + CV[i].COD_PROVINCIA + "')";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "INSERT Provincia(codigo, provincia)" +
                           " values ('" + CV[i].COD_PROVINCIA + "', '" + CV[i].NOM_PROVINCIA + "')";
                            cmd.ExecuteNonQuery();
                        }

                        cmd.CommandText = "INSERT Biblioteca(nombre, telefono, email, direccion, codigoPostal, longitud, latitud, tipo, descripcion, codMunicipal)" +
                        " values ('" + CV[i].NOMBRE + "', '" + telf + "', '" + CV[i].EMAIL + "', '" + CV[i].DIRECCION + "', '"
                                     + CV[i].CP + "', '" + longi + "', '" + lat + "', '" + CV[i].TIPO + "', '" + CV[i].DES_CARACTER + "', '" + CV[i].COD_MUNICIPIO + "')";

                        cmd.ExecuteNonQuery();
                        sqlConnection1.Close();
                    }
                        
                    }
                return "";
            }
        }
    }
}
